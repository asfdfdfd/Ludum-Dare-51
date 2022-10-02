using TMPro;
using UnityEngine;

public class PressEToActivateController : MonoBehaviour
{
    private InteractableSystem _interactableSystem;

    [SerializeField] private TextMeshProUGUI _text;
    
    private void Start()
    {
        _text.enabled = false;
        
        _interactableSystem = GameObject.FindWithTag("SystemComponents").GetComponent<InteractableSystem>();
        
        _interactableSystem._onActiveInteractableChanged.AddListener((interactable) =>
        {
            if (interactable != null && interactable.IsInteractionEnabled())
            {
                _text.enabled = true;
            }
            else
            {
                _text.enabled = false;
            }
        });
    }
}
