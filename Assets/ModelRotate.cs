using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModelRotate : MonoBehaviour
{


    public GameObject GameObject;
    public GameObject objtouch;
    public Slider RotateSlider;

    public Slider rXSlider;
    public Slider rYSlider;
    public Slider rZSlider;

    /*public InputField rXinputi;
    public InputField rYinputi;
    public InputField rZinputi;
    public InputField rMAINinputi;*/

    float speed = 0;

    float rotvalue = 0f;

    int tooitoggle =0;

    string cobjname;


    /// <summary>
    /// //////////////////////////////
    /// </summary>
    /// 
    float rXinputvalue = 20f;
    float rYinputvalue = 20f;
    float rZinputvalue = 20f;
    float rMAINinputvalue = 20f;

    /// <summary>
    /// //////////////////////////////
    /// </summary>
    /// 


    // Use this for initialization
    void Start()
    {
        this.objtouch = GameObject.Find("TouchManager");
        cobjname = objtouch.GetComponent<ObjTouch>().objname;
    }

    // Update is called once per frame
    void Update()
    {
        this.GameObject = GameObject.Find(objtouch.GetComponent<ObjTouch>().objname);
        //Quaternion qua = Quaternion.Euler(GameObject.transform.rotation.x, GameObject.transform.rotation.y, GameObject.transform.rotation.z);
        //Debug.Log(GameObject.transform.eulerAngles.x + "," + GameObject.transform.eulerAngles.y + "," + GameObject.transform.eulerAngles.z);
        //Debug.Log(Quaternion.Euler(rXSlider.value - 90, rYSlider.value, rZSlider.value - 90));

        if (cobjname == objtouch.GetComponent<ObjTouch>().objname)
        {
        }
        else
        {
            this.tooitoggle = 1;
            cobjname = objtouch.GetComponent<ObjTouch>().objname;
            Debug.Log(this.cobjname+"ddjdskfj");
            this.GameObject = GameObject.Find(objtouch.GetComponent<ObjTouch>().objname);

            //Debug.Log(GameObject.transform.rotation.x + "," + GameObject.transform.rotation.y + "," + GameObject.transform.rotation.z);
            this.rotvalue = RotateSlider.value;
            rXSlider.value = GameObject.transform.eulerAngles.x;
            rYSlider.value = GameObject.transform.eulerAngles.y;
            rZSlider.value = GameObject.transform.eulerAngles.z;

            RotateSlider.value = 0;
            this.tooitoggle = 0;
        }


        if (this.tooitoggle == 0)
        {
            GameObject.transform.rotation = Quaternion.Euler(rXSlider.value, rYSlider.value, rZSlider.value);
            if (RotateSlider.value == this.rotvalue)
            {

            }
            else
            {
                this.rotvalue = RotateSlider.value;
                GameObject.transform.rotation = Quaternion.Euler(RotateSlider.value, RotateSlider.value, RotateSlider.value);
                rXSlider.value = RotateSlider.value;
                rYSlider.value = RotateSlider.value;
                rZSlider.value = RotateSlider.value;
            }
        }
    }

    public void RoResetButton()
    {
        rXSlider.value = 270;
        rYSlider.value = 270;
        rZSlider.value = 0;
        RotateSlider.value = 0;
        Debug.Log("pulled!");
    }
}