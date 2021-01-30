using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtomController : MonoBehaviour
{

    public Sprite _onClick;
    public Sprite _default;


    void Start()
    {

    }


    public void MyButtonClickFunction(Image myImageToUpdate)
    {
        myImageToUpdate.sprite = _onClick;
}




}
