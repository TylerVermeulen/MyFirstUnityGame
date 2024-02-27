using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animationscript : MonoBehaviour
{
    [SerializeField] private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        vector
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G)) 
        {
            Debug.Log("pressed");
            animator.SetBool(, true);
        }
        else
        {
            animator.SetBool(yoink, false);
        }
    }
}
