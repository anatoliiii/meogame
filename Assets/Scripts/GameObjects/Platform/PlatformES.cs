using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// платформа дивжется из точки а в точку б
public class PlatformES : MonoBehaviour
{
    public GameObject PEnd;
    public GameObject PStart;
    private bool Triger=true;
    private bool TrigerOn;
    public float speed;
    

    void Update() {//проверяем напралвение движения
        if(!TrigerOn && Triger) {
            Move(PEnd.transform.position);
        }
        else if(!TrigerOn && !Triger) {
            Move(PStart.transform.position);
            
        }
    }

    public void Move(Vector3 transformPosition){//функция передвижения в зависимости от того, куда идет
        transform.position = Vector3.MoveTowards(transform.position, transformPosition, speed * Time.deltaTime);
        if (transform.position == transformPosition) {
            TrigerOn = true;
            Invoke("NoTrigger", 3.0f);
        }
 
     }

    public void NoTrigger() {//не даем скрипту много раз вызывать Inove
        Triger = !Triger;
        TrigerOn = false;
    }
}
