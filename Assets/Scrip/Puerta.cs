using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puerta : MonoBehaviour
{
    Enemigos_GestionEnemigos _gEnemigos;
    Puerta_GertionEscena _gPuerta;
    Animator _myAni;

    Collider2D _myCollider;

    void Start()
    {
        _gEnemigos = GameObject.Find("GameController").GetComponent<Enemigos_GestionEnemigos>();
        _gPuerta = GameObject.Find("GameController").GetComponent<Puerta_GertionEscena>();
        _myAni = GetComponent<Animator>();
        _myCollider = GetComponent<Collider2D>();
        _myAni.SetBool("Abrir", false);
    }

    void Update()
    {
        AbrirPuerta();
    }

    void AbrirPuerta()
    {
        if(_gEnemigos.numeroEnemigos == 0)
        {
            _myAni.SetBool("Abrir",true);
            _myCollider.isTrigger = true;
        }
        else
        {
            _myAni.SetBool("Abrir", false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            _gPuerta.CargarEscena();
        }
    }
}
