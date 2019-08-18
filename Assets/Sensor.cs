using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sensor : MonoBehaviour {


    public GameObject GameObject;
    public GameObject objtouch;

    public GameObject Canvas_up;
    public GameObject Canvas_down;

    public GameObject ATdd;

    public int dropv = 0;

    Rigidbody2D rigid2D;

    public GameObject lmagered;

    public GameObject glass;

    public GameObject wall;
    public GameObject wall1;

    string cobjname;

    /*public void OnTriggerEnter(Collider other)
    {
        if (other.name == "wall")
        {
            Debug.Log("enter");
            other.GetComponent<Renderer>().material.color = lmagered.GetComponent<Image>().color;
        }
        if (other.name == "wall1")
        {
            Debug.Log("enter");
            other.GetComponent<Renderer>().material.color = lmagered.GetComponent<Image>().color;
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.name == "wall")
        {
            Debug.Log("exit");
            other.GetComponent<Renderer>().material.color = glass.GetComponent<Image>().color;
        }
        if (other.name == "wall1")
        {
            Debug.Log("exit");
            other.GetComponent<Renderer>().material.color = glass.GetComponent<Image>().color;
        }
    }*/

    // Use this for initialization
    void Start () {
        this.objtouch = GameObject.Find("TouchManager");

        this.Canvas_up = GameObject.Find("Canvas_up");
        this.Canvas_down = GameObject.Find("Canvas_down");
        this.ATdd = GameObject.Find("Dropdown");
        this.wall = GameObject.Find("wall");
        this.wall1 = GameObject.Find("wall1");
        //this.glass = GameObject.Find("Imageglass");
        //this.lmagered = GameObject.Find("Imageredgless");
    }

    int wait = 0;

	// Update is called once per frame
	void Update () {
        this.GameObject = GameObject.Find(objtouch.GetComponent<ObjTouch>().objname);


        if (cobjname == objtouch.GetComponent<ObjTouch>().objname)
        {
            //dropv = ATdd.GetComponent<Dropdown>().value;
        }
        else
        {
            wait = 1;
            cobjname = objtouch.GetComponent<ObjTouch>().objname;
            this.GameObject = GameObject.Find(objtouch.GetComponent<ObjTouch>().objname);
            ATdd.GetComponent<Dropdown>().value = dropv;
            wait = 0;
            Debug.Log(dropv);
            Debug.Log(ATdd.GetComponent<Dropdown>().value);
        }

        if(wait == 0)
        {
            if (this.gameObject.name == objtouch.GetComponent<ObjTouch>().objname)
            {
                dropv = ATdd.GetComponent<Dropdown>().value;
            }
        }

        if(GameObject.name == this.gameObject.name)
        {

        }
        else
        {
            if (Canvas_up.GetComponent<Slideup>().os == 1 && Canvas_down.GetComponent<Slidedown>().osd == 1)
            {
                this.gameObject.GetComponent<BoxCollider>().enabled = false;
            }
            else if (Canvas_up.GetComponent<Slideup>().os == 0)
            {
                this.gameObject.GetComponent<BoxCollider>().enabled = true;
            }
            else if (Canvas_down.GetComponent<Slidedown>().osd == 0)
            {
                this.gameObject.GetComponent<BoxCollider>().enabled = true;
            }
        }


        /*Vector3 p1 = transform.position;
        Vector3 p2 = this.wall.transform.position;
        Vector3 dir = p1 - p2;
        float d = dir.magnitude;
        float r1 = 0.2f;
        float r2 = 0.2f;

        if(d< r1 + r2)//부딛힘
        {
            wall.GetComponent<Renderer>().material.color = lmagered.GetComponent<Image>().color;
        }
        else
        {
            wall.GetComponent<Renderer>().material.color = glass.GetComponent<Image>().color;
        }

        Vector3 p11 = transform.position;
        Vector3 p21 = this.wall1.transform.position;
        Vector3 dir1 = p11 - p21;
        float d1 = dir.magnitude;
        float r11 = 0.2f;
        float r21 = 0.2f;

        if (d1 < r11 + r21)//부딛힘
        {
            wall1.GetComponent<Renderer>().material.color = lmagered.GetComponent<Image>().color;
        }
        else
        {
            wall1.GetComponent<Renderer>().material.color = glass.GetComponent<Image>().color;
        }*/
    }
}
