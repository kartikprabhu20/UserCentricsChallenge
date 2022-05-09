
using Unity.Usercentrics;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Class to access business logic from settings panel.
/// </summary>
public class SettingsManager : ConsentManager
{
    [SerializeField] GameObject settingPanel;
    [SerializeField] GameObject confirmationPanel;


    //private void Awake()
    //{
    //    base.InitAndShowConsent();
    //}

    // Start is called before the first frame update
    void Start()
    {
        settingPanel.SetActive(false);
    }


    public void resetConsentToDefault()
    {
        getUserCentrics().Reset();
        //DontDestroyOnLoad(this.gameObject);
        //SceneManager.LoadSceneAsync(0);
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
        ShowFirstLayer();
    }

}
