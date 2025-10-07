using UnityEngine;

public class detectarcolision : MonoBehaviour
{
    private vidasdeljugador sistemaVidas;

    void Start()
    {
        // Encuentra el script de vidas en la escena
        sistemaVidas = FindObjectOfType<vidasdeljugador>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("encenillo"))
        {
            sistemaVidas.SumarVida();
            Destroy(collision.gameObject); // Elimina el árbol después del contacto
        }
    }
}

