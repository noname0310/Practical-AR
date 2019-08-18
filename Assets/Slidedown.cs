using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slidedown : MonoBehaviour
{

    Animator animator;

    public Toggle ModelToggle;
    public Toggle SpotToggle;

    int modtoggle = 0;
    int spottoggle = 0;

    public GameObject gameobject;
    public GameObject objtouch;

    public GameObject wallc;

    public int osd = 0;

    void Start()
    {
        this.animator = GetComponent<Animator>();
        this.objtouch = GameObject.Find("TouchManager");
        this.wallc = GameObject.Find("Canvas_wallC");
    }

    int coldable = 0;

    private void Update()
    {
        this.gameobject = GameObject.Find(objtouch.GetComponent<ObjTouch>().objname);
        if(this.coldable == 1)
        {
            gameobject.GetComponent<BoxCollider>().enabled = false;
            osd = 1;
        }
    }

    public void Modelanislide()
    {
        if (ModelToggle.isOn)
        {
            modtoggle = 1;
            wallc.GetComponent<Wallc>().togglemodel = 1;
            this.animator.SetTrigger("down");
            this.animator.SetTrigger("normal");
            //transform.Translate(0, -950, 0);
            //downFCanvas.transform.Translate(0, 950, 0);
            //sutter.transform.Translate(0, 950, 0);
            //scalespot.transform.Translate(0, 950, 0);
            this.coldable = 0;
            gameobject.GetComponent<BoxCollider>().enabled = true;
            osd = 0;
            Debug.Log("unpulled!");
        }
        else
        {
            modtoggle = 0;
            wallc.GetComponent<Wallc>().togglemodel = 0;
            this.animator.SetTrigger("up");
            this.coldable = 1;
            Debug.Log("pulled!");
        }
    }
    public void Spotanislide()
    {
        if (SpotToggle.isOn)
        {
            spottoggle = 1;
            wallc.GetComponent<Wallc>().togglespot = 1;
            this.animator.SetTrigger("Spot_down");
            this.animator.SetTrigger("Spot_stop");
            this.coldable = 0;
            gameobject.GetComponent<BoxCollider>().enabled = true;
            osd = 0;
            Debug.Log("unpulled!");
        }
        else
        {
            spottoggle = 0;
            wallc.GetComponent<Wallc>().togglespot = 0;
            this.animator.SetTrigger("Spot_up");
            this.coldable = 1;
            Debug.Log("pulled!");
        }
    }
}
