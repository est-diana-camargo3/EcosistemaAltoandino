using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class vidasdeljugador : MonoBehaviour
{
    public int vidas = 0; // El jugador inicia con 0 vidas
    public List<Image> corazones; // Arrastra aquí los 9 corazones del Canvas
    public Sprite corazonlleno;
    public Sprite corazonvacio;

    void Start()
    {
        ActualizarVidas();
    }

    public void SumarVida()
    {
        if (vidas < corazones.Count)
        {
            vidas++;
            ActualizarVidas();
        }
    }

    void ActualizarVidas()
    {
        for (int i = 0; i < corazones.Count; i++)
        {
            if (i < vidas)
                corazones[i].sprite = corazonlleno;
            else
                corazones[i].sprite = corazonvacio;
        }
    }
}
