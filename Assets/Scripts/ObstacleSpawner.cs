using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] obstacle;
    // Start is called before the first frame update
    void Start()
    {
        //da damo interval na koliko ce se spawnovati obstacles
        InvokeRepeating("Spawner", 0.5f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
     //da pomeramo i obstacleSpawner napred kao i kameru
        transform.Translate(Vector3.forward * 50 * Time.deltaTime);
    }
    public void Spawner() {
    //da bi spawnovao obstacles random
    Instantiate(obstacle[Random.Range(0,2)], new Vector3(Random.Range(-3f,3f), transform.position.y, transform.position.z), Quaternion.identity); // -random number between 0 and 2, quaternion znaci da mu dajemo default rotaciju kao i na svim obstacleima
    }
}
