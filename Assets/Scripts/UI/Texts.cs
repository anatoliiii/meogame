using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Сдесь пишем то, что выводится на свитке или в диалогах. каждый массив new string это новая записка, каждая строга в ней, новая страница? в конце обязательно END
public class Texts : MonoBehaviour
{
    public string[][] TextScrol =
    {
        new string[] {
        "Страница 1 Тут тидет наш лор",
        "Страница 2 Тут тидет наш лор",
        "Страница 3 Тут тидет наш лор",
        "END", // втсавлять в конце!!!!
        }
        ,
        new string[]
        {
            "Другой диалог",
            " C другими персонажами",
            "END",
        }
    };

    public string[][] TextDialog =//первая цифра отвечает за персонажа, который сейчас говорит
    {
        new string[] {
        "1 Тут тидет наш лор",
        "2 Тут тидет наш лор",
        "3 Тут тидет наш лор",
        "END", // втсавлять в конце!!!!
        }
        ,
        new string[]
        {
            "Другой диалог",
            " C другими персонажами",
            "END",
        }
    };

}

