﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_GestionPlayer : MonoBehaviour
{
    [SerializeField]
    GameObject _player;

    Transform _puerta;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _puerta = GameObject.Find("Entrada").GetComponent<Transform>();
        if (GameObject.Find("Player(Clone)") == null)
        {
            Instantiate(_player, _puerta.position, Quaternion.identity);
        }
    }
}
