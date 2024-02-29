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



        if (Input.GetKeyDown("g"))
        {
            Debug.Log("pressed");
            animator.SetTrigger("Gather");
        }
      
    }
}
