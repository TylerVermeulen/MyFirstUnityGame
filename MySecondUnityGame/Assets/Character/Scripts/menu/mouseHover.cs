using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseHover : MonoBehaviour
{

    private Renderer AAAAAAAA;
    // Start is called before the first frame update
    void Start()
    {
        AAAAAAAA = GetComponent<Renderer>();
    }
    
    
    void OnMouseEnter()
    {
        AAAAAAAA.material.color = Color.cyan;
    } 
    void OnMouseExit()
    {
        AAAAAAAA.material.color = Color.yellow;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
