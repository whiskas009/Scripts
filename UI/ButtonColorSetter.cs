using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class ButtonColorSetter : MonoBehaviour
{
    [SerializeField] private Color _endColor;

    private Image _buttonImage;
    private Color _startColor;

    private void Start()
    {
        _buttonImage = GetComponent<Image>();
        _startColor = _buttonImage.color;
    }

    public void OnSetColor()
    {
        _buttonImage.color = _endColor;
    }

    public void OnReturnColor()
    {
        _buttonImage.color = _startColor;
    }
}
