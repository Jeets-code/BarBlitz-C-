using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public Animator DamageAnim;
    // Start is called before the first frame update
    void Start()
    {
        DamageAnim = GetComponent<Animator>();
        DamageAnim.Play("healthy");

    }

    // Update is called once per frame
    void Update()
    {
        if(Gameplay.lives==3){
            
        DamageAnim.Play("healthy");

        }
        if(Gameplay.lives==2){
            
        DamageAnim.Play("damage");

        }
        if(Gameplay.lives==1){
            
        DamageAnim.Play("deathbed");

        }

    }

}
