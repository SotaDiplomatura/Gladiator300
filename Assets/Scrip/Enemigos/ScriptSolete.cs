using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class ScriptSolete : MonoBehaviour
{
    Transform _player;
    NavMeshAgent _navM;
    Collider2D _myColli;

    [SerializeField]
    GameObject pato1, pato2;

    float x;
    float y;

    [SerializeField]
    float _daño;

    [SerializeField]
    float _speed;

    [SerializeField]
    bool sePuedeRomper;
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
        _myColli = GetComponent<Collider2D>();
        _navM = GetComponent<NavMeshAgent>();
        _navM.updateRotation = false;
        _navM.updateUpAxis = false;
    }


    void FixedUpdate()
    {
        float distanciaObjetivo = Vector3.Distance(transform.position, _player.transform.position);
        float distanciaEnX = (transform.position.x - _player.transform.position.x);
        float distanciaEnY = (transform.position.y - _player.transform.position.y);

        //Debug.Log("distancia en x : " + distanciaEnX + "distancia en y : " + distanciaEnY);


        if (distanciaObjetivo > 3)
        {
            transform.position = Vector3.Lerp(transform.position, _player.transform.position, _speed * Time.deltaTime);
        }
        else
        {

            if (distanciaEnY < distanciaEnX)
            {
                transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, _player.transform.position.y, 0), _speed * Time.deltaTime);
            }
            else
            {
                transform.position = Vector3.Lerp(transform.position, new Vector3(_player.transform.position.x, transform.position.y, 0), _speed * Time.deltaTime);
            }
        }

    }
}
