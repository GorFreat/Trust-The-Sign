using System;
using Unity.VisualScripting;
using UnityEngine;

public enum SoundType
{
    FOOTSTEP,
    JUMP,
    LAND,
    DEATH,
    MOUSE_CLICK,
    EARTH_QUAKE
}
public enum BGMType
{
    BGM1
}
[RequireComponent(typeof(AudioSource)), ExecuteInEditMode]
public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource SFXSource;
    [SerializeField] private AudioSource BGMSource;
    [SerializeField] private SoundList[] soundList;
    [SerializeField] private SoundList[] bgmList;
    public static SoundManager instance;
    private void Awake()
    {
        if (Application.isPlaying)
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
    public static void PlaySound(SoundType sound, float volume = 1)
    {
        AudioClip[] clips = instance.soundList[(int)sound].Sounds;
        AudioClip randomClips = clips[UnityEngine.Random.Range(0, clips.Length)];
        instance.SFXSource.PlayOneShot(randomClips, volume);
    }
    public static void PlayBackgroundMusic(BGMType music, float volume = 1) 
    {
        AudioClip clip = instance.bgmList[(int)music].Sounds[0];
        instance.BGMSource.clip = clip;
        instance.BGMSource.loop = true;
        instance.BGMSource.volume = volume;
        instance.BGMSource.Play();
    }
    public static void StopSFX()
    {
        if (instance != null && instance.SFXSource != null)
        {
            instance.SFXSource.Stop();
        }
    }
#if UNITY_EDITOR
    private void OnEnable()
    {
        string[] names = Enum.GetNames(typeof(SoundType));
        Array.Resize(ref soundList, names.Length);
        for (int i = 0; i < soundList.Length; i++)
        {
            soundList[i].name = names[i];
        }
    }
#endif
}
[Serializable]
public struct SoundList
{
    public AudioClip[] Sounds { get => sounds; }
    [HideInInspector] public string name;
    [SerializeField] private AudioClip[] sounds;
}
