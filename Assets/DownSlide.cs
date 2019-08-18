using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;

public class DownSlide : MonoBehaviour
{

    Animator animator;
    public Toggle ModelToggle;
    public Image downFCanvas;
    public Button sutter;
    public Toggle scalespot;


    int modtoggle = 0;
    int spottoggle = 0;

    void Start()
    {
        this.animator = GetComponent<Animator>();
    }

    public void Modelslide()
    {
        if (ModelToggle.isOn)
        {
            modtoggle = 1;
            this.animator.SetTrigger("down");
            this.animator.SetTrigger("normal");
            //transform.Translate(0, -950, 0);
            //downFCanvas.transform.Translate(0, 950, 0);
            //sutter.transform.Translate(0, 950, 0);
            //scalespot.transform.Translate(0, 950, 0);
            Debug.Log("pulled!");
        }
        else
        {
            modtoggle = 0;
            this.animator.SetTrigger("up");
            //transform.Translate(0, 950, 0);
            //downFCanvas.transform.Translate(0, -950, 0);
            //sutter.transform.Translate(0, -950, 0);
            //scalespot.transform.Translate(0, -950, 0);
            Debug.Log("pulled!");
        }
    }
    public void Spotslide()
    {
        if (scalespot.isOn)
        {
            modtoggle = 1;
            //transform.Translate(0, -520, 0);
            //downFCanvas.transform.Translate(0, 950, 0);
            //sutter.transform.Translate(0, 950, 0);
            //ModelToggle.transform.Translate(0, 950, 0);
            Debug.Log("pulled!");
        }
        else
        {
            modtoggle = 0;
            //transform.Translate(0, 520, 0);
            //downFCanvas.transform.Translate(0, -950, 0);
            //sutter.transform.Translate(0, -950, 0);
            //ModelToggle.transform.Translate(0, -950, 0);
            Debug.Log("pulled!");
        }
    }
}

