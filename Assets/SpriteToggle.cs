using UnityEngine;
using UnityEngine.UI;

public class SpriteToggle : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private Sprite OnSprite;
    [SerializeField] private Sprite OffSprite;
    
    public void SetSprite(bool state)
    {
        _image.sprite = state ? OnSprite : OffSprite;
    }
}
