using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Collectible : MonoBehaviour{
    public static event Action OnCollected;
    public static int total = 5;

    void OnTriggerEnter(Collider other){
        if (other.CompareTag("Player"))
        {
            OnCollected?.Invoke();
            Destroy(gameObject);
        }
    }

    public static void SubscribeToCollectedEvent(Action handler){
        OnCollected += handler;
    }

    public static void UnsubscribeFromCollectedEvent(Action handler){
        OnCollected -= handler;
    }
}
