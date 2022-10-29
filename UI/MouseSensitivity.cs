using UnityEngine;
using UnityEngine.UI;

public class MouseSensitivity : MonoBehaviour
{
    [SerializeField] private Slider _idleSensitivitySlider;
    [SerializeField] private Slider _aimSensitivitySlider;
    [SerializeField] private CameraControl _cameraControl;

    public void OnSetAimValue()
    {
        _cameraControl.ChangeSensitivity(_aimSensitivitySlider.value, true);
    }

    public void OnSetIdleValue()
    {
        _cameraControl.ChangeSensitivity(_idleSensitivitySlider.value);
    }
}
