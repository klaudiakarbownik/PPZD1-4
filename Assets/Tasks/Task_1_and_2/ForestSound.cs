using UnityEngine;
using UnityEngine.Audio;


public class ForestSound : MonoBehaviour
{
    public AudioMixer environmentAudioMixer;

    private void LowPassValue(float amount)
    {
        environmentAudioMixer.SetFloat("lowpass", amount);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        LowPassValue(800);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        LowPassValue(22000);
    }
}
