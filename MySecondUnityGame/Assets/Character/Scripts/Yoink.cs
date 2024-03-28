using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Yoink : MonoBehaviour
{
    [SerializeField] private GameObject Gate1;
    public int Flower_Count = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("o"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown("g"))
        {
            if (other.tag == "Flower")
            {
                
                Destroy(other.gameObject, 1f);
                Flower_Count++;
            }

        }
        if (Input.GetKeyDown("t") && Flower_Count >= 14)
        {
            if (other.tag == "Shop")
            {
                
                Destroy(Gate1);
                Flower_Count = Flower_Count - 14;
            }
        }

    }

}
