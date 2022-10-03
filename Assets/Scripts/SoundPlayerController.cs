using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = Unity.Mathematics.Random;

public class SoundPlayerController : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSourceSteps;

    [SerializeField] private AudioSource _audioSourceBackgroundMusic;

    [SerializeField] private AudioSource _audioSourceBookshelf;
    
    [SerializeField] private AudioSource _audioSourceAssButton;

    [SerializeField] private AudioSource _audioSourceTeleportIn;
    
    [SerializeField] private AudioSource _audioSourceTeleportOut;

    [SerializeField] private AudioSource _audioSourceWitch;
    
    [SerializeField] private AudioSource _audioSourceDeath;

    [SerializeField] private List<AudioClip> _witchSounds;
    
    [SerializeField] private List<AudioClip> _deathSounds;

    private Random rnd;

    private float _witchTimer = 3.0f;

    private void Start()
    {
        rnd = new Random((uint) (Time.time * 1000.0f + 100.0f));
    }

    public void ShowStepsSound(bool shouldShow)
    {
        if (shouldShow && !_audioSourceSteps.isPlaying)
        {
            _audioSourceSteps.Play();
        }
        else if (!shouldShow && _audioSourceSteps.isPlaying)
        {
            _audioSourceSteps.Pause();
        }
    }

    public void PlayBackgroundMusic()
    {
        _audioSourceBackgroundMusic.Stop();
        _audioSourceBackgroundMusic.Play();
    }

    public void PlayBookshelfSlide()
    {
        _audioSourceBookshelf.Play();
    }

    public void PlayAssButton()
    {
        _audioSourceAssButton.Play();
    }

    public void PlayTeleportIn()
    {
        _audioSourceTeleportIn.Play();
    }
    
    public void PLayTeleportOut()
    {
        _audioSourceTeleportOut.Play();
    }

    public void PlayRandomWitchSound()
    {
        var randomSound = rnd.NextInt(_witchSounds.Count() - 1);

        if (!_audioSourceWitch.isPlaying)
        {
            _audioSourceWitch.clip = _witchSounds.ElementAt(randomSound);
            _audioSourceWitch.Play();
        }
    }

    public void PlayRandomDeathSound()
    {
        var randomSound = rnd.NextInt(_deathSounds.Count() - 1);

        if (!_audioSourceDeath.isPlaying)
        {
            _audioSourceDeath.clip = _deathSounds.ElementAt(randomSound);
            _audioSourceDeath.Play();
        }
    }

    private void Update()
    {
        _witchTimer -= Time.deltaTime;

        if (_witchTimer <= 0.0f)
        {
            _witchTimer = rnd.NextFloat(10.0f, 20.0f);
            
            PlayRandomWitchSound();
        }
    }
}
