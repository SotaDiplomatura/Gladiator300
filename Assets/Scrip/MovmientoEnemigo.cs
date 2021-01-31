using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MovmientoEnemigo : MonoBehaviour
{
    Transform _player;
    NavMeshAgent _navM;
    Animator _myAni;
    Vida _myVida;

    float x = 0;
    float y = 0;
    float yRecuerdo;
    float xRecuerdo;

    int inputY;
    int inputX;
    public bool _atacando;
    float cadencia;

    [SerializeField]
    float _distanciaAtaque,_tiempoEntreAtaque;
    [SerializeField]
    float _daño;
    public float _dañoAtaque;
    [SerializeField]
    GameObject _colliderAtac;
    void Start()
    {
        _atacando = false;
        _player = GameObject.FindGameObjectWithTag("Player").transform;
        _myVida = GetComponent<Vida>();
        _myAni = GetComponent<Animator>();
        _navM = GetComponent<NavMeshAgent>();
        _navM.updateRotation = false;
        _navM.updateUpAxis = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!_atacando)
        {
            _navM.SetDestination(_player.position);
            LeerDireccion();
            Flip();
            RotarAtaque();
            Animacion();
        }
        Atacar();
        Muerte();
    }

    void LeerDireccion()
    {
        xRecuerdo = x;
        yRecuerdo = y;
        x = transform.position.x;
        y = transform.position.y;
        float comparacionX = xRecuerdo - x;
        float comparacionY = yRecuerdo - y;
        if(comparacionX > -0.01f && comparacionX < 0.01f)
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

    void RotarAtaque()
    {
        _colliderAtac.transform.right = -(_player.transform.position-_colliderAtac.transform.position);
    }

    void Atacar()
    {
        float distancia = Vector2.Distance(transform.position, _player.position);
        if(distancia < _distanciaAtaque)
        {
            _navM.SetDestination(transform.position);
            _colliderAtac.SetActive(true);
            _atacando = true;  
        }
        cadencia += Time.deltaTime;
        if(cadencia >= _tiempoEntreAtaque)
        {
            cadencia = 0;
            _atacando = false;
            _colliderAtac.SetActive(false);
        }
    }

    void Animacion()
    {
        _myAni.SetInteger("x", inputX);
        _myAni.SetInteger("y", inputY);
    }

    void Muerte()
    {
        if(_myVida._vida <= 0)
        {
            Destroy(gameObject);
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
