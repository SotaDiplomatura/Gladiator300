﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vida : MonoBehaviour
{
    public float _vida;

    public void Daño(float d)
    {
        _vida -= d;
    }
}
