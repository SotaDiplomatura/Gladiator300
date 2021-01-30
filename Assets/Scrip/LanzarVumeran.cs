using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanzarVumeran : MonoBehaviour
{
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
    }

    void ComprobarDisparo()
    {
        if (Input.GetAxis("Disparo") != 0 && _tieneVuemeran)
        {
            if (_potencia < _potenciaMax)
            {
                _potencia += 1+Time.deltaTime;
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

    void Disparar()
    {
        Vector2 posicion;
        if(_myPc._derecha || _myPc._izquierda)
        {
            posicion = transform.GetChild(2).transform.position;
            Instantiate(_vumeran, posicion, Quaternion.identity, transform);
        }else if(_myPc._espalda)
        {
            posicion = transform.GetChild(1).transform.position;
            Instantiate(_vumeran, posicion, Quaternion.identity, transform);
        }else
        {
            posicion = transform.GetChild(0).transform.position;
            Instantiate(_vumeran, posicion, Quaternion.identity, transform);
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
