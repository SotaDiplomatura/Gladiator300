using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorEnemigos : MonoBehaviour
{
    Puerta_GertionEscena _gEscena;

    [SerializeField]
    List<Transform> _puntos;

    [SerializeField]
    Salas _sala;

    [SerializeField]
    List<GameObject> _enemigos;

    [SerializeField]
    int numeroEnemigos;
    [SerializeField]
    float tiempoEntreSpawn;

    float _aparicion = 0;
    int numeroMaximoEnemigos;
    int numeroSpawneados;
    Vector2 _posicion;
    void Start()
    {
        _gEscena = GameObject.Find("GameController").GetComponent<Puerta_GertionEscena>();
        if(_gEscena.numeroDeNivelesPasados >= 3 && _gEscena.numeroDeNivelesPasados < 5)
        {
            numeroEnemigos += 1;
        }else if(_gEscena.numeroDeNivelesPasados >= 5 && _gEscena.numeroDeNivelesPasados < 7)
        {
            numeroEnemigos += 2;
        }
        else if (_gEscena.numeroDeNivelesPasados >= 7 && _gEscena.numeroDeNivelesPasados < 9)
        {
            numeroEnemigos += 2;
        }
        else if (_gEscena.numeroDeNivelesPasados >= 9 && _gEscena.numeroDeNivelesPasados < 11)
        {
            numeroEnemigos += 2;
        }
        else if (_gEscena.numeroDeNivelesPasados >= 11 && _gEscena.numeroDeNivelesPasados < 13)
        {
            numeroEnemigos += 2;
        }else if(_gEscena.numeroDeNivelesPasados == 14)
        {
            numeroEnemigos += 4;
        }

        switch (_sala)
        {
            case Salas.Pequeña:
                numeroEnemigos -= 2;
                numeroMaximoEnemigos = 4;
                break;
            case Salas.Media:
                numeroMaximoEnemigos = 10;
                break;
            case Salas.Grandes:
                numeroEnemigos += 3;
                break;
        }
               
    }

    void Update()
    {
        Spawn();
    }

    void Spawn()
    {
        _aparicion += Time.deltaTime;
        if(_aparicion >= tiempoEntreSpawn )
        {
            ElegirSpawn();
            ElegirEnemigo();

            _aparicion = 0;
        }
    }

    void ElegirSpawn()
    {
        int numeroAleatorio = Random.Range(0,_puntos.Count);
        _posicion = _puntos[numeroAleatorio].position;
    }

    GameObject ElegirEnemigo()
    {
        int numeroAleatorio = Random.Range(0, _puntos.Count);
        if(_gEscena.numeroDeNivelesPasados < 4)
        {
            return _enemigos[0];
        }
        else
        {
            return _enemigos[numeroAleatorio];
        }
    }
}
