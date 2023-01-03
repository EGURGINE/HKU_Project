using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public enum ESoundType
{
    BGM,
    JUMP
}


public class SoundManager : Singleton<SoundManager>
{
    [AssetList]
    [SerializeField] private AudioClip[] sounds;

    private void Start()
    {
        PlaySound(ESoundType.BGM);
    }

    public void PlaySound(ESoundType type)
    {
        GameObject go = new GameObject(type.ToString());
        AudioSource sound = go.AddComponent<AudioSource>();
        sound.clip = sounds[((int)type)];
        if (type == ESoundType.BGM) sound.loop = true;
        else
        {
            sound.loop = false;
            Destroy(go, sound.clip.length);
        }
        sound.Play();
    }

}
