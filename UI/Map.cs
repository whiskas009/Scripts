using UnityEngine;
using UnityEngine.InputSystem;

public class Map : MonoBehaviour
{
    [SerializeField] private GameObject _mapPanel;

    private PlayerInputActions _inputActions;

    private void Start()
    {
        _inputActions = new PlayerInputActions();
        _inputActions.Enable();
        _inputActions.Player.Map.performed += OpenMap;
    }

    public void OpenMap(InputAction.CallbackContext context)
    {
        _mapPanel.SetActive(!_mapPanel.activeSelf);
    }
}
