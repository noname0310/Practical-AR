using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubTarget : MonoBehaviour {

    public GameObject subT;
    public GameObject cube;
    public GameObject cube1;

    // Use this for initialization
    void Start () {
        this.subT = GameObject.Find("ImageTargetSpot");
        this.cube = GameObject.Find("Cube");
        this.cube1 = GameObject.Find("Cube1");
    }
	
	// Update is called once per frame
	void Update () {
        cube.transform.rotation = Quaternion.Euler(subT.transform.rotation.x, subT.transform.rotation.y, subT.transform.rotation.z);
        cube1.transform.rotation = Quaternion.Euler(subT.transform.rotation.x, subT.transform.rotation.y, subT.transform.rotation.z);
    }
}
