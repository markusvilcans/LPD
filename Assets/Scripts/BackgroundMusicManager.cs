using UnityEngine;

public class BackgroundMusicManager : MonoBehaviour{
    public AudioClip[] backgroundMusicSongs;

    private AudioSource audioSource;
    private int currentIndex = 0;

    void Start(){
        audioSource = GetComponent<AudioSource>();
        backgroundMusicSongs = new AudioClip[5];
        for (int i = 0; i < 5; i++){
            backgroundMusicSongs[i] = Resources.Load<AudioClip>("music" + (i + 1));
        }
        currentIndex = Random.Range(0, backgroundMusicSongs.Length);
        PlaySong(currentIndex);
    }

    void PlaySong(int songIndex){
        audioSource.clip = backgroundMusicSongs[songIndex];
        audioSource.loop = false;
        audioSource.Play();
    }

    void Update(){
        if (!audioSource.isPlaying){
            currentIndex++;
            if (currentIndex >= backgroundMusicSongs.Length){
                currentIndex = 0;
            }
            PlaySong(currentIndex);
        }
    }
}
