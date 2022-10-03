using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using DG.Tweening;
using UnityEngine;

public class TeleportationSystem : MonoBehaviour
{
    private const float TEN_SECONDS_TIME = 10.0f;

    private float _tenSecondsTimer = TEN_SECONDS_TIME;

    private TeleportController[] _teleports;

    private TeleportController _activeTeleport;

    private GameObject _playerCapsule;
    private CharacterController _characterController;

    private bool _isTimerStopped = false;

    private SoundPlayerController _soundPlayerController;

    private Camera _camera;
    
    private void Start()
    {
        _camera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
        
        _soundPlayerController = GameObject.FindWithTag("SoundPlayer").GetComponent<SoundPlayerController>();
        
        _playerCapsule = GameObject.FindWithTag("Player");
        _characterController = _playerCapsule.GetComponent<CharacterController>();
        
        _teleports = FindObjectsOfType<TeleportController>();

        foreach (var teleport in _teleports)
        {
            teleport._onPlayerEnteredTeleport.AddListener((teleportController) =>
            {
                _activeTeleport = teleportController;
            });
        }
    }

    private void Update()
    {
        if (!_isTimerStopped)
        {
            _tenSecondsTimer -= Time.deltaTime;

            if (_tenSecondsTimer <= 0)
            {
                MovePlayerToActiveTeleport();
            }
        }
    }

    public void ResetTimer()
    {
        _tenSecondsTimer = TEN_SECONDS_TIME;
    }

    public void StartTimer()
    {
        _isTimerStopped = false;
    }
    
    public void StopTimer()
    {
        _isTimerStopped = true;
    }

    public void MovePlayerToActiveTeleport()
    {
        if (_activeTeleport != null)
        {
            _characterController.enabled = false;
            _playerCapsule.transform.position = _activeTeleport.transform.position;
            _playerCapsule.transform.rotation = _activeTeleport.transform.rotation;
            _characterController.enabled = true;
        
            _soundPlayerController.PlayBackgroundMusic();
            _soundPlayerController.PlayTeleportIn();
        
            ResetTimer();
        }
    }
}
