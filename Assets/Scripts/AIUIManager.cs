using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AIUIManager : MonoBehaviour{
    public List<FOV> aiAgents = new List<FOV>();
    public string eyeGreenObjectName = "eye_green";
    public string eyeOrangeObjectName = "eye_orange";
    public string eyeRedObjectName = "eye_red";

    private Image detectionImage;
    private Sprite eyeGreenSprite;
    private Sprite eyeOrangeSprite;
    private Sprite eyeRedSprite;

    void Start(){
        FOV[] aiArray = FindObjectsOfType<FOV>();
        aiAgents.AddRange(aiArray);

        detectionImage = GameObject.Find("detectionImage")?.GetComponent<Image>();
        GameObject eyeGreenObject = GameObject.Find(eyeGreenObjectName);
        if (eyeGreenObject != null)
            eyeGreenSprite = eyeGreenObject.GetComponent<SpriteRenderer>().sprite;
        GameObject eyeOrangeObject = GameObject.Find(eyeOrangeObjectName);
        if (eyeOrangeObject != null)
            eyeOrangeSprite = eyeOrangeObject.GetComponent<SpriteRenderer>().sprite;
        GameObject eyeRedObject = GameObject.Find(eyeRedObjectName);
        if (eyeRedObject != null)
            eyeRedSprite = eyeRedObject.GetComponent<SpriteRenderer>().sprite;
    }

    public void UpdateUIOnDetection(){
        bool playerDetected = false;
        bool timerExpired = false;
        foreach (FOV agent in aiAgents){
            if (agent.canSeePlayer){
                playerDetected = true;
                if (agent.timer >= 2f){
                    timerExpired = true;
                    break;
                }
            }
        }

        if (detectionImage != null){
            if (timerExpired)
                detectionImage.sprite = eyeRedSprite;
            else if (playerDetected)
                detectionImage.sprite = eyeOrangeSprite;
            else
                detectionImage.sprite = eyeGreenSprite;
        }
    }
}