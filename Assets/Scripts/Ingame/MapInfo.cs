using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapInfo : MonoBehaviour {

    private static MapInfo instance = null;

    public static MapInfo Data
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType(typeof(MapInfo)) as MapInfo;
                if (instance == null)
                {
                    Debug.Log("no instance");
                }
            }
            return instance;
        }
    }

    public List<GameObject> _LandMark_First_Position = new List<GameObject>();
    public List<GameObject> _LandMark_Second_Position = new List<GameObject>();
    public List<GameObject> _LandMark_Third_Position = new List<GameObject>();
    public List<GameObject> _LandMark_Fourth_Position = new List<GameObject>();


    public List<GameObject> _Line_First_Position = new List<GameObject>();
    public List<GameObject> _Line_Second_Position = new List<GameObject>();
    public List<GameObject> _Line_Third_Position = new List<GameObject>();
    public List<GameObject> _Line_Fourth_Position = new List<GameObject>();
}
