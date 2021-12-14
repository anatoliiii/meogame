using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBoardDialog : MonoBehaviour
{    public DialogInspector DialogInspector;
    // Start is called before the first frame update
    void Start()
    {
        DialogInspector = DialogInspector == null ? GetComponent<DialogInspector>() : DialogInspector;

    }

    // Update is called once per frame
    void Update()
    {
        if (DialogInspector != null) {
            if (Input.GetButtonDown("Submit")) {
                DialogInspector.newTalk();
            }
        }
    }
}
