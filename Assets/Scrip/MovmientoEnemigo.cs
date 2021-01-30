using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MovmientoEnemigo : MonoBehaviour
{
    Transform _player;
    NavMeshAgent _navM;
    Animator _myAni;

    float x = 0;
    float y = 0;
    float yRecuerdo;
    float xRecuerdo;

    int inputY;
    int inputX;

    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
        _myAni = GetComponent<Animator>();
        _navM = GetComponent<NavMeshAgent>();
        _navM.updateRotation = false;
        _navM.updateUpAxis = false;
    }

    // Update is called once per frame
    void Update()
    {
        _navM.SetDestination(_player.position);
        LeerDireccion();
        Flip();
        Animacion();
    }

    void LeerDireccion()
    {
        xRecuerdo = x;
        yRecuerdo = y;
        x = transform.position.x;
        y = transform.position.y;
        float comparacionX = xRecuerdo - x;
        comparacionX = (float)System.Math.Round(comparacionX, 3);
        print(comparacionX);
        float comparacionY = yRecuerdo - y;
        if(comparacionX > -0.015f && comparacionX < 0.015f)
        {
            inputX = 0;
        }
        else if (comparacionX < 0)
        {
            inputX = -1;
        }
        else if (comparacionX > 0)
        {
            inputX = 1;
        }

        if (yRecuerdo > y)
        {
            inputY = -1;
        }
        else if (yRecuerdo < y)
        {
            inputY = 1;
        }
        else
        {
            inputY = 0;
        }
    }
    void Flip()
    {
        if(x > _player.position.x)
        {
            transform.localRotation = Quaternion.Euler(new Vector3(0,0,0));
        }else
        {
            transform.localRotation = Quaternion.Euler(new Vector3(0, -180, 0));
        }
    }
    void Animacion()
    {
        _myAni.SetInteger("x", inputX);
        _myAni.SetInteger("y", inputY);
    }
}
