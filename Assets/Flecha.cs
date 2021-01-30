using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flecha : MonoBehaviour
{
    Rigidbody2D _myRb;
    Animator _myAni;
    Puerta_GertionEscena _pGestorEscena;

    [SerializeField]
    float _velocidad;

    void Start()
    {
        _pGestorEscena = GameObject.Find("GameController").GetComponent<Puerta_GertionEscena>();
        _myRb = GetComponent<Rigidbody2D>();
        _myAni = GetComponent<Animator>();
        if (_pGestorEscena.numeroDeNivelesPasados > 7)
        {
            _myAni.SetBool("Incendiada", true);
            _velocidad *= 1.5f;
        }

        _myRb.AddForce(Vector2.left * _velocidad * Time.deltaTime);
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject);
    }
}
