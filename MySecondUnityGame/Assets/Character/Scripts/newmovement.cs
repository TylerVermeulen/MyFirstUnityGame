using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Movement_Controller : MonoBehaviour
{
    private float speed = 5f;
    public float standardspeed = 5f;
    public float rotationSpeed = 5f;

    [SerializeField] private Animator animator;
    private float vertical;
    private float horizontal;
    private float rotate;
    private Rigidbody rb;
    Vector3 m_EulerAngleVelocity;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        m_EulerAngleVelocity = new Vector3(0, 100, 0);
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void FixedUpdate()
    {
        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");
        rotate = Input.GetAxis("Rotate");

        Vector3 move = new Vector3(horizontal, 0f, vertical).normalized * speed;
        rb.MovePosition(rb.position + transform.TransformDirection(move) * Time.deltaTime);

        //// Calculate movement based on input
        //Vector3 movement = new Vector3(horizontal, 0.0f, vertical).normalized * speed;

        //// Calculate the new position of the object
        //Vector3 newPosition = rb.position + movement * Time.fixedDeltaTime;

        //// Calculate the rotation amount based on horizontal input
        //Quaternion rotation = Quaternion.Euler(0.0f, rotate * rotationSpeed * Time.deltaTime, 0.0f);

        //// Rotate the forward direction of the object
        //Vector3 rotatedForward = rotation * transform.forward;

        //// Only move if there is input
        //if (movement.magnitude > 0)
        //{
        //    // Calculate the new position of the object
        //    newPosition += rotatedForward * Time.fixedDeltaTime;
        //}

        Quaternion deltaRotation = Quaternion.Euler(m_EulerAngleVelocity * rotate * Time.deltaTime);
        // Use MovePosition for a smooth transition to the new position
        //rb.MovePosition(Vector3.Lerp(rb.position, transform.TransformDirection(newPosition), 0.5f));
        //transform.Translate(newPosition);
        rb.MoveRotation(rb.rotation * deltaRotation);

        

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Gathering"))
        {
            speed = 0f;
        }
        else
        {
            speed = standardspeed;
        }
    }

}