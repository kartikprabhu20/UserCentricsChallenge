
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// Class to move between scenes
/// </summary>
public class SceneLoader : MonoBehaviour, IUsercentricBridge
{

    [SerializeField]  public GameObject ConnectivityPanel;
    [SerializeField] public Button RetryButton;
    [SerializeField] public Button ProceedButton;


    private ConsentManager consentManager = null;

    private void Awake()
    {
        consentManager = ConsentManager.Instance;

        RetryButton.onClick.AddListener(() => {
            ConnectivityPanel.SetActive(false);
            InitializeUserCentrics();
        });
        ProceedButton.onClick.AddListener(() => { StartGame(); });

    }

    // Start is called before the first frame update
    public void Start()
    {
        InitializeUserCentrics();
    }

    private void InitializeUserCentrics()
    {
        consentManager.UsercentricInitialize(this);
    }

    public void onComplete()
    {
        StartGame();
    }

    public void onError(string errorMessage)
    {
        ConnectivityPanel.SetActive(true);
    }


    void StartGame()
    {
        SceneManager.LoadSceneAsync(1);

    }
}

