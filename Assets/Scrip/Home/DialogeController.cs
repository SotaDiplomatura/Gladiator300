using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogeController : MonoBehaviour
{

    public GameObject _panel;
    public List<string> _Dialogos = new List<string>();
    public int _numeroLista;
    public Text _text;
    bool primeraVez = false;

    void Start()
    {
        if(PlayerPrefs.GetInt("PrimeraVez") != 1)
        {
            primeraVez = true;
        }
        else
        {
            primeraVez = false;
        }
        if(primeraVez)
        {
            _Dialogos.Add("What the hell are you looking at, asshole? The emperor is waiting for you and you should not make him angry.");
            PlayerPrefs.SetInt("PrimeraVez", 1);
        }

        _Dialogos.Add("Once I saw one like you, I think he led a country called América… I said led…");
        _Dialogos.Add("The emperor is important, we live in a society after all.");
        _Dialogos.Add("I had a woman, you know? She said she'd wait for me… but I met Simba… hahaha");
        _Dialogos.Add("Do you know something strange, boy? I just saw an old man and his nephew disappear in front of me in a green puddle. Crazy, don´t you think? Too much work for today.");
        _Dialogos.Add("A man told me once that there was a plumber looking for a peach. It was a great meal for my pet.");
        _Dialogos.Add("Some devilish rabbits were here and caused a great destruction. If I catch them again, I´ll behead them!");
        _Dialogos.Add("Shit! What is a snake doing in my boot?");
        _Dialogos.Add("It is said that if you follow a path made of bread in the forest you will find a chocolate house! But don´t worry, you won´t leave this place so you won't have to check it.");
        _Dialogos.Add("What a great combat, brother! Wait, it wasn't you. I've got confused.");
        _Dialogos.Add("Among all the weapons do you choose the boomerang? Who do you think you are, that guy, Link?");
        _Dialogos.Add("Be careful with the arrows. If they hit you on the knees you must stop your adventures..");
        _Dialogos.Add("If all roads lead to Rome, how do you get out of Rome?");
        _Dialogos.Add("Have you met Simba, yet? He 's working. If you meet him, he will probably eat you. Good luck!");
        _Dialogos.Add("Do you know the definition of madness? Seriously, because I don´t know.");
        _Dialogos.Add("A foreigner told me once about ramen. He had yellow hair and it looks like an orange, but he said it was delicious. It was the last thing he ate.");
       


        if (SceneManager.GetActiveScene().buildIndex == 1)
           
        {
            if (primeraVez)
            {
                _numeroLista = 0;
                _text.text = _Dialogos[_numeroLista].ToString();
                _Dialogos.Remove(_Dialogos[_numeroLista]);
            }
            else
            {
                _numeroLista = Random.Range(1, _Dialogos.Count);
                _text.text = _Dialogos[_numeroLista].ToString();
            }
        }
        

    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            _panel.SetActive(false);
        }
    }
}
