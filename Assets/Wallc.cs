using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;
using UnityEngine.SceneManagement;

public class Wallc : MonoBehaviour {

    Animator animator;

    public GameObject Canvas_up;
    public GameObject Canvas_down;
    public GameObject Canvas_wallC;

    public GameObject wall;
    public GameObject wall1;

    public GameObject ImageTargetwc;
    public GameObject ImageTargetwc2;

    public GameObject ARcamara;

    public GameObject lg;

    public int togglespot = 1;
    public int togglemodel = 1;

    public Toggle ModelToggle;
    public Toggle scaleSpot;


    int move = 1; //0이면 벽이 안따라다님 1이면 따라다님

    // Use this for initialization
    void Start () {
        //GameObject go = Instantiate(lg) as GameObject;
        //go.transform.localPosition = new Vector3();

        this.animator = GetComponent<Animator>();
        this.Canvas_up = GameObject.Find("Canvas_up");
        this.Canvas_down = GameObject.Find("Canvas_down");
        this.Canvas_wallC = GameObject.Find("Canvas_wallC");
        this.wall = GameObject.Find("wall");
        this.wall1 = GameObject.Find("wall1");
        this.ImageTargetwc = GameObject.Find("ImageTargetwc");
        this.ImageTargetwc2 = GameObject.Find("ImageTargetwc2");
        this.ARcamara = GameObject.Find("ARCamera");
    }

    int can = 0;
	// Update is called once per frame
	void Update () {

        if (lightint.lightload > 0)
        {
            lg.GetComponent<Light>().intensity = 1f;///////////////////////////////////////////////////////
        }
        //Debug.Log(togglespot);

        if (Canvas_up.GetComponent<Canvas>().enabled == true) //ar모드일때
        {
            wall.SetActive(false);
            wall1.SetActive(false);
        }
        else
        {
            wall.SetActive(true);
            wall1.SetActive(true);
        }
        if(move == 1)
        {
            wall.transform.parent = GameObject.Find("ImageTargetwc").transform;
            wall.transform.localPosition = new Vector3(0, 1 ,0.4f);
            //wall.transform.localRotation = Quaternion.Euler(ImageTargetwc.transform.eulerAngles.x,0, ImageTargetwc.transform.eulerAngles.z);

            wall1.transform.parent = GameObject.Find("ImageTargetwc2").transform;
            wall1.transform.localPosition = new Vector3(0, 1, 0.4f);
            //wall1.transform.localRotation = Quaternion.Euler(ImageTargetwc2.transform.eulerAngles.x, 0, ImageTargetwc2.transform.eulerAngles.z);
        }
        else if(move == 0)
        {
            wall.transform.parent = null;
            wall1.transform.parent = null;
        }


	    if(Canvas_wallC.GetComponent<Canvas>().enabled == true)//이 캔버스가 활성화 되어있다면
        {
            //한번만 실행
            if(can == 1)
            {
                can = 0;
                this.animator.SetTrigger("gopen");//오픈 애니메이션 실행
            }
            //////
        }
        else
        {
            can = 1;
        }
	}

    public static class lightint
    {
        public static int lightload;
    }

    public void Closeslide()
    {
        //lightint.lightload = lightint.lightload + 1;
        StartCoroutine(Cs());
        
        //Debug.Log(lightint.lightload);
    }

    public void VuforiaReload()//////////////////////////////////////////////////////////////////////
    {
        lightint.lightload = lightint.lightload + 1;
        //ARcamara.GetComponent<VuforiaBehaviour>().enabled = false;
        //ARcamara.GetComponent<VuforiaBehaviour>().enabled = true;
        SceneManager.LoadScene("AR");
        togglemodel = 1;
        togglespot = 1;
    }

    public IEnumerator Cs()
    {
        this.animator.SetTrigger("gclose");
        yield return new WaitForSeconds(1f);
        Canvas_up.GetComponent<Canvas>().enabled = true;
        Canvas_down.GetComponent<Canvas>().enabled = true;
        Canvas_wallC.GetComponent<Canvas>().enabled = false;

    }

    int wftoggle = 0;
}
