using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Volume : MonoBehaviour
{

    [SerializeField] string volume = "MasterVolume";
    [SerializeField] AudioMixer mixer;
    [SerializeField] Slider slider;
    [SerializeField] Toggle toggle;
    [SerializeField] float multiplier = 30f;

    private bool disable_toggle = false;

    private void Awake()
    {

        slider.onValueChanged.AddListener(handle_slider);
        toggle.onValueChanged.AddListener(handle_toggle);

    }
    private void OnDisable()
    {

        PlayerPrefs.SetFloat(volume, slider.value);

    }

    private void handle_slider(float value)
    {

        mixer.SetFloat(volume, Mathf.Log10(value) * multiplier);
        disable_toggle = true;
        toggle.isOn = slider.value > 0.0001f;
        disable_toggle = false;

    }

    private void handle_toggle(bool enabled)
    {

        if(disable_toggle)
        {
            return;
        }

        slider.value = 1f;

        if (enabled)
        {
            slider.value = 0.0001f;
        }
        else
        {
            slider.value = 1f;
        }

    }

    void Start()
    {
        
        slider.value = PlayerPrefs.GetFloat(volume, slider.value);

    }



}
