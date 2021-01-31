using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PerdurarEntreEscenas : MonoBehaviour
{
    bool creado = false;
    [SerializeField]
    bool player = false;
    GameObject _player;

    GameObject _puerta;

    void Awake()
    {
        if (player == true)
        {
            _puerta = GameObject.Find("Entrada").GetComponent<GameObject>();
            _player = GetComponent<GameObject>();
        }
        if(!creado)
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
        if (player == true)
        {
            PlayerPrefs.SetInt("ScenaNueva", SceneManager.GetActiveScene().buildIndex);
            if (PlayerPrefs.GetInt("ScenaNueva") != PlayerPrefs.GetInt("scemaAntigua"))
            {
                _player.transform.position = _puerta.transform.position;
                PlayerPrefs.SetInt("scemaAntigua", (PlayerPrefs.GetInt("ScenaNueva")));
            }
        }
    }
}
enum Salas
{
    Pequeña,Media,Grandes
}