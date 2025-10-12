using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

[DefaultExecutionOrder(100)] // 👈 asegura que corra después de que se cargue la UI
public class vidasdeljugador : MonoBehaviour
{
    public int vidas = 0; // El jugador inicia con 0 vidas
    public List<Image> corazones; // Arrastra aquí los 9 corazones del Canvas
    public Sprite corazonlleno;
    public Sprite corazonvacio;

    void Awake()
    {
        // Inicializar los corazones con corrutina
        StartCoroutine(ActualizarCorazonesAlInicio());
    }
    IEnumerator ActualizarCorazonesAlInicio()
    {
        yield return null; // espera 1 frame
        ActualizarVidas();
    }
    void Start()
    {
        // Esperar un frame para que Unity cargue bien las referencias de UI
        StartCoroutine(InicializarVidas());
    }

    IEnumerator InicializarVidas()
    {
        yield return null; // Esperar un frame
        ActualizarVidas();
    }

    public void SumarVida()
    {
        if (vidas < corazones.Count)
        {
            vidas++;
            ActualizarVidas();

            // 💫 Si llega a las 9 vidas, cambiar a la escena de victoria
            if (vidas >= corazones.Count)
            {
                SceneManager.LoadScene("escenaganaste");
            }
        }
    }

    public void ReiniciarVidas()
    {
        vidas = 0;
        ActualizarVidas();
    }

    private void ActualizarVidas()
    {
        // Verificar que las referencias existan
        if (corazones == null || corazones.Count == 0)
        {
            Debug.LogWarning("⚠️ No hay corazones asignados en el inspector.");
            return;
        }

        for (int i = 0; i < corazones.Count; i++)
        {
            if (corazones[i] == null) continue;

            // Evitar errores si el sprite se perdió
            // if (corazonlleno == null || corazonvacio == null)
            if ( corazonlleno == null)
            {
                Debug.LogWarning("⚠️ Falta asignar sprites de corazón lleno en el Inspector.");
                return;
            }

            if (i < vidas)
                corazones[i].sprite = corazonlleno;
            else
                corazones[i].sprite = corazonvacio;
        }
    }
}
