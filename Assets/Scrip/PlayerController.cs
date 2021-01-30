using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D _myRb;
    Animator _myAni;

    [SerializeField]
    float _velocidad;

    Vector2 _input;

    void Start()
    {
        _myRb = GetComponent<Rigidbody2D>();
        _myAni = GetComponent<Animator>();
    }

    void Update()
    {
        LeerInput();
        Movimiento();
        Flip();
        Animaciones();

    }

    void LeerInput()
    {
        _input.x = Input.GetAxisRaw("Horizontal");
        _input.y = Input.GetAxisRaw("Vertical");
    }

    void Movimiento()
    {
        _input = _input * _velocidad * Time.deltaTime;
        if(_input.x != 0 && _input.y !=0)
        {
            _input /= 1.5f;
        }
        _myRb.velocity = new Vector2(_input.x,_input.y);
    }

    void Flip()
    {
        if(_input.x >0)
        {
            transform.localRotation = Quaternion.Euler(0,180,0);
        }
        else
        {
            transform.localRotation = Quaternion.Euler(0,0,0);
        }
    }

    void Animaciones()
    {
        int x = (int)_input.x;
        int y = (int)_input.y;
        _myAni.SetInteger("X", x);
        _myAni.SetInteger("Y", y);
    }
}
