using UnityEngine;

public class TargetSearchRadius : MonoBehaviour
{
    private bool _isTargetFound = false;

    public bool IsTargetFound => _isTargetFound;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.TryGetComponent(out Player player))
        {
            _isTargetFound = true;
        }  
    }
}
