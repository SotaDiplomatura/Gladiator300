using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PerdurarEntreEscenas : MonoBehaviour
{
    bool creado = false;

    void Awake()
    {
        PlayerPrefs.SetInt("scemaAntigua", 0);
        if (!creado)
        {
            DontDestroyOnLoad(this.gameObject);
            creado = true;
        }
    }
    private void Update()
    {
        if(SceneManager.GetActiveScene().buildIndex == 7)
        {
            Destroy(gameObject);
        }
    }
}
enum Salas
{
    Pequeña,Media,Grandes
}