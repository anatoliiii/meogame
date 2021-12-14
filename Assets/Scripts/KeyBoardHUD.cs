using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBoardHUD : MonoBehaviour {
    public ScrolScript ScrolScript;
    public ScrolList ScrolList;
    public ScrolItem Item;
    public KeyUp KeyUp;
    public Gun Gun;
    // Start is called before the first frame update
    void Start()
    {
        ScrolScript = ScrolScript == null ? GetComponent<ScrolScript>() : ScrolScript;
        ScrolList = ScrolList == null ? GetComponent<ScrolList>() : ScrolList;
        Item = Item == null ? GetComponent<ScrolItem>() : Item;
        KeyUp = KeyUp == null ? GetComponent<KeyUp>() : KeyUp;
        Gun = Gun == null ? GetComponent<Gun>() : Gun;
    }

    // Update is called once per frame
    void Update()
    {
        if (ScrolList != null || ScrolScript != null) {
            if (Input.GetButton("Cancel")) {
                ScrolList.ActiveOff();
                ScrolScript.gameObject.active = false;
            }
            if (Input.GetKey(KeyCode.I)) {
                ScrolList.ActiveOn();
            }
            if (Input.GetKeyDown(KeyCode.Space)){
                ScrolScript.newTalk();
            }
        }
        if (Item!= null || KeyUp != null ) 
        {
            if (Input.GetKeyUp(KeyCode.F)) 
            {
                Item.scrol();
                KeyUp.Key();
            }
        }
        if (Gun != null)
        {
            if (Input.GetKeyUp(KeyCode.E))
            {
                Gun.NewGun();
            }
        }
    }
}
