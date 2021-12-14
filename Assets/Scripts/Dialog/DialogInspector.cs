using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// код диалога. Иконка выводится по первому символу в файле текстов. Выводится по очередности.
public class DialogInspector : MonoBehaviour
{
    [Header("Иконки персонажей")]
    public Sprite[] PersonImage;
    public GameObject LeftImage;
    public GameObject RightImage;
    [Header("Диалоги персонажей")]
    public GameObject LeftText;
    public GameObject RightText;
    public int TalkId, SpeakId;


    public void newTalk() {
        LeftImage.active = true;
        RightImage.active = true;
        string Talktext = GetComponent<Texts>().TextDialog[SpeakId][TalkId];// достаем фразу из нужного диалога и нужной последовательности
        if (Talktext == "END")// завершаем нашу записку
        {
            LeftText.GetComponentInChildren<Text>().text = "";
            RightText.GetComponentInChildren<Text>().text = "";
            TalkId = 0;
            LeftText.active = false;
            RightText.active = false;
            LeftImage.active = false;
            RightImage.active = false;
            gameObject.active = false;
        }
        else //новая фраза
        {
            if (TalkId % 2 == 0)// говорит левый
            {
                int PersonID = Talktext[0] - '0';
                TalkinParty(LeftImage, LeftText,PersonID);
                StartCoroutine(Sentence(Talktext,LeftText));
                TalkId++;
            }
            else//говорит правый
            {
                int PersonID = Talktext[0] - '0';
                TalkinParty(RightImage, RightText, TalkId); 
                StartCoroutine(Sentence( Talktext, RightText));
                TalkId++;
            }
        }
    }

    private void TalkinParty(GameObject Image,GameObject Text, int PersonID) {
        Text.active = true;
        Image.GetComponentInChildren<Image>().sprite = PersonImage[PersonID];
    }

    IEnumerator Sentence(String text, GameObject Txt) {
        Txt.GetComponentInChildren<Text>().text = "";
        foreach (char letter in text.ToCharArray()) {
            Txt.GetComponentInChildren<Text>().text += letter;
            yield return new WaitForSeconds(0.05f);
        }
       
    }
}
