/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Movement_Controller : MonoBehaviour
{
    public float speed = 50f;
    public float standardspeed = 50f;
    public float rotationspeed = 10000f;
    [SerializeField]private Animator animator;
    private float vertical;
    private float horizontal;
    private float rotate;
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
        rotate = Input.GetAxis("Rotate");

        Vector3 movement = new Vector3(0.0f, 0.0f, vertical).normalized * speed;
        // Calculate the new position of the object
        Vector3 newPosition = rb.position + movement * Time.fixedDeltaTime;
        // Use Vector3.Lerp for a smooth transition to the new position
        rb.MovePosition(Vector3.Lerp(rb.position, newPosition, 0.5f)); 
        transform.Rotate((transform.up * rotate) * rotationspeed * Time.deltaTime);

        
        
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Gathering"))
        {
            speed = 0f;
        }
        else
        {
            speed = standardspeed;
        }
    }
    private void FixedUpdate()
    {

    }
}
*/