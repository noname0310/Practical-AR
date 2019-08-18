using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModelSpot : MonoBehaviour {

    public Toggle ScaleSpot;
    public GameObject cube;
    public GameObject spottext;

    public GameObject GameObject;
    public GameObject objtouch;

    public GameObject wallc;

    int scalespot = 1;
    // Use this for initialization
    void Start () {
        this.objtouch = GameObject.Find("TouchManager");
        this.wallc = GameObject.Find("Canvas_wallC");
    }
    
	
	// Update is called once per frame
	void Update () {
        this.GameObject = GameObject.Find(objtouch.GetComponent<ObjTouch>().objname);

        if (GameObject.name == "trash")
        {
            if (ScaleSpot.isOn == false)
            {
                cube.SetActive(false);
                spottext.SetActive(false);
            }
        }
        else
        {
            if (ScaleSpot.isOn == false)
            {
                cube.SetActive(true);
                spottext.SetActive(true);
            }
        }
    }

    public void SpotIn()
    {
        if (ScaleSpot.isOn)
        {
            scalespot = 1;
            cube.SetActive(false);
            spottext.SetActive(false);
            Debug.Log("pulled!");
        }
        else
        {
            if (GameObject.name == "trash")
            {
            }
            else
            {
                scalespot = 0;
                cube.SetActive(true);
                spottext.SetActive(true);
                Debug.Log("pulled!");
            }
        }
    }
}
