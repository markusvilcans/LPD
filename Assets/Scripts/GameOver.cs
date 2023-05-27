using UnityEngine;
using TMPro;

public class GameOver : MonoBehaviour{
    public TMP_Text resultText;
    public FOV FOV;
    public AudioSource audioSource;
    public AudioClip win_sound;
    public AudioClip lose_sound;

    void Start(){
        resultText.enabled = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        if (FOV.caught){
            resultText.enabled = true;
            resultText.text = "YOU GOT CAUGHT! YOU LOSE!";
            resultText.color = new Color32(255, 89, 0, 255);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            PlaySound(lose_sound, audioSource);
        } else if (CollectibleCounter.won) {
            resultText.enabled = true;
            resultText.text = "YOU COLLECTED ALL THE PIECES!";
            resultText.color = new Color32(255, 173, 0, 255);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            PlaySound(win_sound, audioSource);
        } else {
            resultText.enabled = false;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    void PlaySound(AudioClip clip, AudioSource source){
        if (source != null && clip != null){
            source.Stop();
            source.clip = clip;
            source.Play();
        }
    }
}
