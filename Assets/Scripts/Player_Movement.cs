using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;
    public float speed = 40f;
    float move = 0f;
    bool jump = false;
    bool cround = false;
    void Update()
    {
        move = Input.GetAxisRaw("Horizontal") * speed;
        animator.SetFloat("speed",Mathf.Abs(move));
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("isJumpping", true);
        }
        if (Input.GetButtonDown("Cround"))
        {
            cround = true;
        }
        else if (Input.GetButtonUp("Cround"))
        {
            cround = false;
        }
    }
    public void OnLanding()
    {
        animator.SetBool("isJumpping", false);
    }
    public void OnCrouching(bool isCrouching)
    {
        animator.SetBool("isCrouching", isCrouching);
    }
    void FixedUpdate()
    {
        controller.Move(move * Time.fixedDeltaTime, cround, jump);
        jump = false;
    }
}
