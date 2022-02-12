using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(0,0,speed);
    }

    // Update is called once per frame
    void Update()
    {
    if (Input.GetKey(KeyCode.LeftArrow) && transform.position.x>-3.5f) {
   transform.Translate(Vector3.left * speed * Time.deltaTime);
}
    if (Input.GetKey(KeyCode.RightArrow) && transform.position.x<3.5f) {
   transform.Translate(Vector3.right * speed * Time.deltaTime);
}
    }
}
