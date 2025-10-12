using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class botonsalir : MonoBehaviour
{
    public void Cerrar()
    {
        #if UNITY_EDITOR
        EditorApplication.isPlaying = false; // Detiene el juego en el Editor
        #else
        Application.Quit(); // Cierra el juego en el build
        #endif
    }
}

