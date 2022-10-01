using System;
using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;
using UnityEngine.Events;

public class InteractableSystem : MonoBehaviour
{
    public UnityEvent<Interactable> _onActiveInteractableChanged;
    
    private Camera _mainCamera;

    [SerializeField] private float maxRaycastDistance;

    private Interactable _activeInteractable;
    private GameObject _activeGameObject;
    
    public Interactable ActiveInteractable => _activeInteractable;

    private StarterAssetsInputs _input;
    
    private void Start()
    {
        _input = GameObject.FindWithTag("Player").GetComponent<StarterAssetsInputs>();
        
        _mainCamera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
    }

    private void Update()
    {
        var ray = _mainCamera.ScreenPointToRay(new Vector3(Screen.width / 2.0f, Screen.height / 2.0f, 0.0f));

        var layerMask = LayerMask.GetMask(new[] {"Interactable"});

        if (Physics.Raycast(ray, out var hitInfo, maxRaycastDistance, layerMask))
        {
            if (hitInfo.transform.gameObject != _activeGameObject)
            {
                _activeGameObject = hitInfo.transform.gameObject;
                _activeInteractable = _activeGameObject.GetComponent<Interactable>();
                
                _onActiveInteractableChanged?.Invoke(_activeInteractable);
            }
        }
        else
        {
            if (_activeGameObject != null)
            {
                _activeGameObject = null;
                _activeInteractable = null;
                
                _onActiveInteractableChanged?.Invoke(_activeInteractable);
            }
        }

        if (_input.interact)
        {
            if (_activeInteractable != null)
            {
                _activeInteractable.Interact();
            }
        }
    }
}
