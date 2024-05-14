using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour, new()
{
    private static T _instance;

    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new T();
                GameObject singletonGameObject = new GameObject("PatternGameObject");
                _instance = singletonGameObject.AddComponent<T>();
                DontDestroyOnLoad(singletonGameObject);
            }

            return _instance;
        }
    }

    protected Singleton() 
    {
        
    }
}
