using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Yoink : MonoBehaviour
{
    public int Flower_Count = 0;
    private int doorindex = 0;
    [SerializeField] private GameObject tutorialUI;
    [SerializeField] private Animator animator;
    bool istutorialseen = true;
    // Start is called before the first frame update
    void Start()
    {

    }
    internal void DeleteByTag(string tag)
    {
        GameObject[] doors = GameObject.FindGameObjectsWithTag(tag);
        for (int i = 0; i < doors.Length; i++)
        {
            Destroy(doors[i]);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("o"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if (Input.GetKeyDown("y") && istutorialseen == true)
        {
            tutorialUI.SetActive(false);
            istutorialseen=false;
        }
        else if (Input.GetKeyDown("y") && istutorialseen == false)
        {
            tutorialUI.SetActive(true);
            istutorialseen=true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown("g") && animator.GetCurrentAnimatorStateInfo(0).IsName("Gathering") == false)
        {
            if (other.tag == "Flower")
            {
                
                Destroy(other.gameObject, 1f);
                Flower_Count++;
                Scoremanager.instance.AddPoint();
            }

        }
        if (Input.GetKeyDown("t") && Flower_Count >= 14)
        {
            if (other.tag == "Shop")
            {
                switch(doorindex)
                {
                    case 0: 
                        DeleteByTag("Door1")
                            ; break;
                    case 1:
                        DeleteByTag("door2")   
                            ; break;
                    case 2:
                        DeleteByTag("door3")
                            ; break;
                    case 3:
                        DeleteByTag("door4")
                            ; break;
                }
                doorindex++;
                Flower_Count = Flower_Count - 14;
                Scoremanager.instance.RemovePoint();
            }
        }

    }

}
