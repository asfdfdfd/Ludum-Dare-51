using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class BookshelfController : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    [SerializeField] private GameObject _body;

    private SoundPlayerController _soundPlayerController;
    
    private void Start()
    {
        _soundPlayerController = GameObject.FindWithTag("SoundPlayer").GetComponent<SoundPlayerController>();
    }

    public void Slide()
    {
        _animator.SetTrigger("Slide");

        _soundPlayerController.PlayBookshelfSlide();
    }
}
