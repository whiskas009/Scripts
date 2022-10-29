using Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameControl : MonoBehaviour
{
    [SerializeField] private CinemachineBrain _cinemachineBrain;
    [SerializeField] private PlayerInput _playerInput;

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
            if (Time.timeScale == 1)
                Time.timeScale = 0;
            else
                Time.timeScale = 1;
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
