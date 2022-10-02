using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookshelfController : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    
    public void Slide()
    {
        _animator.SetTrigger("Slide");
    }
}
