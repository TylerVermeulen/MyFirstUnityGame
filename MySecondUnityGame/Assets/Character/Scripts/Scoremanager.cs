using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoremanager : MonoBehaviour
{
    public Text Flowercounttext;
    int Flowercount = 0;
    // Start is called before the first frame update
    void Start()
    {
        Flowercounttext.text = Flowercount.ToString() + "POINTS";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
