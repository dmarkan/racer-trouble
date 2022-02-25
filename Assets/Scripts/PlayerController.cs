using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//dodajemo zbog nove scene
using UnityEngine.SceneManagement;
//da bi ubacili text koji se nalazi u UI
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Text ScoreText;
    public Text gameOverText;
    Touch touch;

    // za postepeno povecavanje brzine
    public float speeder;

    public float Score;
    public float speed;
    // pravimo boolean isGameover da bi zaustvaili score da ne ide vise kada player naleti na enemyja
    public bool isGameover;
    public float speedmodifier;
    // Start is called before the first frame update
    // awake funkcija je funkcija koja se pokrece pre start funkcije
    private void Awake() {
        isGameover = false;
        Score = 0;
        //za snimanje scora u highscore koji ce biti smesten na device
        //ako je score == 0, smestamo 0 u highscore
        if(PlayerPrefs.GetFloat("Highscore") == 0) {
            PlayerPrefs.SetFloat("Highscore", 0);
        }
        //SetFloat zato sto je score Float
        PlayerPrefs.SetFloat("Score", Score);
    }
    void Start()
    {   
        speeder = 4f;
        gameOverText.enabled = false;
        speedmodifier = 0.01f;
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

        // dokle god nije gameover povecavace se score
        if(isGameover == false) {
        Score++;
        }
        ScoreText.text = "Score: " + Score.ToString();
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
    //kada player dotakne obstacle da se unisti i da ode u drugu scenu
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Enemy") {
            isGameover = true;
            StartCoroutine("StopandWait"); 
            GetComponent<MeshRenderer>().enabled = false; //da iskljucimo meshrenderer komponentu na playeru
            gameObject.GetComponentInChildren<TrailRenderer>().enabled = false; //da disabliramo i trail
            //da enabliramo game over text jer smo ga disablovali u startu
            gameOverText.enabled = true; 
            //ako je trenutni score veci od highscora, smesticemo ga kao novi highscore
            if (PlayerPrefs.GetFloat("Highscore")< Score) {
                PlayerPrefs.SetFloat("Highscore", Score);
                PlayerPrefs.SetFloat("Score", Score);
            } else {
                PlayerPrefs.SetFloat("Score", Score);
            }
        }
    }
    IEnumerator StopandWait() {
        yield return new WaitForSeconds(2f); //da sacekamo 2 sekunde preko nego sto se iskljuci meshrenderer na playeru
        SceneManager.LoadScene("Restart Menu");
    }
}
