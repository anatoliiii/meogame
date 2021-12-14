using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YkazMove : MonoBehaviour
{
    [SerializeField]
    private int distance;
    [SerializeField]
    private int speed;

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance); // переменной записываються координаты мыши по иксу и игрику
        Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition); // переменной - объекту присваиваеться переменная с координатами мыши
        transform.position = Vector3.Lerp(transform.position, objPosition, speed * Time.deltaTime);
    }
}
