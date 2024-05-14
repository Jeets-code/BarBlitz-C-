using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class EndMenu : MonoBehaviour
{
    public TMP_Text finalScoreText;

    void Start()
    {
        int finalScore = PlayerPrefs.GetInt("FinalScore", 0); // Retrieve the final score from PlayerPrefs
        finalScoreText.SetText("Score: " + finalScore); // Display the final score
    }

    public void MainMenu ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }

    public void QuitGame ()
    {
        Application.Quit();
    }
}
