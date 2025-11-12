using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class ReproductorDeVideos : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public RawImage rawImage;
    public GameObject panelVideo;
    public movimientodeljugador jugador; // 👈 referencia al script del jugador

    void Start()
    {
        // Al iniciar, ocultar el panel
        if (panelVideo != null)
            panelVideo.SetActive(false);

        if (videoPlayer != null)
            videoPlayer.playOnAwake = false;
    }

    public void ReproducirVideo(VideoClip clip)
    {
        if (videoPlayer == null || rawImage == null || panelVideo == null)
        {
            Debug.LogError("⚠️ Falta asignar referencias en ReproductorDeVideos.");
            return;
        }

        panelVideo.SetActive(true); // mostrar panel

        // 🚫 Desactivar movimiento del jugador mientras se reproduce el video
        if (jugador != null)
            jugador.enabled = false;

        videoPlayer.clip = clip;
        videoPlayer.isLooping = false;
        videoPlayer.Prepare();

        videoPlayer.prepareCompleted += (vp) =>
        {
            Debug.Log("🎬 Video preparado, iniciando reproducción...");
            rawImage.texture = videoPlayer.targetTexture;
            videoPlayer.Play();
        };

        // 🎬 Cuando el video termina
        videoPlayer.loopPointReached += (vp) =>
        {
            CerrarVideo();
        };
    }

    public void CerrarVideo()
    {
        Debug.Log("🛑 Cerrando video...");
        videoPlayer.Stop();
        panelVideo.SetActive(false);

        // ✅ Reactivar movimiento del jugador
        if (jugador != null)
            jugador.enabled = true;
    }
}
