using UnityEngine;
using UnityEngine.UI;

public class MuteButton : MonoBehaviour{
    public Sprite unmutedSprite;
    public Sprite mutedSprite;
    public GameObject backgroundMusic;
    private Image buttonImage;
    private bool isMuted = false;

    private void Start(){
        buttonImage = GetComponent<Image>();
        UpdateButtonImage();
    }

    public void OnButtonClick(){
        isMuted = !isMuted;
        UpdateButtonImage();
        AudioSource audioSource = backgroundMusic.GetComponent<AudioSource>();
        audioSource.volume = isMuted ? 0f : 1f;
    }

    private void UpdateButtonImage(){
        buttonImage.sprite = isMuted ? mutedSprite : unmutedSprite;
    }
}
