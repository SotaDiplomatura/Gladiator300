using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vumeran : MonoBehaviour
{
    Rigidbody2D _myRb;
    PlayerController _playerControll;
    LanzarVumeran _playerLanzaV;
    SpriteRenderer _mySr;

    [SerializeField]
    Sprite _normal, _girando;
    [SerializeField]
    float _velocidadGiro;

    float _rt_z;
    float potencia;
    private void Awake()
    {
        _myRb = GetComponent<Rigidbody2D>();
        _mySr = GetComponent<SpriteRenderer>();
        _playerControll = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        _playerLanzaV = GameObject.FindGameObjectWithTag("Player").GetComponent<LanzarVumeran>();
        gameObject.layer = 9;
        potencia = _playerLanzaV._potencia * 10;
    }
    void Start()
    { 
        Invoke("CambiarLayer", 0.2f);
        Inpulso();
    }

    void Inpulso()
    {
        if(_playerControll._derecha && _playerControll._espalda)
        {
            potencia /= 1.5f;
            _myRb.AddForce(new Vector2(1,1) * potencia);
        }else if(_playerControll._derecha && _playerControll._frente)
        {
            potencia /= 1.5f;
            _myRb.AddForce(new Vector2(1, -1) * potencia);

        }else if(_playerControll._izquierda && _playerControll._espalda)
        {
            potencia /= 1.5f;
            _myRb.AddForce(new Vector2(-1, 1) * potencia);

        }else if(_playerControll._izquierda && _playerControll._frente)
        {
            potencia /= 1.5f;
            _myRb.AddForce(new Vector2(-1, -1) * potencia);
        }else if(_playerControll._derecha)
        {
            _myRb.AddForce(new Vector2(1, 0) * potencia);
        }
        else if(_playerControll._izquierda)
        {
            _myRb.AddForce(new Vector2(-1, 0) * potencia);
        }else if(_playerControll._espalda)
        {
            _myRb.AddForce(new Vector2(0, 1) * potencia);
        }else if(!_playerControll._espalda)
        {
            _myRb.AddForce(new Vector2(0, -1) * potencia);
        }
    }

    private void Update()
    {
        _rt_z += Mathf.Round(_myRb.velocity.magnitude) * _velocidadGiro * Time.deltaTime;
        transform.localRotation = Quaternion.Euler(0,0,_rt_z);
        if(_myRb.velocity.magnitude > 5)
        {
            _mySr.sprite = _girando;
        }
        else
        {
            _mySr.sprite = _normal;
        }
        if(Mathf.Round(_myRb.velocity.magnitude) <= 4)
        {
            _myRb.velocity = new Vector2(0,0);
        }
    }

    void CambiarLayer()
    {
        gameObject.layer = 8;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Enemigo"))
        {
            collision.gameObject.GetComponent<Vida>().Daño(_playerControll._daño);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemigo"))
        {
            collision.gameObject.GetComponent<Vida>().Daño(_playerControll._daño);
        }
    }
}
