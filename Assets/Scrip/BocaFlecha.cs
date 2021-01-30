using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BocaFlecha : MonoBehaviour
{
    Animator _myAni;
    Puerta_GertionEscena _pGt;

    void Start()
    {
        _myAni = GetComponent<Animator>();
        _pGt = GameObject.Find("GameController").GetComponent<Puerta_GertionEscena>();
    }

    void Update()
    {
        if(_pGt.numeroDeNivelesPasados > 7)
        {
            _myAni.SetBool("Fuego", true);
        }
    }
}
