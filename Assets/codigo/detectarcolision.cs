using UnityEngine.Video;   
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
    public ReproductorDeVideos reproductorVideos;  // ← referencia al reproductor
    private Animator animator; // referencia al Animator del jugador

    void Start()
    {
        animator = GetComponent<Animator>(); // obtener el Animator al iniciar
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 🌿 Si toca una planta o animal correcto
        if (collision.gameObject.CompareTag("contactocorrecto"))
        {
            Debug.Log("COLISION con: " + collision.gameObject.name);
            plantatocada planta = collision.gameObject.GetComponent<plantatocada>();
            if (planta != null && !planta.fueTocada)
            {
                planta.fueTocada = true;
                vidasdeljugador.SumarVida(); // suma un corazón
                Debug.Log(planta.gameObject.name + " tocada!"); // Para depuración
                                
                // ✅ reproducir video
                VideoAsociado va = collision.gameObject.GetComponent<VideoAsociado>();

                if (va == null)
                {
                    Debug.LogError("❌ ERROR: El objeto " + collision.gameObject.name + " NO tiene el script VideoAsociado.");
                }
                else if (va.clip == null)
                {
                    Debug.LogError("❌ ERROR: El objeto " + collision.gameObject.name + " SÍ tiene VideoAsociado pero **NO tiene un VideoClip asignado**.");
                }
                else
                {
                    Debug.Log("✅ Clip asignado correctamente: " + va.clip.name);
                    StartCoroutine(ReproducirVideoConRetraso(va.clip));
                }
            }
        }

        // 🕊️ Si toca al animal invasor (paloma doméstica)
        if (collision.gameObject.CompareTag("contactoincorrecto"))
        {
            // Desactivar movimiento del jugador
            GetComponent<movimientodeljugador>().enabled = false;

            // Activar animación de muerte
            if (animator != null)
            {
                animator.SetTrigger("Muerte");
            }

            // Iniciar la corrutina del error y reinicio
            StartCoroutine(MostrarErrorYReiniciar());
        }
    }

    IEnumerator ReproducirVideoConRetraso(VideoClip clip)
    {
        // Espera un frame antes de reproducir
        yield return null;

        reproductorVideos.ReproducirVideo(clip);

        Debug.Log("🎬 Corrutina activada → Reproduciendo video en pantalla.");
    }

    IEnumerator MostrarErrorYReiniciar()
    {
        Debug.Log("⚠️ Panel de error activado");

        // Esperar un momento para que la animación se vea antes de mostrar el panel
        yield return new WaitForSeconds(0.5f);

        // Activar panel
        panelerrortocoinvasor.SetActive(true);
        textoerrortocoinvasor.text =
            "Error: La paloma no es del ecosistema Altoandino Bogotano.\n" +
            "Vuelve a intentarlo.";

        // Esperar unos segundos para mostrar el mensaje y permitir que la animación se reproduzca completa
        yield return new WaitForSecondsRealtime(3f);

        // Reiniciar la escena
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
