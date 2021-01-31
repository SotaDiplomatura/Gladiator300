using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flecha : MonoBehaviour
{
    Rigidbody2D _myRb;
    Animator _myAni;
    Puerta_GertionEscena _pGestorEscena;

    [SerializeField]
    float _velocidad,_daño;

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

        _myRb.AddForce(Vector2.left * _velocidad);
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<VidaPlayer>().Daño(_daño);
        }
        if (collision.gameObject.CompareTag("Enemigo"))
        {
            collision.gameObject.GetComponent<Vida>().Daño(_daño);
        }
        Destroy(this.gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<VidaPlayer>().Daño(_daño);
        }
        if (collision.gameObject.CompareTag("Enemigo"))
        {
            collision.gameObject.GetComponent<Vida>().Daño(_daño);
        }
        Destroy(this.gameObject);
    }
}
