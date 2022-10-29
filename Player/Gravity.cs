using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Gravity : MonoBehaviour
{
    [SerializeField] private float _gravityForce;

    private CharacterController _controller;
    private Vector3 _velocity;

    private void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        if (_controller.enabled == false)
            enabled = false;

        _velocity.y += _gravityForce * Time.deltaTime;
        _controller.Move(_velocity * Time.deltaTime);
    }
}
