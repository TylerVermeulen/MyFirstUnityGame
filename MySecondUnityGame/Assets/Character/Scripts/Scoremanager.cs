using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Scoremanager : MonoBehaviour
{
    public static Scoremanager instance;
    public TMP_Text Flowercounttext;
    int Flowercount = 0;


    private void Awake()
    {
        instance = this; 
    }
    // Start is called before the first frame update
    void Start()
    {
        Flowercounttext.text = Flowercount.ToString() + " flowers";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddPoint()
    {
        Flowercount += 1;
        Flowercounttext.text = Flowercount.ToString() + " flowers";
    }
    public void RemovePoint()
    {
        Flowercount -= 14;
    }
}
