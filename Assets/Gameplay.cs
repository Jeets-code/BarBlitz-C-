using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;
using System.Globalization;
using UnityEngine.SceneManagement;

public class Gameplay : MonoBehaviour
{
    Dictionary<char, KeyCode> chartoKeycode = new Dictionary<char, KeyCode>()
    {
        //Lower Case Letters
    {'a', KeyCode.A},
    {'b', KeyCode.B},
    {'c', KeyCode.C},
    {'d', KeyCode.D},
    {'e', KeyCode.E},
    {'f', KeyCode.F},
    {'g', KeyCode.G},
    {'h', KeyCode.H},
    {'i', KeyCode.I},
    {'j', KeyCode.J},
    {'k', KeyCode.K},
    {'l', KeyCode.L},
    {'m', KeyCode.M},
    {'n', KeyCode.N},
    {'o', KeyCode.O},
    {'p', KeyCode.P},
    {'q', KeyCode.Q},
    {'r', KeyCode.R},
    {'s', KeyCode.S},
    {'t', KeyCode.T},
    {'u', KeyCode.U},
    {'v', KeyCode.V},
    {'w', KeyCode.W},
    {'x', KeyCode.X},
    {'y', KeyCode.Y},
    {'z', KeyCode.Z}

    };

    public TMP_Text output; // Reference to the UI text element
    public int number;
    private char letter;

    public TMP_Text score;
    private char lowercase;
    private string lower;
    private KeyCode randomInput;
    private List<KeyCode> randomKeyCodes = new List<KeyCode>();
    public static int points = 0;
    public int keyCodeIndex = 0;
    private int sequenceLength = 4;
    public static bool level = false;
    public string sequence = "";
    public float timeRemaining = 4;
    public static int lives = 4;
    public static bool punch = false;
    public static bool enemyPunch = false;
    public int round = 1;
    //public AudioSource DefeatSound;
    

    // Start is called before the first frame update
    void Start()
    {

        GenerateSequence();
    }
    void Reset()
    {
        randomKeyCodes.Clear();
        sequence = "";
        timeRemaining = 4;
    }
    void GenerateSequence()
    {
        Reset();
        if (round % 4 == 0)
        {
            sequenceLength++;
            level = true;
        }

        sequence = ""; // Reset the sequence string

        for (int i = 0; i < sequenceLength; i++)
        {
            number = UnityEngine.Random.Range(0, 26);
            letter = Convert.ToChar(number + 65);
            lowercase = Char.ToLower(letter);
            randomInput = chartoKeycode[lowercase];
            sequence = sequence + letter;
            randomKeyCodes.Add(randomInput);
        }

        output.SetText(sequence); // Update the UI text with the sequence
        Debug.Log("Generated Sequence: " + sequence);
    }

    // Update is called once per frame
    void Update()
    {
        if (keyCodeIndex < randomKeyCodes.Count)
        {
            if (Input.GetKeyDown(randomKeyCodes[keyCodeIndex]))
            {
                keyCodeIndex++;

                if (keyCodeIndex >= randomKeyCodes.Count)
                {
                    punch = true;
                    //delay
                    round++;
                    keyCodeIndex = 0;
                    points += 10;
                    score.SetText("" + points);
                    
                    
                    // Generate a new sequence for the next turn
                    GenerateSequence();

                }
            }
        }
        else if (Input.anyKeyDown)
        {
            keyCodeIndex = 0;
        }

        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        }
        else
        {
            enemyPunch = true;
            //delay
            lives -= 1;
            timeRemaining = 4;
        }
        
        if (lives == 0)
        {
            StartCoroutine(PlayDefeatSoundAndLoadScene());
        }
    }
    IEnumerator PlayDefeatSoundAndLoadScene()
    {
        //DefeatSound.Play(); // Play the defeat sound

        // Wait for a delay before loading the scene
        yield return new WaitForSeconds(0.5f); // Adjust the delay time as needed

        PlayerPrefs.SetInt("FinalScore", points);
        PlayerPrefs.Save();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        
        lives = 3;
        points = 0;
        round = 1;
        sequenceLength = 4;
    }

}
