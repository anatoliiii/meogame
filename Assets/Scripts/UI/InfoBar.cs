using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// в этом скрипте написанна логика нашей информационной панели персонажа
public class InfoBar : MonoBehaviour
{
    public int Heart;// наши жизни
    public GameObject[] HeartBar;
    public bool Key;
    public GameObject KeyImage;// ключь для прохода уровня
    private void Update()
    {
        for (int i = 0; i < 3; i++)// показываем нуные сердечки
        {
            if (i < Heart) HeartBar[i].active = true;
            else HeartBar[i].active = false;
        }
        if (Key) KeyImage.active = true;//показываем ключик, если он есть
        else KeyImage.active = false;
    }

}
