using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DeathTriggerController : MonoBehaviour
{
    public UnityEvent<DeathTriggerController> _onPlayerEnteredDeathTrigger;

    private int _layerCharacter;

    private void Awake()
    {
        _layerCharacter = LayerMask.NameToLayer("Character");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == _layerCharacter)
        {
            _onPlayerEnteredDeathTrigger?.Invoke(this);
        }
    }
}
