using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class Jump : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    private float buttontime = 0.3f;
    public float jumpamount = 5;
    float jumptime;
    bool jumping = false;
    bool onFloor;
    public float gravityScale = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "floor")
        {
            onFloor = true;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && onFloor) 
        {
            onFloor = false;
            jumping = true;
            jumptime = 0;
        }
        if (jumping == true)
        {
            rb.velocity = new Vector3(0, jumpamount, 0);
            rb.AddForce(Physics.gravity * (gravityScale - 1) * rb.mass);
            jumptime += Time.deltaTime;
        }
        if ( jumptime > buttontime)
        {
            jumping = false;
        }
    }
}
