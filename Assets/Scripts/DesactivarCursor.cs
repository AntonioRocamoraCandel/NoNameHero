using UnityEngine;
using UnityEngine.InputSystem;

public class DesactivarCursor : MonoBehaviour
{
    private bool cursorActivo = false;

    void Start()
    {
        // Oculta y bloquea el cursor al inicio de la escena
        DesactivarCursorInternal();
    }

    void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            // Activa o desactiva el cursor cuando se presiona la tecla Escape
            cursorActivo = !cursorActivo;

            if (cursorActivo)
                ActivarCursor();
            else
                DesactivarCursorInternal();
        }
    }

    private void ActivarCursor()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    private void DesactivarCursorInternal()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void OnDestroy()
    {
        // Vuelve a mostrar el cursor y desbloquearlo cuando se destruye el objeto
        ActivarCursor();
    }
}
