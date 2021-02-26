using System;
using UnityEngine;
using UnityEngine.Audio;
using Random = UnityEngine.Random;

public class PlayerAudioController : PlayerSubsystem
{ 
    [SerializeField] AudioSource playerJumpAudioSource;
    [SerializeField] AudioSource playerWalkAudioSource;
    [SerializeField] AudioSource playerAttackAudioSource;
    [SerializeField] AudioClip[] footstepSounds;
    [SerializeField] AudioClip jumpSound;
    [SerializeField] AudioClip landingSound;
    [SerializeField] AudioClip attackSound;


    public override void HandleEvent(PlayerEventType eventType)
    {
        switch (eventType)
        {
            case PlayerEventType.Jump:
                PlayJumpSound();
                break;
            case PlayerEventType.Landing:
                PlayLandingSound();
                break;
            case PlayerEventType.Death:
                break;
            case PlayerEventType.Attack:
                PlayAttackSound();
                break;
            case PlayerEventType.Footstep:
                PlayFootstepsSound();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(eventType), eventType, null);
        }
    }

    private void PlayJumpSound()
    {
        playerJumpAudioSource.PlayOneShot(jumpSound);
    }

    private void PlayFootstepsSound()
    {
        playerWalkAudioSource.PlayOneShot(footstepSounds[(Random.Range(0, footstepSounds.Length))]);
    }

    private void PlayLandingSound()
    {
        playerWalkAudioSource.PlayOneShot(landingSound);
    }
    private void PlayAttackSound()
    {
        playerAttackAudioSource.PlayOneShot(attackSound);
    }

}