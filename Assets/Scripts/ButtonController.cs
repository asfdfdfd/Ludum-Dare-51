using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonController : MonoBehaviour
{
    [SerializeField] private UnityEvent _onButtonPressed;
    
    public void Interact()
    {
        _onButtonPressed?.Invoke();
    }
}
