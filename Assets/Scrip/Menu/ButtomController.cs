using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtomController : MonoBehaviour
{

    public GameObject _Ajustes;


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

    public void Exit()
    {

        Application.Quit();
    }
}
