using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement_Controller : MonoBehaviour
{
    public float speed = 50f;
    public float standardspeed = 50f;
    public float rotationspeed = 10000f;
    [SerializeField]private Animator animator;
    private float vertical;
    private float horizontal;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 positionUpdate = transform.position + Input.GetAxis("Vertical") * transform.forward * speed * Time.deltaTime;
        // transform.position = positionUpdate;
        // transform.Rotate(new Vector3(0, Input.GetAxis("Horizontal") * rotationspeed * Time.deltaTime, 0));
        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");

        rb.AddForce(transform.forward * vertical * speed * Time.deltaTime);
        transform.Rotate((transform.up * horizontal) * rotationspeed * Time.deltaTime);

        /*
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Gathering"))
        {
            speed = 0f;
        }
        else
        {
            speed = standardspeed;
        }*/
    }
    private void FixedUpdate()
    {

    }
}
