using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class DoorModel
{
	public Vector3 position;
	public Quaternion rot;
	public bool isDoor;
}
public class mapGen : MonoBehaviour
{
	[SerializeField] private int steps = 0;
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
		Debug.Log("what");
		path[0] = Instantiate(area, new Vector3(locationX, 0.0f, locationZ), Quaternion.identity);
		path = genMap(path);
		GenDoors(path);
	}

	private GameObject[] GenDoors(GameObject[] path)
	{
		Room[] rooms = new Room[path.Length];
		for (int i = 0; i < rooms.Length; i++)
		{
			rooms[i] = new Room(path[i]);
		}
		//Debug.Log(rooms);
		foreach (Room item in rooms)
		{
			// +x north, -x south, +z west, -z east
			for (int i = 0; i < rooms.Length; i++)
			{
				if (item != rooms[i])//skip self
				{
					float dx = rooms[i].roomObject.transform.position.x - item.roomObject.transform.position.x;
					float dz = rooms[i].roomObject.transform.position.z - item.roomObject.transform.position.z;
					if (dx == diameter && System.Math.Abs (dz) < 0.1f)
					{
						item.doorEast = true;
					}
					if (dx == -diameter && System.Math.Abs(dz) < 0.1f)
					{
						item.doorWest = true;
					}
					if (dz == diameter && System.Math.Abs(dx) < 0.1f)
					{
						item.doorSouth = true;
					}
					if (dz == -diameter && System.Math.Abs(dx )< 0.1f)
					{
						item.doorNorth = true;
					}
				}
			}
		}

		List<DoorModel> listOfDoorsToInstantiate = new List<DoorModel>();// [path.Length * 4];
		for (int i = 0, L = rooms.Length; i < L; i++)
		{
			//begin north


		//door.transform.position = noDoor.transform.position = new Vector3(
		//	rooms[i].roomObject.transform.position.x + diameter / 2,
		//	rooms[i].roomObject.transform.position.y,
		//	rooms[i].roomObject.transform.position.z);

			listOfDoorsToInstantiate.Add(
				new DoorModel()
				{

					isDoor =rooms[i].doorNorth,
					position=	new Vector3(rooms[i].roomObject.transform.position.x , rooms[i].roomObject.transform.position.y, rooms[i].roomObject.transform.position.z - diameter / 2),
					rot=	Quaternion.Euler(0, 0, 0)
				}
			);

		//door.transform.position = noDoor.transform.position = new Vector3(rooms[i].roomObject.transform.position.x + diameter / 2, rooms[i].roomObject.transform.position.y, rooms[i].roomObject.transform.position.z);
		//door.transform.rotation = noDoor.transform.rotation = Quaternion.Euler(0, 0, 0);
		//if (rooms[i].doorNorth)
		//{
		//	listOfDoorsToInstantiate.Add(door);
		//}
		//else
		//{
		//	listOfDoorsToInstantiate.Add(noDoor);
		//}
			//end north

			//begin south
			//door.transform.position = noDoor.transform.position = new Vector3(rooms[i].roomObject.transform.position.x - diameter / 2, rooms[i].roomObject.transform.position.y, rooms[i].roomObject.transform.position.z);
			//door.transform.rotation = noDoor.transform.rotation = Quaternion.Euler(0, 180, 0);
			//if (rooms[i].doorSouth)
			//{
			//	listOfDoorsToInstantiate.Add(door);
			//}
			//else
			//{
			//	listOfDoorsToInstantiate.Add(noDoor);
			//}


			listOfDoorsToInstantiate.Add(
				new DoorModel()
				{

					isDoor = rooms[i].doorSouth,
					position = new Vector3(rooms[i].roomObject.transform.position.x , rooms[i].roomObject.transform.position.y, rooms[i].roomObject.transform.position.z + diameter / 2),
					rot = Quaternion.Euler(0, 180, 0)
				}
			);
			//end south

			//begin west
		//door.transform.position = noDoor.transform.position = new Vector3(rooms[i].roomObject.transform.position.x, rooms[i].roomObject.transform.position.y, rooms[i].roomObject.transform.position.z + diameter / 2);
		//door.transform.rotation = noDoor.transform.rotation = Quaternion.Euler(0, 270, 0);
		//if (rooms[i].doorWest)
		//{
		//	listOfDoorsToInstantiate.Add(door);
		//}
		//else
		//{
		//	listOfDoorsToInstantiate.Add(Gam(noDoor));
		//}


			listOfDoorsToInstantiate.Add(
				new DoorModel()
				{

					isDoor = rooms[i].doorWest,
					position = new Vector3(rooms[i].roomObject.transform.position.x - diameter / 2, rooms[i].roomObject.transform.position.y, rooms[i].roomObject.transform.position.z),
					rot = Quaternion.Euler(0, 270, 0)
				}
			);
			//end west

			//begin east
			//door.transform.position = noDoor.transform.position = new Vector3(rooms[i].roomObject.transform.position.x, rooms[i].roomObject.transform.position.y, rooms[i].roomObject.transform.position.z - diameter / 2);
			//door.transform.rotation = noDoor.transform.rotation = Quaternion.Euler(0, 90, 0);
			//if (rooms[i].doorEast)
			//{
			//	listOfDoorsToInstantiate.Add(door);
			//}
			//else
			//{
			//	listOfDoorsToInstantiate.Add(noDoor);
			//}
			listOfDoorsToInstantiate.Add(
				new DoorModel()
				{

					isDoor = rooms[i].doorEast,
					position = new Vector3(rooms[i].roomObject.transform.position.x + diameter / 2, rooms[i].roomObject.transform.position.y, rooms[i].roomObject.transform.position.z ),
					rot = Quaternion.Euler(0, 90, 0)
				}
			);
			//end east

		//for (int h = 0; h < listOfDoorsToInstantiate.Count; h++)
		//{
		//	Debug.Log(i, listOfDoorsToInstantiate[i]);
		//}
		}


		//List<Vector2> vectors = new List<Vector2>();

	//	List<Vector2> newVectors = new List<Vector2>(vectors);

		//remove duplicates      
		//null the right duplicates
		for (int i = 0, k = listOfDoorsToInstantiate.Count; i < k; i++)
		{
			//Debug.Log($"remove  duplicates {i}");
			for (int j = 1 + i; j != listOfDoorsToInstantiate.Count; j++)
			{
				//Debug.Log($"remove  duplicates {j}");
				if (listOfDoorsToInstantiate[i] != null && listOfDoorsToInstantiate[j] != null)
				{
					if (listOfDoorsToInstantiate[i].position == listOfDoorsToInstantiate[j].position)
					{

						Debug.Log("door_1:" + i + listOfDoorsToInstantiate[i].position + ", Door_2:" + j + listOfDoorsToInstantiate[j].position);
						listOfDoorsToInstantiate[j] = null;
					}
				}
			}
		}


		return listOfDoorsToInstantiate.Where(i => i != null)
			.Select(i => DoorModelToGameObject(i))
			.ToArray();
		////actually remove duplicates
		//List<GameObject> aaa = new List<GameObject>();
		//
		//foreach (GameObject gameObject in listOfDoorsToInstantiate)
		//{
		//	if (gameObject != null)
		//	{
		//		aaa.Add(gameObject);
		//	}
		//}
		//
		//
		////for (int i = 0; i < aaa.Count; i++)
		//{
		//	//Debug.Log(aaa[i]);
		//}
		//
		//// instantiate
		//GameObject[] returnValue = new GameObject[aaa.Count];
		//for (int i = 0; i < aaa.Count; i++)
		//{
		//	//Debug.Log($"returnValue   {i}");
		//	 Instantiate(aaa[i]);
		//}
		//return aaa.ToArray();


	}

	private GameObject DoorModelToGameObject(DoorModel model)
	{
		GameObject obj = 		Instantiate(model.isDoor ? door:noDoor);
		obj.transform.position = model.position;
		obj.transform.rotation = model.rot;
		obj.transform.localScale = new Vector3(3, 3, 3);

		return obj;
	}

















	////remove duplicates
	//Debug.Log($"remove  duplicates");
	//for (int i = doorIndex - 1; i > 0; i--)
	//{
	//	Debug.Log($"remove  duplicates {i}");
	//	for (int j = 1 + i; j != doorIndex; j++)
	//	{
	//		Debug.Log($"remove  duplicates {j}");
	//		if (listOfDoorsToInstantiate[i] != null && listOfDoorsToInstantiate[j] != null)
	//		{
	//			if (listOfDoorsToInstantiate[i].transform.position == listOfDoorsToInstantiate[j].transform.position)
	//			{
	//				listOfDoorsToInstantiate[j] = null;
	//			}
	//		}
	//	}
	//}
	//








































	//dunno if lists or arrays can be resized or added to + too lazy to figure out, this works 
	int doorIndex = 0;

	// The next part of this function assuems that when looking at the door prefab, the front(aka the blue arrow) points to the left
	// The same should apply to the noDoor prefab

	// now behold a fuckton of (--D--)ry-code



	//foreach (GameObject item in path)
	//{
	//	Debug.Log($"item {item.name}");
	//	// +x north, -x south, +z west, -z east
	//
	//	// summary: if next to me there exists another area, place door prefab in list, if not, placce noDoor prefab in list so hole of area prefab can later be patched
	//	for (int i = 0; i < path.Length; i++)
	//	{
	//		Debug.Log($"path {i}");
	//		//Debug.log90
	//		// begin north
	//		if (item.transform.position.x == (path[i].transform.position.x + diameter) && item.transform.position.z == path[i].transform.position.z)
	//		{
	//			door.transform.position = new Vector3(item.transform.position.x + diameter / 2, item.transform.position.y, item.transform.position.z);
	//			door.transform.rotation = Quaternion.Euler(0, 0, 0);
	//			listOfDoorsToInstantiate[doorIndex] = door;
	//			doorIndex++;
	//		}
	//		else
	//		{
	//			noDoor.transform.position = new Vector3(item.transform.position.x + diameter / 2, item.transform.position.y, item.transform.position.z);
	//			noDoor.transform.rotation = Quaternion.Euler(0, 0, 0);
	//			listOfDoorsToInstantiate[doorIndex] = noDoor;
	//			doorIndex++;
	//		}
	//		// end north
	//
	//
	//		// begin south
	//		if (item.transform.position.x == (path[i].transform.position.x - diameter) && item.transform.position.z == path[i].transform.position.z)
	//		{
	//			door.transform.position = new Vector3(item.transform.position.x - diameter / 2, item.transform.position.y, item.transform.position.z);
	//			door.transform.rotation = Quaternion.Euler(0, 180, 0);
	//			listOfDoorsToInstantiate[doorIndex] = door;
	//			doorIndex++;
	//		}
	//		else
	//		{
	//			noDoor.transform.position = new Vector3(item.transform.position.x - diameter / 2, item.transform.position.y, item.transform.position.z);
	//			noDoor.transform.rotation = Quaternion.Euler(0, 180, 0);
	//			listOfDoorsToInstantiate[doorIndex] = noDoor;
	//			doorIndex++;
	//		}
	//		// end south
	//
	//
	//		// begin west
	//		if (item.transform.position.x == path[i].transform.position.x && item.transform.position.z == (path[i].transform.position.z + diameter))
	//		{
	//			door.transform.position = new Vector3(item.transform.position.x, item.transform.position.y, item.transform.position.z + diameter / 2);
	//			door.transform.rotation = Quaternion.Euler(0, 270, 0);
	//			listOfDoorsToInstantiate[doorIndex] = door;
	//			doorIndex++;
	//		}
	//		else
	//		{
	//			noDoor.transform.position = new Vector3(item.transform.position.x, item.transform.position.y, item.transform.position.z + diameter / 2);
	//			noDoor.transform.rotation = Quaternion.Euler(0, 270, 0);
	//			listOfDoorsToInstantiate[doorIndex] = noDoor;
	//			doorIndex++;
	//		}
	//		// end west
	//
	//
	//		// begin east
	//		if (item.transform.position.x == path[i].transform.position.x && item.transform.position.z == (path[i].transform.position.z - diameter))
	//		{
	//			door.transform.position = new Vector3(item.transform.position.x, item.transform.position.y, item.transform.position.z - diameter / 2);
	//			door.transform.rotation = Quaternion.Euler(0, 90, 0);
	//			listOfDoorsToInstantiate[doorIndex] = door;
	//			doorIndex++;
	//		}
	//		else
	//		{
	//			noDoor.transform.position = new Vector3(item.transform.position.x, item.transform.position.y, item.transform.position.z - diameter / 2);
	//			noDoor.transform.rotation = Quaternion.Euler(0, 90, 0);
	//			listOfDoorsToInstantiate[doorIndex] = noDoor;
	//			doorIndex++;
	//		}
	//		// end west
	//	}
	//}
	//
	////remove duplicates
	//Debug.Log($"remove  duplicates");
	//for (int i = doorIndex - 1; i > 0; i--)
	//{
	//	Debug.Log($"remove  duplicates {i}");
	//	for (int j = 1 + i; j != doorIndex; j++)
	//	{
	//		Debug.Log($"remove  duplicates {j}");
	//		if (listOfDoorsToInstantiate[i] != null && listOfDoorsToInstantiate[j] != null)
	//		{
	//			if (listOfDoorsToInstantiate[i].transform.position == listOfDoorsToInstantiate[j].transform.position)
	//			{
	//				listOfDoorsToInstantiate[j] = null;
	//			}
	//		}
	//	}
	//}
	//
	//// instantiate
	//GameObject[] returnValue = new GameObject[int.MaxValue / 1024];
	//for (int i = 0; i < doorIndex; i++)
	//{
	//	Debug.Log($"returnValue   {i}");
	//	returnValue[i] = Instantiate(listOfDoorsToInstantiate[i]);
	//}
	//return  returnValue;
	//


	private GameObject[] genMap(GameObject[] path)
	{
		//Random.seed = 0;
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



class Tform 
{
	internal Vector3 pos { get; set; } 
	internal Quaternion rot { get; set; }
	public Tform( Vector3 pos, Quaternion rot)
	{
		this.pos = pos;	
		this.rot = rot;
	}
	
	public void clone()
	{

	}
}
class Room
{
	internal GameObject roomObject { get; set; }
	internal bool doorNorth { get; set; }
	internal bool doorEast { get; set; }
	internal bool doorSouth { get; set; }
	internal bool doorWest { get; set; }

	public Room(GameObject roomObject)
	{
		this.roomObject = roomObject;
		this.doorNorth = false;
		this.doorEast = false;
		this.doorSouth = false;
		this.doorWest = false;
	}
}