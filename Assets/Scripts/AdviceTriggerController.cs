using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class AdviceTriggerController : MonoBehaviour
{
    private int _layerCharacter;

    [SerializeField] private string _adviceText;

    private TextMeshProUGUI _adviceTextMeshPro;
    
    private void Awake()
    {
        _layerCharacter = LayerMask.NameToLayer("Character");

        _adviceTextMeshPro = GameObject.FindWithTag("AdviceText").GetComponent<TextMeshProUGUI>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == _layerCharacter)
        {
            _adviceTextMeshPro.SetText(_adviceText);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        _adviceTextMeshPro.SetText("");
    }
}
