using System.Collections;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    [SerializeField] private GameObject _hud;
    [SerializeField] private GameObject _menu;
    [SerializeField] private GameObject _startGameButton;
    [SerializeField] private GameObject _resumeGameButton;
    [SerializeField] private GameControl _gameControl;
    [SerializeField] private PauseGame _pauseGame;
    [SerializeField] private Animator _cameraAnimator;
    [SerializeField] private Animator _playerAnimator;
    [SerializeField] private Animator _weaponAnimator;
    [SerializeField] private AnimatorHash _animatorHash;
    [SerializeField] private float _startGameDelay;

    private WaitForSecondsRealtime _waitTime;
    
    private void Start()
    {
        _waitTime = new WaitForSecondsRealtime(_startGameDelay);
        _gameControl.SetActiveGameControl(false, true, false);
    }

    public void OnStartGame()
    {
        StartCoroutine(OnPlayStartAnimation());
    }

    private void SetActivateObjects()
    {
        _pauseGame.enabled = true;
        _gameControl.SetActiveGameControl(true, true, false);
        _hud.SetActive(true);
        _menu.SetActive(false);
        _startGameButton.SetActive(false);
    }

    private IEnumerator OnPlayStartAnimation()
    {
        _cameraAnimator.SetBool(_animatorHash.IDIsStartAnimation, true);
        _playerAnimator.SetBool(_animatorHash.IDIsStand, true);
        _weaponAnimator.SetBool(_animatorHash.IDIsWeaponStand, true);
        yield return _waitTime;
        SetActivateObjects();
        StopCoroutine(OnPlayStartAnimation());
    }
}
