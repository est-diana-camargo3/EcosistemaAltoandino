using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class botonjugar : MonoBehaviour
{
    [Header("🎮 Configuración del movimiento flotante")]
    public float amplitud = 10f;        // Qué tanto se mueve hacia arriba y abajo
    public float velocidadFlotar = 2f;  // Velocidad del movimiento

    [Header("✨ Efecto de reborde pulsante")]
    public Image rebordeImage;          // Arrastra aquí la imagen del borde amarillo
    public Color colorBase = new Color(1f, 1f, 0f, 0.5f);  // Amarillo semitransparente
    public float velocidadBrillo = 2f;  // Velocidad del pulso
    public float intensidad = 0.5f;     // Qué tanto varía la opacidad

    private Vector3 posicionInicial;

    void Start()
    {
        posicionInicial = transform.localPosition;
    }

    void Update()
    {
        // 🌊 Movimiento suave de “flotar”
        float desplazamientoY = Mathf.Sin(Time.time * velocidadFlotar) * amplitud;
        transform.localPosition = posicionInicial + new Vector3(0, desplazamientoY, 0);

        // 💛 Efecto de brillo pulsante del reborde
        if (rebordeImage != null)
        {
            float alpha = (Mathf.Sin(Time.time * velocidadBrillo) + 1f) / 2f * intensidad + 0.3f;
            rebordeImage.color = new Color(colorBase.r, colorBase.g, colorBase.b, alpha);
        }
    }

    // 🚀 Acción del botón
    public void Jugar()
    {
        // Debug opcional para confirmar que se ejecuta el clic
        Debug.Log("🎮 Botón 'Jugar' presionado. Cargando escena escenadejuego...");

        // Cargar la escena de manera limpia, reemplazando todo
        SceneManager.LoadScene("escenadejuego", LoadSceneMode.Single);
    }
}
