using UnityEngine;
using Unity.Usercentrics;

/// <summary>
/// Buffer class between views and Usercentrics apis.
/// </summary>
///

public class ConsentManager : Singleton<ConsentManager>
{
    private Usercentrics usercentrics = null;

    public void Awake()
    {
        //DI
        usercentrics = Usercentrics.Instance;
    }

    internal void Reset()
    {
        usercentrics.Reset();
    }

    public void UsercentricInitialize(IUsercentricBridge usercentricInitBridge)
    {
        if (!usercentrics.IsInitialized)
        {
            usercentrics.Initialize((usercentricsReadyStatus) =>
            {
                //Debug.Log(TAG + " Initialize " + usercentricsReadyStatus.shouldCollectConsent.ToString());
                  usercentricInitBridge.onComplete();
            },
            (errorMessage) => {
                //Debug.Log(TAG + errorMessage);
                usercentricInitBridge.onError(errorMessage);
            });
        }
        else
        {
            usercentricInitBridge.onComplete();
        }
    }

    public void ShowFirstLayer(IUsercentricBridgeUpdate userCentricUpdate)
    {
        try
        {
            usercentrics.ShowFirstLayer(UsercentricsLayout.PopupBottom, (usercentricsConsentUserResponse) =>
            {
                checkInteractionAndUpdateService(usercentricsConsentUserResponse, userCentricUpdate);
            });
        }
        catch(NotInitializedException ex){
            Debug.Log(ex);
            UsercentricInitialize(userCentricUpdate);
        }
    }

    private void checkInteractionAndUpdateService(UsercentricsConsentUserResponse usercentricsConsentUserResponse, IUsercentricBridgeUpdate userCentricUpdate)
    {
        //Debug.Log(TAG + " Interaction " + usercentricsConsentUserResponse.userInteraction.ToString());
        if (usercentricsConsentUserResponse.userInteraction != UsercentricsUserInteraction.NoInteraction)
        {
            userCentricUpdate.onServiceUpdate(usercentricsConsentUserResponse.consents);

        }
    }

    public void SubscribeOnConsentChange(IUsercentricBridgeUpdate userCentricUpdate)
    {

        Debug.Log("SubscribeOnConsentChange");
        usercentrics.SubscribeOnConsentUpdated((usercentricsUpdatedConsentEvent) =>
        {
            //Service can be updated here, or it can be updated immediately after user interaction with firstlayer 
            //userCentricUpdate.onServiceUpdate(usercentricsUpdatedConsentEvent.consents);

        }
        );
    }

}
