using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaPlayer : MonoBehaviour
{
    [SerializeField]
    float _vida;

    float cadencia;
    float tiempoDa�os;

    private void Update()
    {
        cadencia += Time.deltaTime;
    }
    public void Da�o(float d)
    {
        if(cadencia >= tiempoDa�os)
        {
            _vida -= d;
            cadencia = 0;
        }
    }
}
