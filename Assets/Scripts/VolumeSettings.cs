using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] GameObject optionsOpt;

    [SerializeField]
    private AudioMixer myMixer;
    [SerializeField]
    private Slider sfxSlider;

    private void Start()
    {
        if(PlayerPrefs.HasKey("musicVolume"))
        {
            LoadVolume();
        }
        else
        {
            SetsfxVolume();
        }

        optionsOpt.SetActive(false);
    }



    public void SetsfxVolume()
    {
        float volume = sfxSlider.value;
        myMixer.SetFloat("SFX", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("sfxVolume", volume);
    }

    private void LoadVolume()
    {
        sfxSlider.value = PlayerPrefs.GetFloat("sfxVolume");

        SetsfxVolume();
    }


    public void alernarOpt()
    {
        if (optionsOpt.activeSelf) optionsOpt.SetActive(false);
        else optionsOpt.SetActive(true);
    }

}
