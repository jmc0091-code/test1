using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class MovimientoEnemigo : MonoBehaviour
{
    [Header("Movimiento")]
    public float speed = 2f;                // Velocidad de movimiento
    public float directionChangeTime = 2f;  // Cada cuánto cambia de dirección


    [Header("Limites")]
    public Transform ground;                //objeto a asignar

    public Vector3 moveDirection;          // Dirección actual de movimiento
    public float timer;                    // Temporizador para cambio de dirección
   

    private Vector3 minBounds;
    private Vector3 maxBounds;

    void Start()
    {
        if (ground == null)
        {
            Debug.LogError("🚨 No se ha asignado el suelo en EnemyRandomMovement3D.");
            enabled = false;
            return;
        }

        // Calcular límites del suelo usando su collider o escala
        CalculateGroundBounds();

        ChangeDirection();
    }

    void Update()
    {
        timer += Time.deltaTime;

        // Cambiar dirección aleatoriamente cada cierto tiempo
        if (timer >= directionChangeTime)
        {
            ChangeDirection();
            timer = 0f;
        }

        // Mover al enemigo
        transform.position += moveDirection * speed * Time.deltaTime;

        // Mantener dentro del suelo
        StayInsideGround();
    }

    void ChangeDirection()
    {
        // Dirección aleatoria en 2D (x, y)
        moveDirection = new Vector3 (Random.Range(-1f, 1f), 0 , Random.Range(-1f, 1f)).normalized;
    }

    void CalculateGroundBounds()
    {
        // Si el suelo tiene un collider, usa sus límites
        Collider groundCollider = ground.GetComponent<Collider>();
        if (groundCollider != null)
        {
            minBounds = groundCollider.bounds.min;
            maxBounds = groundCollider.bounds.max;
        }
        else
        {
            // Si no tiene collider, usa su posición y escala
            Vector3 center = ground.position;
            Vector3 halfScale = ground.localScale / 2f;
            minBounds = center - halfScale;
            maxBounds = center + halfScale;
        }
    }

    void StayInsideGround()
    {
        Vector3 pos = transform.position;

        // Limitar posición a los límites del suelo
        pos.x = Mathf.Clamp(pos.x, minBounds.x, maxBounds.x);
        pos.z = Mathf.Clamp(pos.z, minBounds.z, maxBounds.z);

        transform.position = pos;
    }
}

