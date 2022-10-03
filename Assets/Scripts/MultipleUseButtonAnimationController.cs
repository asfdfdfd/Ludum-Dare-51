using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MultipleUseButtonAnimationController : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    
    public void Press()
    {
        _animator.SetTrigger("Press");
    }
}
