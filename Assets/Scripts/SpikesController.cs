using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikesController : MonoBehaviour
{
    [SerializeField] private GameObject _deathTriggerGameObject;

    [SerializeField] private bool _isUp = true;

    [SerializeField] private Animator _spikesAnimator;
    
    private void Start()
    {
        _deathTriggerGameObject.SetActive(_isUp);
        
        if (_isUp)
        {
            _spikesAnimator.SetInteger("IsUp", 2); // Without animation.
        }
        else
        {
            _spikesAnimator.SetInteger("IsUp", -1); // Without animation.
        }
    }

    public void MoveUp()
    {
        _isUp = true;
        _spikesAnimator.SetInteger("IsUp", 1); // With animation.
        _deathTriggerGameObject.SetActive(_isUp);
    }

    public void MoveDown()
    {
        _isUp = false;
        _spikesAnimator.SetInteger("IsUp", 0); // With animation.
        _deathTriggerGameObject.SetActive(_isUp);
    }
}
