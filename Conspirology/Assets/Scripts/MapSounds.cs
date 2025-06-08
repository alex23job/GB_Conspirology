using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSounds : MonoBehaviour
{
    [SerializeField] private AudioSource effects;
    [SerializeField] private AudioClip clickItem;
    [SerializeField] private AudioClip clickButton;

    public void PlayClickItem()
    {
        effects.clip = clickItem;
        effects.Play();
    }

    public void PlayClickButton()
    {
        effects.clip = clickButton;
        effects.Play();
    }
}
