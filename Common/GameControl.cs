using Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameControl : MonoBehaviour
{
    [SerializeField] private CinemachineBrain _cinemachineBrain;
    [SerializeField] private PlayerInput _playerInput;

    private float _maxTimeScale = 1.0f;
    private float _minTimeScale = 0.0f;

    public void SetActiveGameControl(bool isChangeStateCursor = true, bool isChangePlayerControl = true, bool isChangeGameTime = true)
    {
        SetActivePlayerControl(isChangePlayerControl);
        SetActiveCursor(isChangeStateCursor);
        SetGameTime(isChangeGameTime);
    }

    private void SetGameTime(bool isChangeGameTime = true)
    {
        if (isChangeGameTime)
        {
            if (Time.timeScale == _maxTimeScale)
                Time.timeScale = _minTimeScale;
            else
                Time.timeScale = _maxTimeScale;
        }
    }

    private void SetActivePlayerControl(bool isChangePlayerControl = true)
    {
        if (isChangePlayerControl)
        {
            _playerInput.enabled = !_playerInput.enabled;
            _cinemachineBrain.enabled = !_cinemachineBrain.enabled;
        }  
    }

    private void SetActiveCursor(bool isChangeStateCursor = true)
    {
        if (isChangeStateCursor)
        {
            Cursor.visible = !Cursor.visible;

            if (Cursor.lockState == CursorLockMode.Locked)
                Cursor.lockState = CursorLockMode.None;
            else
                Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
