using UnityEngine;
using UnityEngine.UI;

public class CambiarSpriteButtonMenu : MonoBehaviour
{
    public Sprite normalSprite;
    public Sprite clickedSprite;
    public AudioSource audioSource;
    private float volumenOriginal;

    private Image buttonImage;

    private void Start()
    {
        buttonImage = GetComponent<Image>();
        buttonImage.sprite = normalSprite;
        audioSource = GetComponent<AudioSource>();
        volumenOriginal = audioSource.volume;
    }

    public void CambiarImagen()
    {
        if (buttonImage.sprite == normalSprite)
        {
            buttonImage.sprite = clickedSprite;
            audioSource.mute = true;
            //audioSource.volume = volumenOriginal;
        }
        else
        {
            buttonImage.sprite = normalSprite;
            audioSource.mute = false;
        }
    }
}
