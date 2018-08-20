using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Obsolete("Singleton is an anti-pattern")]
public class MonoBehaviourSingleton<T> : MonoBehaviour  where T : class 
{
    public static T instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this as T;
            DontDestroyOnLoad(this);
        }
        else if(instance != this as T)
        {
            Debug.LogWarning($"Destroying {gameObject.name}. Another instance of object has been found");
            Destroy(gameObject);
        }
        OnAwake();
    }

    public virtual void OnAwake()
    {

    }
}
