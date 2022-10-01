using UnityEngine;
using UnityEngine.Events;

public class TeleportController : MonoBehaviour
{
    public UnityEvent<TeleportController> _onPlayerEnteredTeleport;
    
    private int _layerCharacter;

    private void Awake()
    {
        _layerCharacter = LayerMask.NameToLayer("Character");
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == _layerCharacter)
        {
            _onPlayerEnteredTeleport?.Invoke(this);
        }
    }
}
