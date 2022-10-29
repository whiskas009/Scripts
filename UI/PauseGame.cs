using UnityEngine;
using UnityEngine.InputSystem;

public class PauseGame : MonoBehaviour
{
    [SerializeField] private GameObject _menu;
    [SerializeField] private GameObject _startGameButton;
    [SerializeField] private GameObject _resumeGameButton;
    [SerializeField] private GameControl _gameControl;
    [SerializeField] private GameObject _hud;

    private PlayerInputActions _playerInput;

    private void Start()
    {
        _playerInput = new PlayerInputActions();
        _playerInput.Enable();
        _playerInput.Player.Menu.performed += OnOpenMenu;
    }

    private void OnOpenMenu(InputAction.CallbackContext callback)
    {
        ChangeActivityObjects();
    }

    public void ChangeActivityObjects()
    {
        _hud.SetActive(!_hud.activeSelf);
        _menu.SetActive(!_menu.activeSelf);
        _resumeGameButton.SetActive(!_resumeGameButton.activeSelf);
        _gameControl.SetActiveGameControl(true, false);
    }
}
