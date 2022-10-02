using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    [SerializeField] private UnityEvent<Interactable> _onInteraction;

    [SerializeField] private bool _isSingleInteraction;

    private bool isInteracted;
    
    public void Interact()
    {
        if (IsInteractionEnabled())
        {
            isInteracted = true;
            
            _onInteraction?.Invoke(this);
        }
    }

    public bool IsInteractionEnabled()
    {
        if (_isSingleInteraction && isInteracted)
        {
            return false;
        }
        
        return true;
    }
}
