using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    [SerializeField] private float _rotationSmoothTime;

    private float _rotationSmoothVelocity;
    private float _lockAngleValue = 0.0f;

    public void Rotate(float targetAngle)
    {
        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y,
                targetAngle, ref _rotationSmoothVelocity, _rotationSmoothTime);

        transform.rotation = Quaternion.Euler(_lockAngleValue, angle, _lockAngleValue);
    } 
}
