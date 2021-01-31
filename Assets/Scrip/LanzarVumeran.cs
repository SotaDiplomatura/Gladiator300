using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanzarVumeran : MonoBehaviour
{
    [SerializeField]
    List<Sprite> _barra;
    [SerializeField]
    SpriteRenderer _spriteBarra;
    [SerializeField]
    Animator _aniBarra;

    PlayerController _myPc;
    [SerializeField]
    GameObject _vumeran;
    [SerializeField]
    float _potenciaMax;
    public float _potencia;


    bool _cargado = false;
    bool _tieneVuemeran = true;
    void Start()
    {
        _myPc = GetComponent<PlayerController>();
    }

    void Update()
    {
        ComprobarDisparo();
        ActualizarBarra();
    }

    void ComprobarDisparo()
    {
        if (Input.GetAxis("Disparo") != 0 && _tieneVuemeran)
        {
            if (_potencia < _potenciaMax)
            {
                _potencia += 0.3f;
            }
            _cargado = true;
        }
        else if (_tieneVuemeran && _cargado)
        {
            Disparar();
            _cargado = false;
            _tieneVuemeran = false;
        }
    }
    void ActualizarBarra()
    {
        if (_potencia == 0)
        {
            _aniBarra.enabled = false;
            _aniBarra.SetBool("Full", false);
            _spriteBarra.sprite = null;
        } else if (_potencia < _potenciaMax / 4)
        {
            _aniBarra.enabled = false;
            _aniBarra.SetBool("Full", false);
            _spriteBarra.sprite = _barra[0];
        }else if (_potencia < _potenciaMax / 3)
        {
            _aniBarra.enabled = false;
            _aniBarra.SetBool("Full", false);
            _spriteBarra.sprite = _barra[1];
        }else if (_potencia < _potenciaMax / 2)
        {
            _aniBarra.enabled = false;
            _aniBarra.SetBool("Full", false);
            _spriteBarra.sprite = _barra[2];
        }else if (_potencia < _potenciaMax)
        {
            _aniBarra.enabled = false;
            _aniBarra.SetBool("Full", false);
            _spriteBarra.sprite = _barra[2];
        }
        else
        {
            _aniBarra.enabled = true;
            _aniBarra.SetBool("Full", true);
        }
    }
    void Disparar()
    {
        Vector2 posicion;
        if(_myPc._derecha || _myPc._izquierda)
        {
            posicion = transform.GetChild(2).transform.position;
            Instantiate(_vumeran, posicion, Quaternion.identity);
        }else if(_myPc._espalda)
        {
            posicion = transform.GetChild(1).transform.position;
            Instantiate(_vumeran, posicion, Quaternion.identity);
        }else
        {
            posicion = transform.GetChild(0).transform.position;
            Instantiate(_vumeran, posicion, Quaternion.identity);
        }
        Invoke("BajarPotencia", 0.1f);
    }

    void BajarPotencia()
    {
        _potencia = 0;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Vumeran"))
        {
            _tieneVuemeran = true;
            Destroy(collision.gameObject);
        }
    }
}
