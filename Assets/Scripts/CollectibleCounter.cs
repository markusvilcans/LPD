using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class CollectibleCounter : MonoBehaviour
{
    TMPro.TMP_Text text;
    int count;
    public static bool won;

    void Start(){
        won = false;
        UpdateCount();
    }

    void Awake(){
        text = GetComponent<TMPro.TMP_Text>();
    }

    void OnEnable(){
        Collectible.SubscribeToCollectedEvent(OnCollectibleCollected);
    }

    void OnDisable(){
        Collectible.UnsubscribeFromCollectedEvent(OnCollectibleCollected);
    }

    void OnCollectibleCollected(){
        count++;
        UpdateCount();
        if(count == Collectible.total ){
            won = true;
            SceneManager.LoadScene(2);
        }
    }

    void UpdateCount(){
        text.text = $"Collected {count} / {Collectible.total} pieces.";
    }
}
