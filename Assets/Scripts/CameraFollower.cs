using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    public float speed;
    // za postepeno povecavanje brzine kamere
    public float speeder; 
    // Start is called before the first frame update
    void Start()
    {
        speeder = 4f;
    }

    // Update is called once per frame
    void Update()
    {
          // da bi se postepeno povecavala brzina playera
        if(speeder >= 0) {
        speeder -= Time.deltaTime;
        }       
        if(speeder <= 0 && speed < 50) {
            speed++;
            speeder = 4f;
        }
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
