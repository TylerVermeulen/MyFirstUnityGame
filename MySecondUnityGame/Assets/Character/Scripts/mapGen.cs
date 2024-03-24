using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapGen : MonoBehaviour
{
    [SerializeField] private int steps = 10;
    [SerializeField] GameObject area, door, noDoor;
    private GameObject[] path;
    [SerializeField] private float locationX = 0, locationZ = 0;
    [SerializeField] private float boundryToNegativeX = 50, boundryToNegativeZ = 50, boundryToPositiveX = 200, boundryToPositiveZ = 200;

    private float B_NegativeX, B_NegativeZ, B_PositiveX, B_PositiveZ;
    float currentX, currentZ;

    float diameter;
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
        GameObject[] listOfDoorsToInstantiate = new GameObject[int.MaxValue / 1024];
        // dunno if lists or arrays can be resized or added to + too lazy to figure out, this works 
        int doorIndex = 0;

        // The next part of this function assuems that when looking at the door prefab, the front(aka the blue arrow) points to the left
        // The same should apply to the noDoor prefab

        // now behold a fuckton of (--D--)ry-code
        foreach (GameObject item in path)
        {
            // +x north, -x south, +z west, -z east

            // summary: if next to me there exists another area, place door prefab, if not, placce noDoor prefab in hole of area prefab
            for (int i = 0; i < path.Length; i++)
            {
                // begin north
                if (item.transform.position.x == (path[i].transform.position.x + diameter) && item.transform.position.z == path[i].transform.position.z)
                {
                    door.transform.position = new Vector3(item.transform.position.x + diameter / 2, item.transform.position.y, item.transform.position.z);
                    door.transform.rotation = Quaternion.Euler(0, 0, 0);
                    listOfDoorsToInstantiate[doorIndex] = door;
                    doorIndex++;
                }
                else
                {
                    noDoor.transform.position = new Vector3(item.transform.position.x + diameter / 2, item.transform.position.y, item.transform.position.z);
                    noDoor.transform.rotation = Quaternion.Euler(0, 0, 0);
                    listOfDoorsToInstantiate[doorIndex] = noDoor;
                    doorIndex++;
                }
                // end north


                // begin south
                if (item.transform.position.x == (path[i].transform.position.x - diameter) && item.transform.position.z == path[i].transform.position.z)
                {
                    door.transform.position = new Vector3(item.transform.position.x - diameter / 2, item.transform.position.y, item.transform.position.z);
                    door.transform.rotation = Quaternion.Euler(0, 180, 0);
                    listOfDoorsToInstantiate[doorIndex] = door;
                    doorIndex++;
                }
                else
                {
                    noDoor.transform.position = new Vector3(item.transform.position.x - diameter / 2, item.transform.position.y, item.transform.position.z);
                    noDoor.transform.rotation = Quaternion.Euler(0, 180, 0);
                    listOfDoorsToInstantiate[doorIndex] = noDoor;
                    doorIndex++;
                }
                // end south


                // begin west
                if (item.transform.position.x == path[i].transform.position.x && item.transform.position.z == (path[i].transform.position.z + diameter))
                {
                    door.transform.position = new Vector3(item.transform.position.x , item.transform.position.y, item.transform.position.z+ diameter / 2);
                    door.transform.rotation = Quaternion.Euler(0, 270, 0);
                    listOfDoorsToInstantiate[doorIndex] = door;
                    doorIndex++;
                }
                else
                {
                    noDoor.transform.position = new Vector3(item.transform.position.x , item.transform.position.y, item.transform.position.z+ diameter / 2);
                    noDoor.transform.rotation = Quaternion.Euler(0, 270, 0);
                    listOfDoorsToInstantiate[doorIndex] = noDoor;
                    doorIndex++;
                }
                // end west


                // begin east
                if (item.transform.position.x == path[i].transform.position.x  && item.transform.position.z == (path[i].transform.position.z- diameter))
                {
                    door.transform.position = new Vector3(item.transform.position.x , item.transform.position.y, item.transform.position.z- diameter / 2);
                    door.transform.rotation = Quaternion.Euler(0, 90, 0);
                    listOfDoorsToInstantiate[doorIndex] = door;
                    doorIndex++;
                }
                else
                {
                    noDoor.transform.position = new Vector3(item.transform.position.x , item.transform.position.y, item.transform.position.z- diameter / 2);
                    noDoor.transform.rotation = Quaternion.Euler(0, 90, 0);
                    listOfDoorsToInstantiate[doorIndex] = noDoor;
                    doorIndex++;
                }
                // end west
            }
        }
    }

    private GameObject[] genMap(GameObject[] path)
    {
        Debug.Log(" aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa aaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
        diameter = (float)(area.transform.localScale.x * 0.95);
        B_NegativeX = path[0].transform.position.x - boundryToNegativeX;
        B_NegativeZ = path[0].transform.position.z - boundryToNegativeZ;
        B_PositiveX = path[0].transform.position.x + boundryToPositiveX;
        B_PositiveZ = path[0].transform.position.z + boundryToPositiveZ;


        for (int i = 1; i < path.Length; i++)
        {
            switch (Random.Range(0, 4))
            {
                case 1:
                    locationX += diameter;
                    break;
                case 2:
                    locationX -= diameter;
                    break;
                case 3:
                    locationZ += diameter;
                    break;
                case 4:
                    locationZ -= diameter;
                    break;
            }

            canMake = "true";

            for (int j = i; j >= 0; j--)
            {
                if (path[j] != null)
                {
                    if (
                        locationX <= B_NegativeX || locationZ <= B_NegativeZ ||
                        locationX >= B_PositiveX || locationZ >= B_PositiveZ
                        )
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
                    Debug.Log("aaaaaaaa");
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
// if (item.transform.position.x == (path[i].transform.position.x - diameter) && item.transform.position.z == path[i].transform.position.z)
// {

// }
// if (item.transform.position.x == path[i].transform.position.x && item.transform.position.z == (path[i].transform.position.z + diameter))
// {

// }
// if (item.transform.position.x == path[i].transform.position.x && item.transform.position.z == (path[i].transform.position.z + diameter))
// {

// }
