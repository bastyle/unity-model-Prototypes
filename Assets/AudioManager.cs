using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager _instance;
    public AudioClip[] audioclips;
    public string[] audioClipsNames;
    private Dictionary<string, AudioClip> audioClipDictionary= new Dictionary<string, AudioClip>();

    public static AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        int i = 0;
        foreach (var clip in audioclips)
        {
            audioClipDictionary[clip.name] = clip;
            audioClipsNames[i] = clip.name;
            i++;
        }
        _instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlayClip(string name)
    {
        audioSource.clip = _instance.audioClipDictionary[name];
        audioSource.loop = false;
        audioSource.Play();
    }
}
