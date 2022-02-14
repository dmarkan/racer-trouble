using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    public float speed;
    private void OnTriggerEnter(Collider other) {
        // destroyer unistava sve obstacle koje dotakne
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(other.gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        speed = 3;
    }

    // Update is called once per frame
    void Update()
    {
        // da bi se destroyer kretao za playerom
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
