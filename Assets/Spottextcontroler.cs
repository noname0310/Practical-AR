using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spottextcontroler : MonoBehaviour {

    public GameObject spottext;
    public GameObject scalespot;
    public GameObject arcam;


	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        spottext.transform.localPosition = new Vector3 (scalespot.transform.localPosition.x+2f, scalespot.transform.localPosition.y, scalespot.transform.localPosition.z);

        spottext.gameObject.GetComponent<TextMesh>().text = ("1m / " + string.Format("{0:###0. 00}",scalespot.transform.localScale.y));
        spottext.gameObject.transform.localRotation = Quaternion.Euler(arcam.gameObject.transform.localRotation.x, arcam.gameObject.transform.localRotation.y, arcam.gameObject.transform.localRotation.z);
    }
}
