using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MultipleUseButtonController : MonoBehaviour
{
    [SerializeField] private UnityEvent _onButtonPressed;
    
    private SoundPlayerController _soundPlayerController;
    
    private void Start()
    {
        _soundPlayerController = GameObject.FindWithTag("SoundPlayer").GetComponent<SoundPlayerController>();
    }
    
    public void Interact()
    {
        _soundPlayerController.PlayAssButton();
        
        _onButtonPressed?.Invoke();
    }
}
