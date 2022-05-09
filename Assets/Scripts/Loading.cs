using System.Collections;
using System.Collections.Generic;
using Unity.Usercentrics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour
{

    float delay = 3f;


    private void Awake()
    {
        Usercentrics usercentric = Usercentrics.Instance;

    }
    // Start is called before the first frame update
    void Start()
    {
        Invoke("StartGame", delay);
    }

    void StartGame()
    {
        SceneManager.LoadSceneAsync(1);

    }
}
