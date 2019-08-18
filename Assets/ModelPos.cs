using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModelPos : MonoBehaviour
{


    public GameObject GameObject;
    public GameObject objtouch;
    public GameObject ScaleSpot;
    public Slider PosSlider;

    public Slider pXSlider;
    public Slider pYSlider;
    public Slider pZSlider;

    public Slider sxSlider;
    public Slider sYSlider;

    /*public InputField pXinputi;
    public InputField pYinputi;
    public InputField pZinputi;
    public InputField pMAINinputi;*/

    public GameObject Chair;
    public GameObject Table;
    public GameObject Book_shelf;
    public GameObject Torchere;
    public GameObject Vase;

    public Slider SpXSlider;
    public Slider SpYSlider;
    public Slider SpZSlider;
    public Slider SpotSlider;
    public Dropdown dropd;

    float speed = 0;

    float posvalue = 0f;
    float spovalue = 0f;

    /// <summary>
    /// //////////////////////////////
    /// </summary>
    /// 
    float pXinputvalue = 20f;
    float pYinputvalue = 20f;
    float pZinputvalue = 20f;
    float pMAINinputvalue = 20f;

    /// <summary>
    /// //////////////////////////////
    /// </summary>
    /// 

    int nf = 0;


    // Use this for initialization
    void Start()
    {
        this.ScaleSpot = GameObject.Find("ScaleSpot");
        this.objtouch = GameObject.Find("TouchManager");
    }


    public void PCHair()
    {

        GameObject go = Instantiate(Chair) as GameObject;
        go.name = ("Chair"+ "(" + nf + ")");
        go.transform.localPosition = new Vector3();
        this.nf = nf + 1;
    }
    public void PTAble()
    {
        GameObject go = Instantiate(Table) as GameObject;
        go.name = ("Table" + "(" + nf + ")");
        go.transform.localPosition = new Vector3();
        this.nf = nf + 1;
    }
    public void PBOok_self()
    {
        GameObject go = Instantiate(Book_shelf) as GameObject;
        go.name = ("Book_shelf" + "(" + nf + ")");
        go.transform.localPosition = new Vector3();
        this.nf = nf + 1;
    }

    public void TOrchere() {
        GameObject go = Instantiate(Torchere) as GameObject;
        go.name = ("Torchere" + "(" + nf + ")");
        go.transform.localPosition = new Vector3();
        this.nf = nf + 1;
    }

    public void PVAse()
    {
        GameObject go = Instantiate(Vase) as GameObject;
        go.name = ("Vase" + "(" + nf + ")");
        go.transform.localPosition = new Vector3();
        this.nf = nf + 1;
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
            this.posvalue = PosSlider.value;
            pXSlider.value = GameObject.transform.localPosition.x;
            pYSlider.value = GameObject.transform.localPosition.y;
            pZSlider.value = GameObject.transform.localPosition.z;

            PosSlider.value = 0;
            this.tooitoggle = 0;
        }

        if (tooitoggle == 0)
        {
            if (GameObject.name == "trash")
            {
            }
            else
            {
                if (GameObject.GetComponent<Sensor>().dropv == 0)
                {
                    GameObject.transform.localPosition = new Vector3(pXSlider.value, pYSlider.value, pZSlider.value);
                    ScaleSpot.transform.localPosition = new Vector3((pXSlider.value + sxSlider.value) * SpXSlider.value, (pYSlider.value + (sYSlider.value * 5f)) / 10 + 0 + (SpYSlider.value * 10), pZSlider.value + (SpZSlider.value * 10));
                    if (PosSlider.value == this.posvalue)
                    {

                    }
                    else
                    {
                        this.posvalue = PosSlider.value;
                        GameObject.transform.localPosition = new Vector3(PosSlider.value, PosSlider.value, PosSlider.value);
                        ScaleSpot.transform.localPosition = new Vector3((PosSlider.value + sxSlider.value) * SpXSlider.value, (PosSlider.value + (sYSlider.value * 5f)) / 10 + 0 + (SpYSlider.value * 10), PosSlider.value + (SpZSlider.value * 10));
                        pXSlider.value = PosSlider.value;
                        pYSlider.value = PosSlider.value;
                        pZSlider.value = PosSlider.value;
                    }




                    if (SpotSlider.value == this.spovalue)
                    {

                    }
                    else
                    {
                        this.spovalue = SpotSlider.value;
                        SpXSlider.value = SpotSlider.value;
                        SpYSlider.value = SpotSlider.value;
                        SpZSlider.value = SpotSlider.value;
                    }
                }
                else if (GameObject.GetComponent<Sensor>().dropv == 1)
                {
                    GameObject.transform.localPosition = new Vector3(pXSlider.value, pYSlider.value, pZSlider.value);
                    ScaleSpot.transform.localPosition = new Vector3((pXSlider.value + 187f) * SpXSlider.value, (pYSlider.value + (187f * 5f)) / 10 + 0 + (SpYSlider.value * 10), pZSlider.value + (SpZSlider.value * 10));
                    if (PosSlider.value == this.posvalue)
                    {

                    }
                    else
                    {
                        this.posvalue = PosSlider.value;
                        GameObject.transform.localPosition = new Vector3(PosSlider.value, PosSlider.value, PosSlider.value);
                        ScaleSpot.transform.localPosition = new Vector3((PosSlider.value + 187f) * SpXSlider.value, (PosSlider.value + (187f * 5f)) / 10 + 0 + (SpYSlider.value * 10), PosSlider.value + (SpZSlider.value * 10));
                        pXSlider.value = PosSlider.value;
                        pYSlider.value = PosSlider.value;
                        pZSlider.value = PosSlider.value;
                    }




                    if (SpotSlider.value == this.spovalue)
                    {

                    }
                    else
                    {
                        this.spovalue = SpotSlider.value;
                        SpXSlider.value = SpotSlider.value;
                        SpYSlider.value = SpotSlider.value;
                        SpZSlider.value = SpotSlider.value;
                    }
                }
                else
                {
                    GameObject.transform.localPosition = new Vector3(pXSlider.value, pYSlider.value, pZSlider.value);
                    ScaleSpot.transform.localPosition = new Vector3((pXSlider.value + 132f) * SpXSlider.value, (pYSlider.value + (132f * 5f)) / 10 + 0 + (SpYSlider.value * 10), pZSlider.value + (SpZSlider.value * 10));
                    if (PosSlider.value == this.posvalue)
                    {

                    }
                    else
                    {
                        this.posvalue = PosSlider.value;
                        GameObject.transform.localPosition = new Vector3(PosSlider.value, PosSlider.value, PosSlider.value);
                        ScaleSpot.transform.localPosition = new Vector3((PosSlider.value + 132f) * SpXSlider.value, (PosSlider.value + (132f * 5f)) / 10 + 0 + (SpYSlider.value * 10), PosSlider.value + (SpZSlider.value * 10));
                        pXSlider.value = PosSlider.value;
                        pYSlider.value = PosSlider.value;
                        pZSlider.value = PosSlider.value;
                    }




                    if (SpotSlider.value == this.spovalue)
                    {

                    }
                    else
                    {
                        this.spovalue = SpotSlider.value;
                        SpXSlider.value = SpotSlider.value;
                        SpYSlider.value = SpotSlider.value;
                        SpZSlider.value = SpotSlider.value;
                    }
                }
            }
        }
    }

    public void SpResetButton()
    {
        SpotSlider.value = 0;
        SpXSlider.value = 0.7f;
        SpYSlider.value = 0;
        SpZSlider.value = 0;
        SpotSlider.value = 0;
        Debug.Log("pulled!");
    }

    public void PoResetButton()
    {
        pXSlider.value = 0;
        pYSlider.value = 0;
        pZSlider.value = 0;
        PosSlider.value = 0;
        Debug.Log("pulled!");
    }
}