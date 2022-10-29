using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    [SerializeField] private float _rotationSmoothTime;

    private float _rotationSmoothVelocity;

    public void Rotate(float targetAngle)
    {
        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y,
                targetAngle, ref _rotationSmoothVelocity, _rotationSmoothTime);

        transform.rotation = Quaternion.Euler(0.0f, angle, 0.0f);
    } 
}
