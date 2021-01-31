using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Puerta_GertionEscena : MonoBehaviour
{
    public int numeroDeNivelesPasados;
    [SerializeField]
    int finalDelJuego;

    public void CargarEscena()
    {
        int escenaRandom;
        if (numeroDeNivelesPasados < 8)
        {
            escenaRandom = Random.Range(2, 6);
            SceneManager.LoadScene(escenaRandom);
        }
        else
        {
            escenaRandom = Random.Range(2, 7);
            SceneManager.LoadScene(escenaRandom);
        }
        if(numeroDeNivelesPasados >= finalDelJuego)
        {
            SceneManager.LoadScene(7);
        }
        numeroDeNivelesPasados++;
    }

}
