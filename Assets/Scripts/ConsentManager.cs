using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Usercentrics;
using System.Net.NetworkInformation;
using System;

public class ConsentManager : MonoBehaviour
{
    public const string TAG = "Usercentric Challenge: ";
    private Usercentrics usercentrics = null;
    private IFrameWorkFactory frameWorkFactory = null;
    private NetworkAvailabilityChangedEventHandler networkChangeHandler = null;

    void Awake()
    {
        //DI
        usercentrics = Usercentrics.Instance;
        frameWorkFactory = FrameWorkFactory.Instance;

        InitAndShowConsent();
    }

    protected void InitAndShowConsent()
    {
        if (!usercentrics.IsInitialized)
        {
            usercentrics.Initialize((usercentricsReadyStatus) =>
            {
                Debug.Log(TAG + " Initialize " + usercentricsReadyStatus.shouldCollectConsent.ToString());
                if (usercentricsReadyStatus.shouldCollectConsent)
                {
                    ShowFirstLayer();
                }
                else
                {
                    UpdateServices(usercentricsReadyStatus.consents);
                }
                networkChangeHandler = null; //If Initialize is successful no need to listen for network changes.
            },
            (errorMessage) => {
                Debug.Log(TAG + errorMessage);
                if (Application.internetReachability == NetworkReachability.NotReachable)
                {
                    Debug.Log(TAG + "NetworkReachability.NotReachable");

                    //Unfortunately the below sample does not work for android device, but similar listner can be observed for onConnectiviryAvailable.
                    networkChangeHandler += new NetworkAvailabilityChangedEventHandler(AvailabilityChanged);
                }
                //Display toast or snackbar or prompt saying internet connection is missing
            });

        }
        else
        {
            ShowFirstLayer();
        }
        
    }

    private void AvailabilityChanged(object sender, NetworkAvailabilityEventArgs e)
    {
        if (e.IsAvailable && !usercentrics.IsInitialized)
        {
            Debug.Log(TAG + "Internet connected ");
            InitAndShowConsent();
        }
            
        else
            Debug.Log(TAG + "Internet disconnected ");
    }

    public Usercentrics getUserCentrics()
    {
        return usercentrics;
    }

    public void ShowFirstLayer()
    {
        //Debug.Log(TAG + " ShowFirstLayer");
        try
        {
            usercentrics.ShowFirstLayer(UsercentricsLayout.PopupBottom, (usercentricsConsentUserResponse) =>
            {
                checkInteractionAndUpdateService(usercentricsConsentUserResponse);
            });
        }
        catch(NotInitializedException ex){
            Debug.Log(ex);
            InitAndShowConsent();
        }
    }

    private void checkInteractionAndUpdateService(UsercentricsConsentUserResponse usercentricsConsentUserResponse)
    {
        //Debug.Log(TAG + " Interaction " + usercentricsConsentUserResponse.userInteraction.ToString());
        if (usercentricsConsentUserResponse.userInteraction != UsercentricsUserInteraction.NoInteraction)
            UpdateServices(usercentricsConsentUserResponse.consents);
    }

    public void UpdateServices(List<UsercentricsServiceConsent> consents)
    {
        //Debug.Log(TAG + " UpdateServices");

        foreach (var serviceConsent in consents)
        {
            //Debug.Log(TAG + serviceConsent.dataProcessor+" "+ serviceConsent.templateId + " " + serviceConsent.status.ToString());

            IFrameWork framework = frameWorkFactory.GetFrameWork(serviceConsent.templateId);

            //Example to execute framework related work.
            //framework.enableFrameWork(serviceConsent.status);
            //framework.init();
            //framework.process();
        }
    }
}
