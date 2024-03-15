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

        if (Input.GetKeyDown("g"))
        {
            animator.SetTrigger("Gather");
        }
        if (Input.GetAxis("Vertical") != 0)
        {
            if (Input.GetAxis("Vertical") > 0)
            {
                animator.SetTrigger("Walk");
            }
            if (Input.GetAxis("Vertical") < 0)
            {
                animator.SetTrigger("WalkR");
            }
        }
        else
        {
            animator.SetTrigger("Idle");
        }

    }
    private void resetAllTrigger() {
        animator.ResetTrigger("Gather");
        animator.ResetTrigger("Walk");
        animator.ResetTrigger("WalkR");
        animator.ResetTrigger("Idle");
    }
}
