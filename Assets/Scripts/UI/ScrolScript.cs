using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrolScript : MonoBehaviour
{
    public Text talkText;
    public Text talkNumber;
    public int talkId = 0;
    public int speakingId = 0;
    int NumberId;
    public Character Character;

    private void Start() {
        Character = Character == null ? GetComponent<Character>() : Character;
    }

    public void newTalk() // новая страница или начало текста
    {
        NumberId = speakingId + 1;
        talkNumber.text = "Записка №" + NumberId;
        string text = GetComponent<Texts>().TextScrol[speakingId][talkId];
        if (text == "END")// завершаем нашу записку
        {
            EndTalk();
        }
        else //новая страница
        {
            talkText.text = text;
            talkId++;
        }

    }

    public void EndTalk()// кнопка завершения страницы
    {
        talkText.text = "";
        talkId = 0;
        gameObject.active = false;
        Character.move = true;
    }
}
