using TMPro; 
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class detectarcolision : MonoBehaviour
{
    public vidasdeljugador vidasdeljugador; // referencia al script de las vidas
    public GameObject panelerrortocoinvasor; // panel con el mensaje de error
    public TMP_Text textoerrortocoinvasor; 

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 🌿 Si toca una planta o animal correcto
        if (collision.gameObject.CompareTag("contactocorrecto"))
        {
            plantatocada planta = collision.gameObject.GetComponent<plantatocada>();
            if (planta != null && !planta.fueTocada)
            {
                planta.fueTocada = true;
                vidasdeljugador.SumarVida(); // suma un corazón
                Debug.Log(planta.gameObject.name + " tocada!"); // Para depuración
            }
        }


        // 🕊️ Si toca al animal invasor (paloma doméstica)
        if (collision.gameObject.CompareTag("contactoincorrecto"))
        {
            StartCoroutine(MostrarErrorYReiniciar());
            // Ejemplo: deshabilitar el script del jugador
            GetComponent<movimientodeljugador>().enabled = false;
        }
    }

    IEnumerator MostrarErrorYReiniciar()
    {
        Debug.Log("⚠️ Panel de error activado");

        // Activar panel
        panelerrortocoinvasor.SetActive(true);
        textoerrortocoinvasor.text =
            "Error: La paloma no es del ecosistema Altoandino Bogotano.\n" +
            "Vuelve a intentarlo.";

        // Esperar un frame para que Unity dibuje la UI
        yield return null;

        // Esperar unos segundos en tiempo real antes de pausar o reiniciar
        yield return new WaitForSecondsRealtime(3f);

        // Reiniciar la escena
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
