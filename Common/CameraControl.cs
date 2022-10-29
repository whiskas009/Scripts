using Cinemachine;
using UnityEngine;

[RequireComponent(typeof(Cinemachine.CinemachineFreeLook))]
public class CameraControl : MonoBehaviour
{
    [SerializeField] private float _aimFOV;
    [SerializeField] private float _aimAxisSensitivity;
    [SerializeField] private float _idleAxisSensitivity;
    [SerializeField] private float _idleFOV;
    [SerializeField] private float _speedFovChange;

    private Cinemachine.CinemachineFreeLook _cinemachineCamera;

    private void Start()
    {
        _cinemachineCamera = GetComponent<Cinemachine.CinemachineFreeLook>();
    }

    public void SetCameraValue(bool isAim = false)
    {
        if (isAim)
        {
            _cinemachineCamera.m_Lens.FieldOfView = Mathf.Lerp(_cinemachineCamera.m_Lens.FieldOfView, _aimFOV, _speedFovChange * Time.deltaTime);
            _cinemachineCamera.m_XAxis.m_AccelTime = _aimAxisSensitivity;
            _cinemachineCamera.m_YAxis.m_AccelTime = _aimAxisSensitivity;
        }
        else
        {
            _cinemachineCamera.m_Lens.FieldOfView = Mathf.Lerp(_cinemachineCamera.m_Lens.FieldOfView, _idleFOV, _speedFovChange * Time.deltaTime);
            _cinemachineCamera.m_XAxis.m_AccelTime = _idleAxisSensitivity;
            _cinemachineCamera.m_YAxis.m_AccelTime = _idleAxisSensitivity;
        }
    }

    public void ChangeSensitivity(float value, bool isAim = false)
    {
        if (isAim)
            _aimAxisSensitivity = 1 - value;
        else
            _idleAxisSensitivity = 1 - value;
    }
}
