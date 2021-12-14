using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//просто добавляем +1 хп и удаляем объект
public class HeartUp : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<InfoBar>().Heart++;
            Destroy(gameObject);
        }
    }

}
