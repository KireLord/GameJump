using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlayer : MonoBehaviour
{
    public float normalSpeed = 5f; // Velocidad normal
    public float boostedSpeed = 10f; // Velocidad aumentada al presionar Shift
    public float acceleration = 5f; // Aceleración
    public float deceleration = 5f; // Deceleración
    private float currentSpeed; // Velocidad actual

    private Vector3 velocity; // Velocidad del personaje

    // Start is called before the first frame update
    void Start()
    {
        currentSpeed = normalSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        // Verificar si se está presionando la tecla Shift para aumentar la velocidad
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            currentSpeed = Mathf.MoveTowards(currentSpeed, boostedSpeed, acceleration * Time.deltaTime);
        }
        else
        {
            currentSpeed = Mathf.MoveTowards(currentSpeed, normalSpeed, deceleration * Time.deltaTime);
        }

        // Calcular la velocidad del personaje
        velocity = new Vector3(currentSpeed * horizontalInput, currentSpeed * verticalInput, 0f);

        // Aplicar la velocidad al personaje
        transform.position += velocity * Time.deltaTime;

        // Rotar el objeto para que mire en la dirección del movimiento
        if (velocity != Vector3.zero)
        {
            float angle = Mathf.Atan2(-velocity.x, velocity.y) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }
}


