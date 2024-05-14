using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Punch : MonoBehaviour
{
    //public Animator PunchAnim;
    public GameObject RightHand;
    public GameObject LeftHand;

    public Animator leftHandAnimator;
    public Animator rightHandAnimator;
    public AudioSource PunchSound;

    private bool isLeftHandPunching = true;

    // Start is called before the first frame update
    void Start()
    {
        leftHandAnimator = LeftHand.GetComponent<Animator>();
        rightHandAnimator = RightHand.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Gameplay.punch)
        //PunchAnim.Play("LefthandJab");
        {
            if (isLeftHandPunching)
            {
                leftHandAnimator.Play("LefthandJab");
            }
            else
            {
                rightHandAnimator.Play("RightHandJab");
            }

            PunchSound.Play();
            isLeftHandPunching = !isLeftHandPunching; // Toggle punching hand
            Gameplay.punch = false;
            
        }

    }
}
