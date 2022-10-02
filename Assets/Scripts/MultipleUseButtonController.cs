using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MultipleUseButtonController : MonoBehaviour
{
    [SerializeField] private UnityEvent _onButtonPressed;

    [SerializeField] private MultipleUseButtonAnimationController _animatorController;

    private bool _isAnimationStarted = false;
    
    private void Start()
    {
        _animatorController.onButtonPressed.AddListener(() =>
        {
            _onButtonPressed?.Invoke();
        });

        _animatorController.onButtonReleased.AddListener(() =>
        {
            _isAnimationStarted = false;
        });
    }

    public void Interact()
    {
        if (!_isAnimationStarted)
        {
            _isAnimationStarted = true;

            _animatorController.Press();
        }
    }
}
