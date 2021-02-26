using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using System;

public class SettingsPanel : UiPanel {
    [SerializeField] Slider masterVolumeSlider;
    [SerializeField] Slider musicVolumeSlider;
    [SerializeField] Slider effectsVolumeSlider;
    [SerializeField] AudioMixer mixer;

    private void Start()
    {
        masterVolumeSlider.onValueChanged.AddListener(delegate { MasterValueChangeCheck(); });
        musicVolumeSlider.onValueChanged.AddListener(delegate { MusicValueChangeCheck(); });
        effectsVolumeSlider.onValueChanged.AddListener(delegate { EffectsValueChangeCheck(); });
    }

    private void EffectsValueChangeCheck()
    {
        mixer.SetFloat("Effects", LineartoDecibel(effectsVolumeSlider.value));
    }

    private void MusicValueChangeCheck()
    {
        mixer.SetFloat("Music", LineartoDecibel(musicVolumeSlider.value));
    }

    private void MasterValueChangeCheck()
    {
        mixer.SetFloat("Master", LineartoDecibel(masterVolumeSlider.value));
    }
    private float LineartoDecibel(float value)
    {
        float dB;
        if (value != 0)
            dB = 20.0f * Mathf.Log10(value);
        else
            dB = -144.0f;

        return dB;
    }
    protected override void OnInitialise() { }

    protected override void OnOpen() { }

    protected override void OnClose() { }
}