using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//вешается на каждый свиток в HUD, нужен чтоб открывать нужный свиток

public class ScrolListItem : MonoBehaviour
{
    [SerializeField]
    private int ScrolId;
    [SerializeField]
    private GameObject ScrolList;
    [SerializeField]
    private GameObject ScrolPanel;

    public Character Character;

    private void Start() {
        Character = Character == null ? GetComponent<Character>() : Character;
    }

    public void Click()
    {
        if (GetComponentInParent<ScrolList>().ImageListActive[ScrolId] && Character != null)
        {
            // Debug.Log(ScrolId);
            ScrolPanel.GetComponent<ScrolScript>().speakingId = ScrolId;
            ScrolPanel.GetComponent<ScrolScript>().newTalk();
            ScrolPanel.active = true;
            ScrolList.active = false;
            Character.move = false;
        }
    }
}
