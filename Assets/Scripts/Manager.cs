using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    public Text HighText;
    float highScore;
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.GetFloat("HighScore") == 0) {
            PlayerPrefs.SetFloat("HighScore", 0);
            highScore = PlayerPrefs.GetFloat("Highscore");
            HighText.text = "High Score: " + highScore.ToString();
        } else {
            //PlayerPrefs.GetFloat("Highscore");
            highScore = PlayerPrefs.GetFloat("Highscore");
            HighText.text = "High Score: " + highScore.ToString();
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartGame() {
        SceneManager.LoadScene("SampleScene");
    }
}
