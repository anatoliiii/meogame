using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Скрипт свитка в игре. Вешается на сам свиток. Передает значения номера свитка и номера текста. Так-же указать вспомогательный текст при подходе.

public class ScrolItem : MonoBehaviour
{
    [Header("Панель свитка")]
    public int speakId;
    public GameObject ScrolPanel;
    private bool player=false;
    [SerializeField]
    public GameObject ScrolList;
    public Character Character;

    private void Start() {
        Character = Character == null ? GetComponent<Character>() : Character;
    }

    private void OnTriggerEnter2D(Collider2D collision) // при входе открывается вспомогательное окно
    {
        if (collision.tag == "Player")
        {
            player = true;
        }
    }
    public void scrol()
    {
        if (player) // при нажатии F открывается записка, уходит вспомогательное окно
        {
            ScrolPanel.GetComponent<ScrolScript>().speakingId = speakId;
            ScrolPanel.GetComponent<ScrolScript>().newTalk();
            ScrolPanel.active = true;
            ScrolList.active = true;
            ScrolList.GetComponent<ScrolList>().ImageListActive[speakId] = true;
            ScrolList.active = false;
            Character.move = false;
            Destroy(gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)// при выходе из объекта вспомогательное окно скрывается
    {
        if (collision.tag == "Player")
        {
            player = false;
        }
    }
}
