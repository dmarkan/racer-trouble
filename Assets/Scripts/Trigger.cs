using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player")
        {
         Debug.Log("player hit the trigger");
         StartCoroutine("Mover");
        }
    }     
    IEnumerator Mover() {
        yield return new WaitForSeconds(2f);
        Debug.Log("this is working after 2 seconds");
        //we are moving the world when player collides with trigger
        gameObject.transform.parent.position = new Vector3(0, 0, gameObject.transform.position.z + 300);
    }
}
