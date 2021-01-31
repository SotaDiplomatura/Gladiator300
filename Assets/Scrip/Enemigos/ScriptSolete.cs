using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class ScriptSolete : MonoBehaviour
{
    Transform _player;
    NavMeshAgent _navM;
    Collider2D _myColli;

    float x;
    float y;

    [SerializeField]
    float _daño;

    [SerializeField]
    float _speed;

    [SerializeField]
    bool sePuedeRomper;

    public LayerMask _playerMask;

    public Sprite disparo;
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

        if (distanciaEnX < 0.1 || distanciaEnY < 0.1)
        {
            Disparo();
        }

        else if (distanciaObjetivo > 3)
        {
            transform.position = Vector3.Lerp(transform.position, _player.transform.position, _speed);
        }
        else
        {

            if (distanciaEnY < distanciaEnX)
            {
                transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, _player.transform.position.y, 0), _speed);
            }
            else
            {
                transform.position = Vector3.Lerp(transform.position, new Vector3(_player.transform.position.x, transform.position.y, 0), _speed);
            }
        }

        void Disparo ()
        {
            if (distanciaEnY < 0)
            {
                Debug.DrawRay(transform.position, Vector3.right * Mathf.Infinity);
                RaycastHit2D hit;

                //hit = Physics2D.Linecast(transform.position,Vector3.up, _playerMask);

                //if (hit.collider != null)
                //{
                //    Debug.Log("Disparo");
                //}
            }
            else if (distanciaEnY > 0)
            {
                Debug.DrawRay(transform.position, Vector3.up * Mathf.Infinity);
                //RaycastHit2D hit;

                //hit = Physics2D.Linecast(transform.position, _player.transform.position, _playerMask);

                //if (hit.collider != null)
                //{
                //    Debug.Log("Disparo");
                //}
            }
            else if (distanciaEnX < 0)
            {
                Debug.DrawRay(transform.position, Vector3.down * Mathf.Infinity);
                RaycastHit2D hit;

                //hit = Physics2D.Linecast(transform.position, _player.transform.position, _playerMask);

                //if (hit.collider != null)
                //{
                //    Debug.Log("Disparo");
                //}
            }
            else if (distanciaEnX > 0)
            {
                Debug.DrawRay(transform.position, Vector3.left * Mathf.Infinity);
                //RaycastHit2D hit;

                //hit = Physics2D.Linecast(transform.position, _player.transform.position, _playerMask);

                //if (hit.collider != null)
                //{
                //    Debug.Log("Disparo");
                //}
            }
        }
    }
}
