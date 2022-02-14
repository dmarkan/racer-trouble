using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Touch touch;
    public float speed;
    public float speedmodifier;
    // Start is called before the first frame update
    void Start()
    {
        speedmodifier = 0.01f;
    }

    // Update is called once per frame
    void Update()
    {
        //da bi se player pomerao levo i desno pomocu strelica na tastaturi
    if (Input.GetKey(KeyCode.LeftArrow) && transform.position.x>-3.5f) {
   transform.Translate(Vector3.left * speed * Time.deltaTime);
}
    if (Input.GetKey(KeyCode.RightArrow) && transform.position.x<3.5f) {
   transform.Translate(Vector3.right * speed * Time.deltaTime);
}
    //da bi se player pomerao na touch screen   -   testirati posle na telefonu, napraviti apk tako sto se ide na file, build settings, pa na android
    if(Input.touchCount > 0 && transform.position.x>-3.5f && transform.position.x<3.5f) {
        touch = Input.GetTouch(0);
        transform.Translate(touch.deltaPosition.x * speedmodifier,0,0);
    } else if(transform.position.x > 3.5f) {
        transform.position = new Vector3(3.49f, transform.position.y,transform.position.z);
    } else if(transform.position.x < -3.5f) {
        transform.position = new Vector3(-3.49f, transform.position.y, transform.position.z);
    }
    transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
