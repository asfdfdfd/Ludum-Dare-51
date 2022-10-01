using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathSystem : MonoBehaviour
{
    [SerializeField] private TeleportationSystem _teleportationSystem;

    private void Start()
    {
        var deathTriggers = FindObjectsOfType<DeathTriggerController>();

        foreach (var deathTrigger in deathTriggers)
        {
            deathTrigger._onPlayerEnteredDeathTrigger.AddListener((deathTrigger) =>
            {
                _teleportationSystem.ResetTimer();
                _teleportationSystem.MovePlayerToActiveTeleport();
            });
        }
    }
}
