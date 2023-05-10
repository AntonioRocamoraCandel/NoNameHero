using UnityEngine;

public class BackgroundMovement : MonoBehaviour
{
    public Transform target; // objeto que se seguirá (el personaje)
    public float smoothTime = 0.3f; // tiempo de suavizado del movimiento
    private Vector3 velocity = Vector3.zero;

    void LateUpdate()
    {
        Vector3 targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z);
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}
