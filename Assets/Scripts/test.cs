using System.Collections;
using System.Collections.Generic;
using Unity.Usercentrics;
using UnityEngine;

public class test : MonoBehaviour
{
    private Usercentrics t = null;

    void Awake()
    {
        t= Usercentrics.Instance; 
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy()
    {
        Debug.Log("test onDestroy");
    }
}

public class test2: Singleton<test2>
{
    private void OnDestroy()
    {
        Debug.Log("test2 onDestroy");
    }
}