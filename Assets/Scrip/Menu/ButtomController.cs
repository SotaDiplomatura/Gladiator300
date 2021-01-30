using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtomController : MonoBehaviour
{

    public GameObject _Ajustes;
    public GameObject _Sonido;
    public GameObject _Tutorial;


    void Start()
    {

    }


    public void StartGame()
    {
        SceneManager.LoadScene((1), LoadSceneMode.Single);
    }
    public void AjustesMenu()
    {
        if (_Ajustes.activeSelf)
        {
            _Ajustes.SetActive(false);
        }
        else
        {
            _Ajustes.SetActive(true);
        }


    }
    public void SonidoControl()
    {
        if (_Sonido.activeSelf)
        {
            _Sonido.SetActive(false);
        }
        else
        {
            _Sonido.SetActive(true);
        }


    }
    public void TutorialControl()
    {
        if (_Tutorial.activeSelf)
        {
            _Tutorial.SetActive(false);
        }
        else
        {
            _Tutorial.SetActive(true);
        }


    }

    public void Exit()
    {

        Application.Quit();
    }
}
