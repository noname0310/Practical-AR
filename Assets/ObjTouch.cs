using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjTouch : MonoBehaviour {

    public string objname;
    public int select = 0;

    public GameObject gameobject;
    public GameObject objtouch;
    public GameObject Cmsg;

    Animator animator;

    public Text msgtext;

    // Use this for initialization
    void Start () {
        this.Cmsg = GameObject.Find("CanvasMSG");
        this.animator = Cmsg.GetComponent<Animator>();

        this.objtouch = GameObject.Find("TouchManager");
        msgtext.GetComponent<Text>().text = (" ");
    }

    int destroysig = 0;
    public void ModelDelete()
    {
        if (gameobject.name == "trash")
        {

        }
        else
        {
            Destroy(gameobject);
            destroysig = 1;
        }

    }

    // Update is called once per frame
    void Update()
    {

        this.gameobject = GameObject.Find(objtouch.GetComponent<ObjTouch>().objname);

        if (this.destroysig == 1)
        {
            this.destroysig = 0;
            this.select = 0;
            this.animator.SetTrigger("ginfo");
            msgtext.GetComponent<Text>().text = (this.objname + " was not selected");
            Debug.Log("trash");
            this.objname = "trash";
        }

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 300f))
            {
                if(this.select == 0)
                {
                    if (hit.transform.name == "Plane")
                    {
                        
                    }
                    else if (hit.transform.name == "Planesu")
                    {

                    }
                    else if (hit.transform.name == "wall")
                    {

                    }
                    else if (hit.transform.name == "wall1")
                    {

                    }
                    else if (hit.transform.name == "Image12")
                    {

                    }
                    else if (hit.transform.name == "Image123")
                    {

                    }
                    else
                    {
                        this.select = 1;

                        Debug.Log(hit.transform.name);
                        this.objname = hit.transform.name;
                        this.animator.SetTrigger("ginfo");
                        msgtext.GetComponent<Text>().text = (this.objname +" was selected");
                    }
                }
                else if (this.select == 1)
                {
                    if (hit.transform.name == this.objname)
                    {
                        if (hit.transform.name == "Plane")
                        {

                        }
                        else if (hit.transform.name == "Planesu")
                        {

                        }
                        else if (hit.transform.name == "wall")
                        {

                        }
                        else if (hit.transform.name == "wall1")
                        {

                        }
                        else if (hit.transform.name == "Image12")
                        {

                        }
                        else if (hit.transform.name == "Image123")
                        {

                        }
                        else
                        {
                            this.select = 0;
                            this.animator.SetTrigger("ginfo");
                            msgtext.GetComponent<Text>().text = (this.objname + " was not selected");
                            Debug.Log("trash");
                            this.objname = "trash";
                            
                        }
                    }
                    else
                    {
                        if (hit.transform.name == "Plane")
                        {

                        }
                        else if (hit.transform.name == "Planesu")
                        {

                        }
                        else if (hit.transform.name == "wall")
                        {

                        }
                        else if (hit.transform.name == "wall1")
                        {

                        }
                        else if (hit.transform.name == "Image12")
                        {

                        }
                        else if (hit.transform.name == "Image123")
                        {

                        }
                        else
                        {
                            this.select = 1;

                            Debug.Log(hit.transform.name);
                            this.objname = hit.transform.name;
                            this.animator.SetTrigger("ginfo");
                            msgtext.GetComponent<Text>().text = (this.objname + " was selected");
                        }
                    }
                }
            }
        }
    }
}
