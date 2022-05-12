
using System.Collections.Generic;
using System.Net.NetworkInformation;
using Unity.Usercentrics;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Class to access business logic from settings panel.
/// </summary>
public class SettingsManager : MonoBehaviour,IUsercentricBridgeUpdate
{
    [SerializeField] GameObject settingPanel;
    [SerializeField] GameObject confirmationPanel;
    [SerializeField] GameObject snackbar;

    private ConsentManager consentManager = null;
    private IFrameworkFactory frameWorkFactory = null;
    private NetworkAvailabilityChangedEventHandler networkChangeHandler = null;

    private void Awake()
    {
        //DI
        consentManager = ConsentManager.Instance;
        frameWorkFactory = FrameworkFactory.Instance;
    }

    // Start is called before the first frame update
    public void Start()
    {
        settingPanel.SetActive(false);
        consentManager.UsercentricInitialize(this);

    }

    public void resetConsentToDefault()
    {
        consentManager.Reset();
        SceneManager.LoadSceneAsync(0); 
    }

    public void enableSettingsPanel()
    {
        settingPanel.SetActive(true);

    }

    public void disableSettingsPanel()
    {
        settingPanel.SetActive(false);

    }

    public void enableConfirmationPanel()
    {
        confirmationPanel.SetActive(true);
        disableSettingsPanel();

    }

    public void disableConfirmationPanel()
    {
        confirmationPanel.SetActive(false);
        enableSettingsPanel();

    }

    public void openConsentPanel()
    {
        consentManager.ShowFirstLayer(this);
    }

    public void onComplete()
    {
        consentManager.SubscribeOnConsentChange(this);
        openConsentPanel();
        networkChangeHandler = null; //If Initialize is successful no need to listen for network changes.
    }

    public void onError(string errorMessage)
    {
        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            //Unfortunately the below sample does not work for android device, but similar listner can be observed for onConnectiviryAvailable.
            networkChangeHandler += new NetworkAvailabilityChangedEventHandler(AvailabilityChanged);
            snackbar.SetActive(true);
            Invoke("disableSnackbar", 3f);// Show snackbar for 3 seconds
        }
    }

    private void disableSnackbar()
    {
        snackbar.SetActive(false);

    }

    private void AvailabilityChanged(object sender, NetworkAvailabilityEventArgs e)
    {
        if (e.IsAvailable)
        {
            Debug.Log("Internet connected ");
            consentManager.UsercentricInitialize(this);
        }
        else
        {
            Debug.Log("Internet disconnected ");

        }
    }

    public void onServiceUpdate(List<UsercentricsServiceConsent> consents)
    {

        foreach (var serviceConsent in consents)
        {
            Debug.Log("onServiceUpdate: "+serviceConsent.templateId);

            IFramework framework = frameWorkFactory.GetFrameWork(serviceConsent.templateId);

            //Example to execute framework related work.
            framework.enableFrameWork(serviceConsent.status);
            //framework.init();
            //framework.process();
        }

    }

}
