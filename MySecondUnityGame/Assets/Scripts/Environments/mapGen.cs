using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class DoorModel
{
	public Vector3 position;
	public Quaternion rot;
	public bool isDoor;
	public string tag;
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

public class mapGen : MonoBehaviour
{
	[SerializeField] private int steps = 0;
	[SerializeField] GameObject[] Environments = new GameObject[5];
	[SerializeField] GameObject endE;
	[SerializeField] GameObject beginArea, area, door, noDoor;
	private GameObject[] path;
	[SerializeField] private float locationX = 0, locationY = 0, locationZ = 0;
	[SerializeField] private float boundryToNegativeX, boundryToNegativeZ, boundryToPositiveX, boundryToPositiveZ;
		
	private Room[] roomList;

	private float B_NegativeX, B_NegativeZ, B_PositiveX, B_PositiveZ;
	float currentX, currentZ;

	float diameter;
	string canMake = "true";
	void Start()
	{
		//UnityEditor.SceneView.FocusWindowIfItsOpen(typeof(UnityEditor.SceneView));
		path = new GameObject[steps];
		Debug.Log("what");
		path[0] = Instantiate(beginArea, new Vector3(locationX, locationY, locationZ), Quaternion.identity);
		path = genMap(path);
		roomList = GenDoors(path, new string[] { "Door1", "door2", "door3", "door4", "door5", "door6", "door2", "Door1", "door2", "Door1", "door2", "Door1", "door2", "Door1" });
		GenEnvironments(RandomizeArray(Environments, new System.Random()), path);
	}

	private void GenEnvironments(GameObject[] EnvArray, GameObject[] path)
	{
		int temp = 0;
		Room lastRoom = roomList[roomList.Length - 1];

		for (int i = 0, j = EnvArray.Length; i < j; i++)
		{
			GameObject newEnv = Instantiate(EnvArray[i]);
			newEnv.transform.position = path[i].transform.position;

            temp++;
		}
		if (lastRoom.doorNorth)
		{
			Instantiate(endE, new Vector3(lastRoom.roomObject.transform.position.x, lastRoom.roomObject.transform.position.y, lastRoom.roomObject.transform.position.z), Quaternion.Euler(0, 69, 0));
		}
		else if (lastRoom.doorSouth)
		{
			Instantiate(endE, new Vector3(lastRoom.roomObject.transform.position.x, lastRoom.roomObject.transform.position.y, lastRoom.roomObject.transform.position.z), Quaternion.Euler(0, 250, 0));
		}
		else if (lastRoom.doorWest)
		{
			Instantiate(endE, new Vector3(lastRoom.roomObject.transform.position.x, lastRoom.roomObject.transform.position.y, lastRoom.roomObject.transform.position.z), Quaternion.Euler(0, -204.5f, 0));
		}
		else if (lastRoom.doorEast)
		{
			Instantiate(endE, new Vector3(lastRoom.roomObject.transform.position.x, lastRoom.roomObject.transform.position.y, lastRoom.roomObject.transform.position.z), Quaternion.Euler(0, -24.5f, 0));
		
		}
		//Instantiate(endE, path[temp].transform);
	}

	internal static T[] RandomizeArray<T>(T[] array, System.Random rand)
	{
		List<T> options = array.ToList();
		List<T> result = new List<T>();

		while (options.Count > 0)
		{ 
			int i = rand.Next(options.Count);

			result.Add(options[i]);

			options.RemoveAt(i);
		}
		return result.ToArray();
	}

	private Room[] GenDoors(GameObject[] path, string[] tags)
	{
		Room[] rooms = new Room[path.Length];
		for (int i = 0; i < rooms.Length; i++)
		{
			rooms[i] = new Room(path[i]);
		}
		//Debug.Log(rooms);
		foreach (Room item in rooms)
		{
			// +x east, -x west, +z south (don't worry about it), -z north (again, don't worry about it) 
			for (int i = 0; i < rooms.Length; i++)
			{
				if (item != rooms[i])//skip self
				{
					float dx = rooms[i].roomObject.transform.position.x - item.roomObject.transform.position.x;
					float dz = rooms[i].roomObject.transform.position.z - item.roomObject.transform.position.z;
					if (dx == diameter && System.Math.Abs(dz) < 0.1f)
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
					if (dz == -diameter && System.Math.Abs(dx) < 0.1f)
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
			listOfDoorsToInstantiate.Add(
				new DoorModel()
				{

					isDoor = rooms[i].doorNorth,
					position = new Vector3(rooms[i].roomObject.transform.position.x, rooms[i].roomObject.transform.position.y, rooms[i].roomObject.transform.position.z - diameter / 2),
					rot = Quaternion.Euler(0, 90, 0),
					tag = tags[i]
				}
			);
			//end north

			//begin south
			listOfDoorsToInstantiate.Add(
				new DoorModel()
				{

					isDoor = rooms[i].doorSouth,
					position = new Vector3(rooms[i].roomObject.transform.position.x, rooms[i].roomObject.transform.position.y, rooms[i].roomObject.transform.position.z + diameter / 2),
					rot = Quaternion.Euler(0, 270, 0),
					tag = tags[i]
				}
			);
			//end south

			//begin west



			listOfDoorsToInstantiate.Add(
				new DoorModel()
				{

					isDoor = rooms[i].doorWest,
					position = new Vector3(rooms[i].roomObject.transform.position.x - diameter / 2, rooms[i].roomObject.transform.position.y, rooms[i].roomObject.transform.position.z),
					rot = Quaternion.Euler(0, 180, 0),
					tag = tags[i]
				}
			);
			//end west

			//begin east
			listOfDoorsToInstantiate.Add(
				new DoorModel()
				{

					isDoor = rooms[i].doorEast,
					position = new Vector3(rooms[i].roomObject.transform.position.x + diameter / 2, rooms[i].roomObject.transform.position.y, rooms[i].roomObject.transform.position.z),
					rot = Quaternion.Euler(0, 0, 0),
					tag = tags[i]
				}
			);
			//end east
		}

		//remove duplicates      
		//null the right duplicates
		for (int i = 0, k = listOfDoorsToInstantiate.Count; i < k; i++)
		{

			for (int j = 1 + i; j != listOfDoorsToInstantiate.Count; j++)
			{

				if (listOfDoorsToInstantiate[i] != null && listOfDoorsToInstantiate[j] != null)
				{
					if (listOfDoorsToInstantiate[i].position == listOfDoorsToInstantiate[j].position)
					{

						Debug.Log("door_1:" + i + listOfDoorsToInstantiate[i].position + ", Door_2:" + j + listOfDoorsToInstantiate[j].position);
						listOfDoorsToInstantiate[i] = null;
					}
				}
			}
		}


		listOfDoorsToInstantiate.Where(i => i != null)
			.Select(i => DoorModelToGameObject(i))
			.ToArray();

		return rooms;


	}

	private GameObject DoorModelToGameObject(DoorModel model)
	{
		GameObject obj = Instantiate(model.isDoor ? door : noDoor);
		obj.transform.position = model.position;
		obj.transform.rotation = model.rot;
		obj.tag = model.isDoor ? model.tag : "Untagged";
		//obj.transform.localScale = new Vector3(3, 3, 3); 

		return obj;
	}


	private GameObject[] genMap(GameObject[] path)
	{


		//Random.seed = 1;


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

			// assumption made that compiler will optimise this string canMake = "case" thing going on here
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
							canMake = "false";
						}
					}
				}
			}
			switch (canMake)
			{
				case "true":
					path[i] = Instantiate(area, new Vector3(currentX = locationX, locationY, currentZ = locationZ), Quaternion.identity);
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
}