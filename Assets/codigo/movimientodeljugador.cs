using UnityEngine;

public class movimientodeljugador : MonoBehaviour
{
    public float velocidad = 50f; // Velocidad del jugador
    private Rigidbody2D rb;
    private Vector2 movimiento;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Buscar el Rigidbody2D del jugador
    }

    void Update()
    {
        // Teclas WASD o Flechas
        movimiento.x = Input.GetAxisRaw("Horizontal");
        movimiento.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        // Mover al jugador con físicas
        rb.MovePosition(rb.position + movimiento * velocidad * 4* Time.fixedDeltaTime);
    }
}
