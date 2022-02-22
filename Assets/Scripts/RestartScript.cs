using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RestartScript : MonoBehaviour
{
    public Text Scoretext;
    public Text Highscoretext;
    float highscore;
    float score;
    // Start is called before the first frame update
    void Start()
    {
        score = PlayerPrefs.GetFloat("Score");
        highscore = PlayerPrefs.GetFloat("Highscore");
        Scoretext.text = "Score: " + score.ToString();
        Highscoretext.text = "High Score: " + highscore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // void znaci da funkcija ne vraca nista
    public void RestartGame() {
        SceneManager.LoadScene("SampleScene");
    }
    public void MainMenuGame() {
        SceneManager.LoadScene("MainMenu");
    }
}
