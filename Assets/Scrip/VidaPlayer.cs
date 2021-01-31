using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VidaPlayer : MonoBehaviour
{
    [SerializeField]
    List<Sprite> _live;
    Image _imgLive;

    [SerializeField]
    float _vida;
    float _vidaMax;

    float cadencia;
    float tiempoDa�os;

    private void Start()
    {
        _imgLive = GameObject.Find("GameController").transform.GetChild(0).transform.GetChild(0).GetComponent<Image>();
        _vidaMax = _vida;
    }
    private void Update()
    {
        cadencia += Time.deltaTime;
    }
    public void Da�o(float d)
    {
        if(cadencia >= tiempoDa�os)
        {
            _vida -= d;
            cadencia = 0;
        }
    }
    void actualizarSprite()
    {
        if(_vida <= 0)
        {
            Destroy(GameObject.Find("GameController"));
            SceneManager.LoadScene(1);
        }
        else if(_vida < _vidaMax/4)
        {
            _imgLive.sprite = _live[0];
        }
        else if (_vida < _vidaMax / 3)
        {
            _imgLive.sprite = _live[1];
        }
        else if (_vida < _vidaMax / 2)
        {
            _imgLive.sprite = _live[2];
        }
        else if (_vida == _vidaMax)
        {
            _imgLive.sprite = _live[3];
        }
    }
}
