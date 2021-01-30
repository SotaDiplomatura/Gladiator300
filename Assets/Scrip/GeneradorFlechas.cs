using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorFlechas : MonoBehaviour
{
    [SerializeField]
    GameObject _flecha;
    public float time;
    void Start()
    {
        StartCoroutine("Instanciar");
    }
    IEnumerator Instanciar()
    {
        time = Random.Range(0.5f, 2f);
        Instantiate(_flecha, transform.position, transform.rotation);
        yield return new WaitForSeconds(time);
        StartCoroutine("Instanciar");
    }
}
