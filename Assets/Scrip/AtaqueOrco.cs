using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueOrco : MonoBehaviour
{
    MovmientoEnemigo _movEnemigo;

    void Start()
    {
        _movEnemigo = transform.parent.GetComponent<MovmientoEnemigo>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Vida>().Daño(_movEnemigo._dañoAtaque);
        }
    }

}
