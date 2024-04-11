using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animationscript : MonoBehaviour
{
    [SerializeField] private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame

    void Update()
    {

        resetAllTrigger();

        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");
        if (Input.GetKeyDown("g"))
        {
            animator.SetTrigger("Gather");
        }
        if (v != 0)
        {
            if( v > 0)
            {

                animator.ResetTrigger("WalkBack");
                animator.ResetTrigger("Idle");
                animator.ResetTrigger("WalkLeft");
                animator.ResetTrigger("WalkRight");
                animator.ResetTrigger("StrafeForwardLeft");
                animator.ResetTrigger("StrafeForwardRight");
                animator.ResetTrigger("StrafeBackLeft");
                animator.ResetTrigger("StrafeBackRight");
                animator.SetTrigger("WalkForward");
            }
            if (v < 0)
            {
                animator.ResetTrigger("WalkForward");

                animator.ResetTrigger("Idle");
                animator.ResetTrigger("WalkLeft");
                animator.ResetTrigger("WalkRight");
                animator.ResetTrigger("StrafeForwardLeft");
                animator.ResetTrigger("StrafeForwardRight");
                animator.ResetTrigger("StrafeBackLeft");
                animator.ResetTrigger("StrafeBackRight");
                animator.SetTrigger("WalkBack");

            }
        }
        if (h != 0)
        {
            if (h > 0)
            {
                animator.ResetTrigger("WalkForward");
                animator.ResetTrigger("WalkBack");
                animator.ResetTrigger("Idle");
                animator.ResetTrigger("WalkLeft");

                animator.ResetTrigger("StrafeForwardLeft");
                animator.ResetTrigger("StrafeForwardRight");
                animator.ResetTrigger("StrafeBackLeft");
                animator.ResetTrigger("StrafeBackRight");
                animator.SetTrigger("WalkRight");
            }
            if (h < 0)
            {
                animator.ResetTrigger("WalkForward");
                animator.ResetTrigger("WalkBack");
                animator.ResetTrigger("Idle");

                animator.ResetTrigger("WalkRight");
                animator.ResetTrigger("StrafeForwardLeft");
                animator.ResetTrigger("StrafeForwardRight");
                animator.ResetTrigger("StrafeBackLeft");
                animator.ResetTrigger("StrafeBackRight");
                animator.SetTrigger("WalkLeft");
            }
        }
        if (v != 0 && h != 0)
        {
            if (v > 0 && h > 0)
            {
                animator.ResetTrigger("WalkForward");
                animator.ResetTrigger("WalkBack");
                animator.ResetTrigger("Idle");
                animator.ResetTrigger("WalkLeft");
                animator.ResetTrigger("WalkRight");
                animator.ResetTrigger("StrafeForwardLeft");
                animator.ResetTrigger("StrafeForwardRight");
                animator.ResetTrigger("StrafeBackLeft");
                animator.SetTrigger("StrafeForwardRight");
            }
            if (v > 0 && h < 0)
            {
                animator.ResetTrigger("WalkForward");
                animator.ResetTrigger("WalkBack");
                animator.ResetTrigger("Idle");
                animator.ResetTrigger("WalkLeft");
                animator.ResetTrigger("WalkRight");
                animator.ResetTrigger("StrafeForwardLeft");
                animator.ResetTrigger("StrafeForwardRight");

                animator.ResetTrigger("StrafeBackRight");
                animator.SetTrigger("StrafeForwardLeft");
            }
            if (v < 0 && h > 0)
            {
                animator.ResetTrigger("WalkForward");
                animator.ResetTrigger("WalkBack");
                animator.ResetTrigger("Idle");
                animator.ResetTrigger("WalkLeft");
                animator.ResetTrigger("WalkRight");
                animator.ResetTrigger("StrafeForwardLeft");
                animator.ResetTrigger("StrafeForwardRight");
                animator.ResetTrigger("StrafeBackLeft");

                animator.SetTrigger("StrafeBackRight");
            }
            if (v < 0 && h < 0)
            {
                animator.ResetTrigger("WalkForward");
                animator.ResetTrigger("WalkBack");
                animator.ResetTrigger("Idle");
                animator.ResetTrigger("WalkLeft");
                animator.ResetTrigger("WalkRight");
                animator.ResetTrigger("StrafeForwardLeft");
                animator.ResetTrigger("StrafeForwardRight");

                animator.ResetTrigger("StrafeBackRight");
                animator.SetTrigger("StrafeBackLeft");
            }
        }
        if (h==0 && v == 0)
        {
            animator.SetTrigger("Idle");
        }

    }
    private void resetAllTrigger() {
        animator.ResetTrigger("Gather");
        animator.ResetTrigger("WalkForward");
        animator.ResetTrigger("WalkBack");
        animator.ResetTrigger("Idle");
        animator.ResetTrigger("WalkLeft");
        animator.ResetTrigger("WalkRight");
        animator.ResetTrigger("StrafeForwardLeft");
        animator.ResetTrigger("StrafeForwardRight");
        animator.ResetTrigger("StrafeBackLeft");
        animator.ResetTrigger("StrafeBackRight");
    }
}
