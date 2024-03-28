using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class skyboxchange : MonoBehaviour
{
    public Material skybox;
    public Material otherSkyBox;
    [SerializeField] private GameObject biglamp;
    Light sun;
    // Start is called before the first frame update
    void Start()
    {
        sun = biglamp.GetComponent<Light>();
    }
    void OnTriggerEnter(Collider other)
    { 
        if (other.tag == "player")
            Debug.Log("skybox");
        { 
            if (RenderSettings.skybox != otherSkyBox)
            { 
                RenderSettings.skybox = otherSkyBox; 
                sun.intensity = 0.25f;

            }
        }

    }
    // Update is called once per frame
    void Update()
    {
        


    }
}
