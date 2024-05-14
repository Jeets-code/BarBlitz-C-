using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class enemyPunch : MonoBehaviour
{
    public Animator EnemyPunch;
    public AudioSource DefeatSound;

    // Start is called before the first frame update
    void Start()
    {
        EnemyPunch = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Gameplay.enemyPunch==true){
        EnemyPunch.Play("EnemyPunch");
        Gameplay.enemyPunch = false;
        DefeatSound.Play();

        }

    }
}
