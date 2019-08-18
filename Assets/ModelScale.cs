using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModelScale : MonoBehaviour {


    public GameObject GameObject;
    public GameObject objtouch;
    public GameObject ScaleSpot;
    public Slider ScaleSlider;

    public Slider sXSlider;
    public Slider sYSlider;
    public Slider sZSlider;
    public Dropdown dropd;

    /*public InputField sXinputi;
    public InputField sYinputi;
    public InputField sZinputi;
    public InputField sMAINinputi;*/


    float speed = 0;

    float Scalevalue = 0.15f;


    /// <summary>
    /// //////////////////////////////
    /// </summary>
    /// 
    float sXinputvalue = 20f;
    float sYinputvalue = 20f;
    float sZinputvalue = 20f;
    float sMAINinputvalue = 20f;

    /// <summary>
    /// //////////////////////////////
    /// </summary>
    /// 


    // Use this for initialization
    void Start () {
        this.ScaleSpot = GameObject.Find("ScaleSpot");
        this.objtouch = GameObject.Find("TouchManager");

    }

    string cobjname;
    int tooitoggle = 0;

    // Update is called once per frame
    void Update()
    {
        this.GameObject = GameObject.Find(objtouch.GetComponent<ObjTouch>().objname);

        if (cobjname == objtouch.GetComponent<ObjTouch>().objname)
        {
        }
        else
        {
            this.tooitoggle = 1;
            cobjname = objtouch.GetComponent<ObjTouch>().objname;
            this.GameObject = GameObject.Find(objtouch.GetComponent<ObjTouch>().objname);

            //Debug.Log(GameObject.transform.rotation.x + "," + GameObject.transform.rotation.y + "," + GameObject.transform.rotation.z);
            this.Scalevalue = ScaleSlider.value;
            sXSlider.value = GameObject.transform.localScale.x;
            sYSlider.value = GameObject.transform.localScale.y;
            sZSlider.value = GameObject.transform.localScale.z;
            Debug.Log(GameObject.transform.localScale.x + "," + GameObject.transform.localScale.y + "," + GameObject.transform.localScale.z);
            Debug.Log(sXSlider.value + "," + sYSlider.value + "," + sZSlider.value);
            ScaleSlider.value = 0;
            this.tooitoggle = 0;
        }

        if (tooitoggle == 0)
        {
            if (GameObject.name == "trash")
            { }
            else
            {

                if (GameObject.GetComponent<Sensor>().dropv == 0)
                {
                    sXSlider.interactable = true;
                    sYSlider.interactable = true;
                    sZSlider.interactable = true;
                    ScaleSlider.interactable = true;
                    GameObject.transform.localScale = new Vector3(sXSlider.value, sYSlider.value, sZSlider.value);
                    ScaleSpot.transform.localScale = new Vector3(3f, sYSlider.value * 1, 3f);
                    if (ScaleSlider.value == this.Scalevalue)
                    {

                    }
                    else
                    {
                        this.Scalevalue = ScaleSlider.value;
                        GameObject.transform.localScale = new Vector3(ScaleSlider.value, ScaleSlider.value, ScaleSlider.value);
                        ScaleSpot.transform.localScale = new Vector3(3f, ScaleSlider.value * 1, 3f);
                        sXSlider.value = ScaleSlider.value;
                        sYSlider.value = ScaleSlider.value;
                        sZSlider.value = ScaleSlider.value;
                    }
                }
                else if (GameObject.GetComponent<Sensor>().dropv == 1)
                {
                    GameObject.transform.localScale = new Vector3(187f, 187f, 187f);
                    ScaleSpot.transform.localScale = new Vector3(3f, 187 * 1, 3f);
                    sXSlider.interactable = false;
                    sYSlider.interactable = false;
                    sZSlider.interactable = false;
                    ScaleSlider.interactable = false;
                }
                else
                {
                    GameObject.transform.localScale = new Vector3(132f, 132f, 132f);
                    ScaleSpot.transform.localScale = new Vector3(3f, 132f * 1, 3f);
                    sXSlider.interactable = false;
                    sYSlider.interactable = false;
                    sZSlider.interactable = false;
                    ScaleSlider.interactable = false;
                }
            }
        }
    }

    public void SiResetButton()
    {
        sXSlider.value = 40f;
        sYSlider.value = 40f;
        sZSlider.value = 40f;
        ScaleSlider.value = 40f;
        Debug.Log("pulled!");
    }
}