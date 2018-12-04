using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GridManager : MonoBehaviour {

    //// Declaring global variables.
    //public GameObject[] prefabRooms;
    //public GameObject[] rooms;
    ////public GameObject prefabRoom1;
    ////public GameObject prefabRoom2;

    //public GameObject grid;

    //public string activeScene = "SampleScene";

    //Vector3 gridPos;

    //// Use this for initialization.
    //void Start()
    //{

    //    // Declaring local variables.
    //    float x;
    //    float y;
    //    float z = 0;

    //    //// Hard coding rooms[] array with the types of rooms available.
    //    //prefabRooms = new GameObject[2];
    //    //prefabRooms[0] = prefabRoom1;
    //    //prefabRooms[1] = prefabRoom2;

    //    // Protoyping for an example level 1.
    //    if (activeScene == "SampleScene")
    //    {
    //        for (int i = 0; i < prefabRooms.Length; i++)
    //        {
    //            // Prevents rooms from overlapping as two rooms cannot have the same Vecto3.
    //            do
    //            {
    //                x = Random.Range(-2, 1);
    //                y = Random.Range(-1, 2);
    //                gridPos = new Vector3(x, y, z);

    //            } while (Overlap(gridPos));

    //            // Instantiates each prefab as a GameObject under the parent Grid.
    //            rooms[i] = Instantiate(prefabRooms[i], gridPos, Quaternion.identity);
    //            rooms[i].transform.parent = GameObject.Find("Grid").transform;
    //        }

    //    }

    //}

    //private bool Overlap(Vector3 gridPos)
    //{
    //    bool isOverlapping;



    //    return isOverlapping;
    //}

}
