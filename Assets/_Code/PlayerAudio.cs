using System;
using UnityEngine;
using UnityEngine.Audio;


public class PlayerAudio : MonoBehaviour
{
    public AudioMixerSnapshot forestDay;
    public AudioMixerSnapshot forestSunset;
    public AudioMixerSnapshot forestNight;
    public AudioMixerSnapshot fieldDay;
    public AudioMixerSnapshot fieldSunset;
    public AudioMixerSnapshot fieldNight;
    private TimeOfDay _currentTime;
    private AudioMixerSnapshot[] _availableSnapshots;
    public int transitionTime;

    private void Start()
    {
        _currentTime = TimeOfDay.Day;
        _availableSnapshots = new AudioMixerSnapshot[2];
        _availableSnapshots[0] = forestDay;
        _availableSnapshots[1] = fieldDay;
    }

    // Update is called once per frame
    void Update()
    {
        switch (_currentTime)
        {
            case TimeOfDay.Day:
                _availableSnapshots[0] = forestDay;
                _availableSnapshots[1] = fieldDay;
                break;
            case TimeOfDay.Sunset:
                _availableSnapshots[0] = forestSunset;
                _availableSnapshots[1] = fieldSunset;
                break;
            case TimeOfDay.Night:
                _availableSnapshots[0] = forestNight;
                _availableSnapshots[1] = fieldNight;
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        _availableSnapshots[0].TransitionTo(transitionTime);

    }
    private void OnTriggerExit2D(Collider2D other)
    {
        _availableSnapshots[1].TransitionTo(transitionTime);
    }
}
