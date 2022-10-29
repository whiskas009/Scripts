using Cinemachine;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class WeaponRecoil : MonoBehaviour
{
    [SerializeField] private float _cameraOffsetY;
    [SerializeField] private float _cameraOffsetXMax;
    [SerializeField] private float _cameraOffsetXMin;
    [SerializeField] private float _timeCameraOffset;
    [SerializeField] private float _weaponOffsetZ;

    private Rig _bodyRecoil;
    private OverrideTransform _weaponRecoil;
    private CinemachineImpulseSource _cameraImpuls;
    private CinemachineFreeLook _camera;
    private Camera _mainCanera;
    private float _currentTime;
    private float _cameraOffsetX = 0;

    private void Start()
    {
        _mainCanera = FindObjectOfType<MainCamera>().GetComponent<Camera>();
        _camera = FindObjectOfType<CameraControl>().GetComponent<CinemachineFreeLook>();
        _cameraImpuls = FindObjectOfType<CinemachineImpulseSource>();
        _weaponRecoil = FindObjectOfType<WeaponRecoilRigging>().GetComponent<OverrideTransform>();
        _bodyRecoil = FindObjectOfType<BodyRecoilRigging>().GetComponent<Rig>();
    }

    private void Update()
    {
        if (_currentTime > 0f)
        {
            _camera.m_YAxis.Value -= _cameraOffsetY * Time.deltaTime;
            _camera.m_XAxis.Value -= _cameraOffsetX * Time.deltaTime;
            SetRecoilWeight();
            _currentTime -= Time.deltaTime;
        }
        else
        {
            SetRecoilWeight(false);
        }  
    }

    public void GenerateRecoil()
    {
        _currentTime = _timeCameraOffset;
        _cameraOffsetX = Random.Range(_cameraOffsetXMin, _cameraOffsetXMax);
        _cameraImpuls.GenerateImpulse(_mainCanera.transform.forward);
    }

    private void SetRecoilWeight(bool isUpWeight = true)
    {
        float _targetWeight = 0.0f;

        if (isUpWeight)
            _targetWeight = 1.0f;
        
        _weaponRecoil.weight = Mathf.Lerp(_weaponRecoil.weight, _targetWeight, (1.0f / _timeCameraOffset) * Time.deltaTime);
        _bodyRecoil.weight = Mathf.Lerp(_weaponRecoil.weight, _targetWeight, (1.0f / _timeCameraOffset) * Time.deltaTime);
    }
}
