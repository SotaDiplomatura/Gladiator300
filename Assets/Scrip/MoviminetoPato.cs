using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoviminetoPato : MonoBehaviour
{
    Transform _player;
    NavMeshAgent _navM;
    Animator _myAni;
    Vida _myVida;
    Collider2D _myColli;

    [SerializeField]
    GameObject pato1, pato2;

    float x;
    float y;

    [SerializeField]
    float _daño;

    [SerializeField]
    bool sePuedeRomper;
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
        _myColli = GetComponent<Collider2D>();
        _myAni = transform.GetChild(0).GetComponent<Animator>();
        _navM = GetComponent<NavMeshAgent>();
        _myVida = GetComponent<Vida>();
        _navM.updateRotation = false;
        _navM.updateUpAxis = false;
    }

    // Update is called once per frame
    void Update()
    {
        _navM.SetDestination(_player.position);
        Flip();
        LeerInput();
        Muerte();
    }

    void Flip()
    {
        if (x > _player.position.x)
        {
            transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 0));
        }
        else
        {
            transform.localRotation = Quaternion.Euler(new Vector3(0, -180, 0));
        }
    }

    void LeerInput()
    {
        x = transform.position.x;
        y = transform.position.y;
    }

    void Muerte()
    {
        if(_myVida._vida <= 0)
        {
            if(sePuedeRomper)
            {
                Instantiate(pato1, new Vector2(transform.localPosition.x + Random.Range(-0.1f, 0.1f), transform.localPosition.y + Random.Range(-0.1f, 0.1f)), Quaternion.identity);
                Instantiate(pato1, new Vector2(transform.localPosition.x + Random.Range(-0.1f, 0.1f), transform.localPosition.y + Random.Range(-0.1f, 0.1f)), Quaternion.identity);
            }
            _navM.SetDestination(transform.position);
            _myColli.enabled = false;
            sePuedeRomper = false;
            _myAni.SetBool("Descomponer", true);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Vida>().Daño(_daño);
        }
    }
}
