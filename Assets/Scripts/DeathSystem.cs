using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathSystem : MonoBehaviour
{
    [SerializeField] private TeleportationSystem _teleportationSystem;

    private SoundPlayerController _soundPlayerController;

    private void Start()
    {
        _soundPlayerController = GameObject.FindWithTag("SoundPlayer").GetComponent<SoundPlayerController>();

        var deathTriggers = FindObjectsOfType<DeathTriggerController>();

        foreach (var deathTrigger in deathTriggers)
        {
            deathTrigger._onPlayerEnteredDeathTrigger.AddListener((deathTrigger) =>
            {
                _soundPlayerController.PlayRandomDeathSound();
                
                _teleportationSystem.MovePlayerToActiveTeleport();
            });
        }
    }
}
