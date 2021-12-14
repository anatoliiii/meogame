using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// данный скрипт обеспечивает передвижение вместе с платформой персонажа за счет добавления её в дочерние элементы
public class InPlatform : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.transform.parent = transform;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        collision.transform.parent = null;
    }
}
