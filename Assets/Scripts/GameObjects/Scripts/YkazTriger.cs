using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YkazTriger : MonoBehaviour
{
    [SerializeField]
    private GameObject circle;


    private void OnMouseDown()
    {
        if (circle.active)
        {
            circle.active = false;
        }
        else circle.active = true;
    }
}
