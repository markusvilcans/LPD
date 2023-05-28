using UnityEngine;
using UnityEngine.UI;

public class CaughtImage : MonoBehaviour{
    public Image detectionImage;
    public Sprite eye_green;
    public Sprite eye_orange;
    public Sprite eye_red;
    
    private void Start(){
        detectionImage.sprite = eye_green;
    }

    public void SetDetectionState(DetectionState state){
        switch (state){
            case DetectionState.NotSeen:
                detectionImage.sprite = eye_green;
                break;
            case DetectionState.Seen:
                detectionImage.sprite = eye_orange;
                break;
            case DetectionState.Caught:
                detectionImage.sprite = eye_red;
                break;
        }
    }
}

public enum DetectionState{
    NotSeen,
    Seen,
    Caught
}
