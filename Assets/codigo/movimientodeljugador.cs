using UnityEngine;

public class movimientodeljugador : MonoBehaviour
{
    public float velocidad = 50f;
    private Rigidbody2D rb;
    private Vector2 movimiento;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        movimiento.x = Input.GetAxisRaw("Horizontal");
        movimiento.y = Input.GetAxisRaw("Vertical");

        // ¿Se está moviendo?
        bool estaCaminando = movimiento != Vector2.zero;

        // Actualizar animator (Caminar = true cuando se mueve)
        animator.SetBool("Caminar", estaCaminando);

        // Voltear sprite SOLO si hay movimiento horizontal (para conservar la última dirección en Idle)
        if (movimiento.x > 0.01f)
        {
            spriteRenderer.flipX = false;
        }
        else if (movimiento.x < -0.01f)
        {
            spriteRenderer.flipX = true;
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movimiento * velocidad * Time.fixedDeltaTime);
    }
}
