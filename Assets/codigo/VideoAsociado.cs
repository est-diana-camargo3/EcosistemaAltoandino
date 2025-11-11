using UnityEngine;
using UnityEngine.Video;

public class VideoAsociado : MonoBehaviour
{
    public VideoClip clip;

    public void ReproducirVideo()
    {
        // Llamar al reproductor global para activar el panel y reproducir
        ReproductorDeVideos.instancia.ReproducirVideo(clip);
    }
}
