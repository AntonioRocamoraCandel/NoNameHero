using UnityEngine;

public class DesactivarCursor : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject gameOverScreen;
    public GameObject menuControles;

    private void Update()
    {
        if (pauseMenu.activeSelf || gameOverScreen.activeSelf || menuControles.activeSelf)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
