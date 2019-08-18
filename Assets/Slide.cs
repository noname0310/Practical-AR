using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;

public class Slide : MonoBehaviour {

    public Toggle SizeToggle;
    public Toggle PosToggle;
    public Toggle RotToggle;
    public Image FCanvas;


    int Sizetoggle = 0;
    int Postoggle = 0;
    int Rottoggle = 0;

    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}
 /*
    private static DateTime Delay(int MS)
    {
        DateTime ThisMoment = DateTime.Now;
        TimeSpan duration = new TimeSpan(0, 0, 0, 0, MS);
        ime AfterWards = ThisMoment.Add(duration);

        while (AfterWards >= ThisMoment)
        {
            System.Windows.Forms.Applicaton.DoEvents();
            ThisMoment = DateTime.Now;
        }
        return DateTime.Now;  
    }
    */
    /*
    Vector2 ractTemp = this.SizePanel.transform.localPosition;

    switch (Sizetoggle)
    {
        case 0:
            ractTemp.y -= 0.1f;
            this.Sizetoggle = 1;
            break;
        case 1:
            ractTemp.y += 0.1f;
            this.Sizetoggle = 0;
            break;

    }
    this.SizePanel.transform.localPosition = ractTemp;
    */

}

