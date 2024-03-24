using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotation_test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Rigidbody rb = GetComponent<Rigidbody>();
        Quaternion rot = Quaternion.Euler(34.2f, 34.6f, 92.0f);
        transform.rotation = rot;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
