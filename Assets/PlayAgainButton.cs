using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayAgainButton : MonoBehaviour
{
    public void OnPlayAgainButtonClicked()
    {
        // Load the main game scene again
        SceneManager.LoadScene("arena");
    }
}