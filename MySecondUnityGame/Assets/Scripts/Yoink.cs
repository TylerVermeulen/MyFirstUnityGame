using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yoink : MonoBehaviour
{
    [SerializeField]private GameObject Flower;
    // Start is called before the first frame update
    void Start()
    {
        Flower = GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown("g"))
        {
            if (other.tag == "Flower")
            {
                Destroy(other.gameObject,1f);
            }

        }
    }
}
