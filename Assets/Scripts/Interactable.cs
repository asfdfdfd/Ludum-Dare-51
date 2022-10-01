using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    [SerializeField] private UnityEvent<Interactable> _onInteraction;

    public void Interact()
    {
        _onInteraction?.Invoke(this);
    }
}
