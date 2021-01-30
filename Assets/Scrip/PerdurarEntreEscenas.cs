using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerdurarEntreEscenas : MonoBehaviour
{
    bool creado = false;

    void Awake()
    {
        if(!creado)
        {
            DontDestroyOnLoad(this.gameObject);
            creado = true;
        }
    }

}
enum Salas
{
    Pequeña,Media,Grandes
}