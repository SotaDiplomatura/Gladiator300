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

    public float _vida;
    public float _vidaMax;

    float cadencia;
    float tiempoDaños;

    private void Start()
    {
        _imgLive = GameObject.Find("GameController").transform.GetChild(0).transform.GetChild(0).GetComponent<Image>();
        _vidaMax = _vida;
    }
    private void Update()
    {
        cadencia += Time.deltaTime;
        actualizarSprite();
    }
    public void Daño(float d)
    {
        if(cadencia >= tiempoDaños)
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
            Destroy(gameObject);
        }
        else if(_vida < _vidaMax * 0.25f)
        {
            _imgLive.sprite = _live[0];
        }
        else if (_vida < _vidaMax * 0.5f)
        {
            _imgLive.sprite = _live[1];
        }
        else if (_vida < _vidaMax * 0.75f)
        {
            _imgLive.sprite = _live[2];
        }
        else if (_vida == _vidaMax)
        {
            _imgLive.sprite = _live[3];
        }
    }
}
