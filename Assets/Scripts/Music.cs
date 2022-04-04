using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    public static Music Instance { get; private set; }
    void Awake()
    {

        if (Instance)
        {
            DestroyImmediate(gameObject);
            return;
        }
        else
        {
            Instance = this; 
            DontDestroyOnLoad(gameObject);
        }

       
    }


}
