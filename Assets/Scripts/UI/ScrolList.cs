 using System;
 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//вешается на общую панель всех свитокв в HUD. контролирует их активность и нажатия
public class ScrolList : MonoBehaviour
{
    public Image[] ImageList;
    [SerializeField]
    public bool[] ImageListActive;
    public Character Character;

    private void Awake()
    {
        ImageListActive = new bool[ImageList.Length];//присваиваем размер активного поля к размеру общего количества свитков
    }

    private void Start() {
        Character = Character == null ? GetComponent<Character>() : Character;
    }

    private void Update()
    {
        for(int i = 0; i < ImageList.Length; i++)
        {
            if (ImageListActive[i]) ImageList[i].color = Color.white;// включаем нужные свитки
            else ImageList[i].color = Color.gray;
        }
    }

    public void ActiveOn() {
        Character.move = false;
        gameObject.active = true;
    }
    public void ActiveOff() {
        Character.move = true;
        gameObject.active = false;
    }
}
