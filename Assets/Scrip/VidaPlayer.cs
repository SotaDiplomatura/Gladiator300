using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaPlayer : MonoBehaviour
{
    [SerializeField]
    float _vida;

    float cadencia;
    float tiempoDaños;

    private void Update()
    {
        cadencia += Time.deltaTime;
    }
    public void Daño(float d)
    {
        if(cadencia >= tiempoDaños)
        {
            _vida -= d;
            cadencia = 0;
        }
    }
}
