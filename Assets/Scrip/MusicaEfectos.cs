using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class MusicaEfectos : MonoBehaviour
{
    [SerializeField]
    AudioMixer _auMixer;

    [SerializeField]
    Slider _sliderVolumen;


    void Start()
    {
        _sliderVolumen.minValue = -60;
        _sliderVolumen.maxValue = 20;
        _sliderVolumen.value = 0;
    }

    void Update()
    {
        _auMixer.SetFloat("Master", _sliderVolumen.value);
    }
}
