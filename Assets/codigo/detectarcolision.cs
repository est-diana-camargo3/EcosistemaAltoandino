using UnityEngine;

public class detectarcolision : MonoBehaviour
{
    private vidasdeljugador sistemaVidas;

    void Start()
    {
        sistemaVidas = FindObjectOfType<vidasdeljugador>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Detectar plantas correctas (tag compartido)
        if (collision.gameObject.CompareTag("plantacorrecta"))
        {
            plantatocada planta = collision.gameObject.GetComponent<plantatocada>();
            if (planta != null && !planta.fueTocada)
            {
                planta.fueTocada = true; // marcar como ya tocada
                sistemaVidas.SumarVida();
            }
        }
    }
}


