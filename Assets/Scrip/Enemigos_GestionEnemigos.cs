using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigos_GestionEnemigos : MonoBehaviour
{
    public int numeroEnemigos;

    private void Update()
    {
        if(GameObject.FindGameObjectWithTag("Enemigo") == null)
        {
            numeroEnemigos = 0;
        }
    }

    public void SumarEnemigo()
    {
        numeroEnemigos++;
    }
}
