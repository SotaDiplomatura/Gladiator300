using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUP : MonoBehaviour
{
    Puerta_GertionEscena _gEscena;
    PlayerController _myPlayerControll;
    VidaPlayer _myVida;
    [SerializeField]
    GameObject _levelUp,_levelUp2;

    [SerializeField]
    int salaLevelUp,salaLevelUp2;
    void Start()
    {
        _gEscena = GameObject.Find("GameController").GetComponent<Puerta_GertionEscena>();
        _myPlayerControll = GetComponent<PlayerController>();
        _myVida = GetComponent<VidaPlayer>();
        if (_gEscena.numeroDeNivelesPasados == salaLevelUp)
        {
            _levelUp.SetActive(true);
            _myPlayerControll._daño *= 2f;
            _myPlayerControll._velocidad += 2f;
            _myVida._vida = _myVida._vidaMax;
        }
        if (_gEscena.numeroDeNivelesPasados == salaLevelUp2)
        {
            _levelUp2.SetActive(true);
            _myPlayerControll._daño *= 2f;
            _myPlayerControll._velocidad += 2f;
            _myVida._vida = _myVida._vidaMax;
        }
    }
}
