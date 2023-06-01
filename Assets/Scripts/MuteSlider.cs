using UnityEngine;
using UnityEngine.UI;

public class MuteSlider : MonoBehaviour
{
    public GameObject backgroundMusic;
    private Slider volumeSlider;
    private bool isMuted = false;

    private void Start()
    {
        volumeSlider = GetComponent<Slider>();
        volumeSlider.value = 0.5f; // Set the initial value to 0.5
        volumeSlider.onValueChanged.AddListener(OnSliderValueChanged);
    }

    public void OnSliderValueChanged(float value)
    {
        isMuted = (value == 0f);
        AudioSource audioSource = backgroundMusic.GetComponent<AudioSource>();
        audioSource.volume = value;
    }
}
