using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wall_col : MonoBehaviour {

    Rigidbody2D rigid2D;

    public Image lmagered;

    public Image glass;

    // Use this for initialization
    void Start()
    {
        this.rigid2D = GetComponent<Rigidbody2D>();
    }

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("enter");
        this.GetComponent<Renderer>().material.color = lmagered.color;
    }
    public void OnTriggerExit(Collider other)
    {
        Debug.Log("exit");
        this.GetComponent<Renderer>().material.color = glass.color;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
