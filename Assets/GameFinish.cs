using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;

public class GameFinish : MonoBehaviour
{
    public TMP_Text finalScore;
    // Start is called before the first frame update
    void Start()
    {
        finalScore.SetText("Score: " + Gameplay.points);
    }
}
