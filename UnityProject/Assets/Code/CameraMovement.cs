using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float maxOffset = 920f;

    private float initialPositionX;

    void Start()
    {
        initialPositionX = transform.position.x;
    }

    void Update()
    {
        // Calculamos el movimiento basado en las teclas de dirección
        float move = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;

        // Nueva posición en X calculada
        float newPositionX = transform.position.x + move;

        // Limitamos el movimiento de la cámara a los bordes de la imagen de fondo
        newPositionX = Mathf.Clamp(newPositionX, initialPositionX - maxOffset, initialPositionX + maxOffset);

        // Aplicamos la nueva posición a la cámara
        transform.position = new Vector3(newPositionX, transform.position.y, transform.position.z);
    }
}
