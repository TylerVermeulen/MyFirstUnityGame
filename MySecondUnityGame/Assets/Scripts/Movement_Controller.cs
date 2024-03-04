using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement_Controller : MonoBehaviour
{
    [SerializeField]private float speed = 3f;
    [SerializeField]private float rotationspeed = 10000f;
    [SerializeField]private Animator animator;

    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 positionUpdate = transform.position + Input.GetAxis("Vertical") * transform.forward * speed * Time.deltaTime;
        transform.position = positionUpdate;
        transform.Rotate(new Vector3(0, Input.GetAxis("Horizontal") * rotationspeed * Time.deltaTime, 0));


        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Gathering"))
        {
            speed = 0f;
        }
        else
        {
            speed = 3f;
        }
        //float horizontal = Input.GetAxis("Horizontal") * rotationspeed;
        // float vertical = Input.GetAxis("Vertical") * speed;

        // horizontal *= Time.deltaTime;
        // vertical *= Time.deltaTime;

        // transform.Translate(0, 0, vertical);
        //  transform.Rotate(0, horizontal, 0);
        //if ()
        {
       
        }
    }
}
