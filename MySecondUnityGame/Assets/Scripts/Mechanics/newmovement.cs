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



        Quaternion deltaRotation = Quaternion.Euler(m_EulerAngleVelocity * rotate * Time.deltaTime);

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