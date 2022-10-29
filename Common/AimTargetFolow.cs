using UnityEngine;

public class AimTargetFolow : MonoBehaviour
{
    [SerializeField] private Camera _mainCamera;
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private float _speedChange;

    private float _halfSreen = 2.0f;
    private float _rayDistance = 999f;
    
    private void Update()
    {
        Vector2 screenCenterPoint = new Vector2(Screen.width / _halfSreen, Screen.height / _halfSreen);
        Ray ray = _mainCamera.ScreenPointToRay(screenCenterPoint);

        if (Physics.Raycast(ray, out RaycastHit hit, _rayDistance, _layerMask))
            transform.position = Vector3.Slerp(transform.position, hit.point, _speedChange * Time.deltaTime);
    }
}
