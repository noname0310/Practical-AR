using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane_move_c : MonoBehaviour {

    public GameObject Plane;
    public GameObject Planesu;
    public Camera cam;

	// Use this for initialization
	void Start () {
        this.Plane = GameObject.Find("Plane");
        this.Planesu = GameObject.Find("Planesu");
    }
	
	// Update is called once per frame
	void Update () {
		if(35 < cam.GetComponent<Camera>().fieldOfView)
        {
            Plane.gameObject.transform.localPosition = new Vector3(0, -1.13f, 1.6f);
            Planesu.gameObject.transform.localPosition = new Vector3(0, 1.15f, 1.6f);
        }
        else
        {
            Plane.gameObject.transform.localPosition = new Vector3(0, -1.13f, 2.9f);
            Planesu.gameObject.transform.localPosition = new Vector3(0, 1.15f, 2.8f);
        }
	}
}
