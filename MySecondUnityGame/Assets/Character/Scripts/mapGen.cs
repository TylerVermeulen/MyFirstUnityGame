using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapGen : MonoBehaviour
{
    [SerializeField] private int steps = 10;
    [SerializeField] GameObject area;
    private GameObject[] path;
    [SerializeField] private float locationX = 0, locationZ = 0;
    float currentX, currentZ;
    float size;
    string canMake = "true";
    void Start()
    {
        UnityEditor.SceneView.FocusWindowIfItsOpen(typeof(UnityEditor.SceneView));
        path = new GameObject[steps];

        path[0] = Instantiate(area, new Vector3(locationX, 0.0f, locationZ), Quaternion.identity);
        path = genMap(path);
        genDoors(path);
    }

    private void genDoors(GameObject[] path)
    {
        foreach (GameObject item in path)
        {
            for (int i = 0; i < path.Length; i++)
            {

            }
        }
    }

    private GameObject[] genMap(GameObject[] path)
    {
        Debug.Log(" aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa aaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
        size = (float)(area.transform.localScale.x * 0.95);

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

            canMake = "true";

            for (int j = i; j >= 0; j--)
            {
                if (path[j] != null)
                {
                    if (locationX <= -50.0f || locationZ <= -50.0f)
                    {
                        canMake = "outBounds";
                    }
                    else
                    {
                        if (
                            (locationX == path[j].transform.position.x &&
                            locationZ == path[j].transform.position.z))
                        {
                            // Debug.Log("aaaaaaaaaaaa");
                            canMake = "false";
                        }
                    }
                }
            }
            switch (canMake)
            {
                case "true":
                    path[i] = Instantiate(area, new Vector3(currentX = locationX, 0.0f, currentZ = locationZ), Quaternion.identity);

                    break;
                case "outBounds":
                    locationX = currentX;
                    locationZ = currentZ;
                    i--;
                    break;
                case "false":
                    i--;
                    break;
            }
        }
        return path;
    }





    void Update()
    {

    }
}
