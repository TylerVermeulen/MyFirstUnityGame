using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapGen : MonoBehaviour
{
    [SerializeField] private int steps = 10;
    [SerializeField] GameObject area;
    private GameObject[] path;
    int locationX, locationZ, headX, headZ;
    int size;
    bool canMake = true;
    void Start()
    {
        path = new GameObject[steps];

        path[0] = Instantiate(area, new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity);
        genMap(path);
    }

    void genMap(GameObject[] path)
    {
        Debug.Log(" aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa aaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
        size = (int)area.transform.localScale.x;

        for (int i = 1; i < path.Length; i++)
        {
            switch (Random.Range(0, 4))
            {
                case 1:
                    locationX += size;
                    break;
                case 2:
                    locationX -= size;
                    break;
                case 3:
                    locationZ += size;
                    break;
                case 4:
                    locationZ -= size;
                    break;
            }

            canMake = true;

            for (int j = i; j >= 0; j--)
            {
                if (path[j] != null)
                {
                    if (locationX == path[j].transform.position.x && locationZ == path[j].transform.position.z)
                    {
                        canMake = false;
                    }
                }
            }
            if (canMake)
            {
                path[i] = Instantiate(area, new Vector3(locationX, 0.0f, locationZ), Quaternion.identity);
            }
            else
            {
                i--;
            }
        }
    }





    void Update()
    {

    }
}
