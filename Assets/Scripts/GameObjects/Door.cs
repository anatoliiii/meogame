using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// просто убираем дверь, если у персонажа есть ключ, атак-же если его нету показываем подсказку
public class Door : MonoBehaviour
{
    [SerializeField]
    private GameObject HelpPanel;
    private bool player = false;
    private GameObject Player;
    public Text HelpPanelText;
    public string HelpPanelInText;

    private void Start()
    {
        Player = GameObject.FindWithTag("Player");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (collision.GetComponent<InfoBar>().Key)
            {
                collision.GetComponent<InfoBar>().Key = false;
                Destroy(gameObject);
            }
            else
            {
                player = true;
                HelpPanelText.text = HelpPanelInText;
                HelpPanel.active = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            HelpPanel.active = false;
            player = false;
        }
    }
}
