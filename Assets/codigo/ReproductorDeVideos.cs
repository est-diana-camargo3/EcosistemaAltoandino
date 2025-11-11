using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using System.Collections;

public class ReproductorDeVideos : MonoBehaviour
{
    public static ReproductorDeVideos instancia;
    public GameObject panelVideo;
    public RawImage contenedorVideo;
    public VideoPlayer videoPlayer;

    public movimientodeljugador movimientoJugador; // Para pausar movimiento

    void Start()
    {
        panelVideo.SetActive(false);
        contenedorVideo.gameObject.SetActive(false);
    }

    public void ReproducirVideo(VideoClip clip)
    {
        StartCoroutine(MostrarVideo(clip));
    }

    IEnumerator MostrarVideo(VideoClip clip)
    {
        // Pausar movimiento del jugador
        if (movimientoJugador != null)
            movimientoJugador.enabled = false;

        panelVideo.SetActive(true);
        contenedorVideo.gameObject.SetActive(true);

        videoPlayer.clip = clip;
        videoPlayer.Play();

        // Esperar a que el video termine
        while (videoPlayer.isPlaying)
        {
            yield return null;
        }

        // Ocultar video
        videoPlayer.Stop();
        panelVideo.SetActive(false);
        contenedorVideo.gameObject.SetActive(false);

        // Reanudar movimiento
        if (movimientoJugador != null)
            movimientoJugador.enabled = true;
    }
}
