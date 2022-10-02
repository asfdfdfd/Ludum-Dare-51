using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleUseButtonAnimationController : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    public void Press()
    {
        _animator.SetTrigger("Press");
    }
}
