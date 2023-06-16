using UnityEngine;
using UnityEngine.UI;

public class CambiarSpriteButtonMenu : MonoBehaviour
{
    public Sprite normalSprite;
    public Sprite clickedSprite;

    private Image buttonImage;

    private void Start()
    {
        buttonImage = GetComponent<Image>();
        buttonImage.sprite = normalSprite;
    }

    public void CambiarImagen()
    {
        if (buttonImage.sprite == normalSprite)
        {
            buttonImage.sprite = clickedSprite;
        }
        else
        {
            buttonImage.sprite = normalSprite;
        }
    }

}