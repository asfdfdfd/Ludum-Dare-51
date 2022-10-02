using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MultipleUseButtonAnimationController : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    public UnityEvent onButtonPressed;
    
    public UnityEvent onButtonReleased;
    
    public void Press()
    {
        _animator.SetTrigger("Press");
    }

    public void OnAnimationButtonPressed()
    {
        onButtonPressed?.Invoke();
    }

    public void OnAnimationFinished()
    {
        onButtonReleased?.Invoke();
    }
}
