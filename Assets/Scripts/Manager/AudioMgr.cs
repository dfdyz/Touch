using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static Unity.VisualScripting.Member;

public class AudioMgr : MonoBehaviour
{
    public static AudioMgr Instance;
    //[SerializeField]
    private AudioSource BgmSource;

    //[SerializeField]
    private AudioSource HitSoundSource;

    public AudioClip Bgm_Idle;
    public AudioClip Bgm_Battle;
    public AudioClip Sound_Hit;
    public AudioClip Sound_Win;
    public AudioClip Sound_Strike;
    public AudioClip Sound_miss;
    public AudioClip Sound_reborn;


    // Start is called before the first frame update
    void Awake()
    {
        BgmSource = this.AddComponent<AudioSource>();
        HitSoundSource = this.AddComponent<AudioSource>();

        BgmSource.loop = true;
        HitSoundSource.loop = false;

        Instance = this;

    }


    public enum SoundType{
        Bgm, Hit
    }
    public void PlaySound(SoundType t, AudioClip audio)
    {
        AudioSource source;
        if(t == SoundType.Bgm)
        {
            source = BgmSource;
        }
        else if(t == SoundType.Hit)
        {
            source = HitSoundSource;
        }
        else
        {
            return;
        }

        source.Stop();
        source.clip = audio;
        source.Play();
    }

    public void StopSound(SoundType t)
    {
        AudioSource source;
        if (t == SoundType.Bgm)
        {
            source = BgmSource;
        }
        else if (t == SoundType.Hit)
        {
            source = HitSoundSource;
        }
        else
        {
            return;
        }

        source.Stop();
    }




}
