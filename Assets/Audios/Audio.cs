using UnityEngine;
using System.Collections;

public class LoopDosAudios : MonoBehaviour
{
    public AudioSource audioSource1;
    public AudioSource audioSource2;
    public float duracionLoop = 8f;
    [Range(0.1f, 2f)]
    public float pitchAudio2 = 0.8f; // Pitch para el segundo audio (más lento si < 1)

    void Start()
    {
        if (audioSource1 != null)
        {
            audioSource1.loop = false;
            audioSource1.time = 0f;
            audioSource1.Play();
            StartCoroutine(LoopAudio(audioSource1));
        }

        if (audioSource2 != null)
        {
            audioSource2.pitch = pitchAudio2; // Ajustamos el pitch antes de reproducir
            audioSource2.loop = false;
            audioSource2.time = 0f;
            audioSource2.Play();
            StartCoroutine(LoopAudio(audioSource2));
        }
    }

    IEnumerator LoopAudio(AudioSource source)
    {
        while (true)
        {
            if (source.time >= duracionLoop)
            {
                source.time = 0f;  // Reinicia sin detener el audio
            }
            yield return null;
        }
    }
}
