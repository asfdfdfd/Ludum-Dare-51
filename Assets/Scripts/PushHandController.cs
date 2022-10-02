using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PushHandController : MonoBehaviour
{
    [SerializeField] private bool _isTimerBased;

    [SerializeField] private float _time;

    [SerializeField] private Animator _animator;
    
    private float _timer;

    private void Start()
    {
        _timer = _time;
    }

    private void Update()
    {
        _timer -= Time.deltaTime;

        if (_timer <= 0)
        {
            _animator.SetTrigger("Attack");
            _timer += _time;
        }
    }
}
