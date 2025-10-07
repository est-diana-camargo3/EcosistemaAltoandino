using UnityEngine;
using UnityEngine.SceneManagement; // Para recargar escena (si quisieras)

public class detectarcolision : MonoBehaviour
{
    private vidasdeljugador sistemaVidas;
    private Vector3 posicionInicial;

    void Start()
    {
        // Busca el sistema de vidas y guarda la posición inicial del jugador
        sistemaVidas = FindObjectOfType<vidasdeljugador>();
        posicionInicial = transform.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // ✅ Contacto correcto: plantas o animales del ecosistema
        if (collision.gameObject.CompareTag("contactocorrecto"))
        {
            plantatocada planta = collision.gameObject.GetComponent<plantatocada>();
            if (planta != null && !planta.fueTocada)
            {
                planta.fueTocada = true;
                sistemaVidas.SumarVida();
            }
        }

        // ❌ Contacto incorrecto: Paloma Doméstica
        if (collision.gameObject.CompareTag("contactoincorrecto"))
        {
            Debug.Log("⚠️ Contacto con animal invasor: reiniciando juego.");

            // Reinicia vidas
            sistemaVidas.vidas = 0;
            sistemaVidas.SendMessage("ActualizarVidas");

            // Devuelve jugador a su posición inicial
            transform.position = posicionInicial;

            // (Opcional) Si prefieres reiniciar toda la escena:
            // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}


