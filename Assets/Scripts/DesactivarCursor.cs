using UnityEngine;

public class DesactivarCursor : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject gameOverScreen;
    public GameObject controles;
    public GameObject controlesMando;
    public GameObject controlesPC;
    public GameObject menuSalir;
    public GameObject menuReiniciar;

    private void Update()
    {
        if (pauseMenu.activeSelf || gameOverScreen.activeSelf || controles.activeSelf  || controlesPC.activeSelf || controlesMando.activeSelf || menuSalir.activeSelf || menuReiniciar.activeSelf)
        {
            Debug.Log("Activo");
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
