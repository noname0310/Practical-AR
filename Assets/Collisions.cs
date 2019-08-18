using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collisions : MonoBehaviour {

    Rigidbody2D rigid2D;

    public Toggle ScaleToggle;

    // Use this for initialization
    void Start () {
        this.rigid2D = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
	}
    
    public void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("goal");
    }
    
}
