using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUP : MonoBehaviour
{
    Puerta_GertionEscena _gEscena;
    PlayerController _myPlayerControll;
    [SerializeField]
    GameObject _levelUp,_levelUp2;

    [SerializeField]
    int salaLevelUp;
    void Start()
    {
        _gEscena = GameObject.Find("GameController").GetComponent<Puerta_GertionEscena>();
        _myPlayerControll = GetComponent<PlayerController>();
    }

    void Update()
    {
        if(_gEscena.numeroDeNivelesPasados > salaLevelUp)
        {
            _levelUp.SetActive(true);
            _myPlayerControll._daño *= 2;
            _myPlayerControll._velocidad *= 1.5f;
        }
    }
}
