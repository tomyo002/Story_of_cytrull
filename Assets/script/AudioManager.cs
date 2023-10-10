using UnityEngine.Audio;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
     public AudioClip[] playlist;
     public AudioSource audioSource;
     private int MusicIndex =0;
     public AudioMixerGroup soundEffectMixer;
    public static AudioManager instance;
  
  private void Awake()
  {
    if(instance != null)
    {
        Debug.LogWarning("Il y a plus d'une instance de AudioManager dans la scene");
        return;
    }
    instance =this;
  }
    // Start is called before the first frame update
    void Start()
    {
        audioSource.clip = playlist[0];
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if(!audioSource.isPlaying)
        {
            PlayNextSong();
        }
    }
    void PlayNextSong()
    {
        MusicIndex = (MusicIndex +1) % playlist.Length;
        audioSource.clip = playlist[MusicIndex];
        audioSource.Play();
    }
    public AudioSource playClipAt(AudioClip clip,Vector3 pos)
    {
        GameObject tempGO = new GameObject("TempAudio");
        tempGO.transform.position = pos;
        AudioSource audioSource = tempGO.AddComponent<AudioSource>();
        audioSource.clip = clip;
        audioSource.outputAudioMixerGroup = soundEffectMixer;
        audioSource.Play();
        Destroy(tempGO, clip.length);
        return audioSource;
    }
}
