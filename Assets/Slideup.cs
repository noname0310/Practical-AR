using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slideup : MonoBehaviour {

    Animator animator;
    Rigidbody2D rigid2D;

    public Toggle ScaleToggle;
    public Toggle PosToggle;
    public Toggle RotToggle;

    public GameObject gameobject;
    public GameObject objtouch;

    public GameObject Planesu;

    public GameObject Canvas_up;
    public GameObject Canvas_down;
    public GameObject Canvas_wallC;

    public GameObject image12;

    int transpervalue = 0;
    int scaletoggle = 0;
    int postoggle = 0;
    int rottoggle = 0;
    int open = 0;

    int coldable = 0;

    public int allupInfo = 0;

    public int os = 0;

    public Toggle ModelToggle;
    public Toggle scaleSpot;

    void Start()
    {
        this.animator = GetComponent<Animator>();
        this.rigid2D = GetComponent<Rigidbody2D>();
        this.objtouch = GameObject.Find("TouchManager");
        this.Planesu = GameObject.Find("Planesu");
        this.Canvas_up = GameObject.Find("Canvas_up");
        this.Canvas_down = GameObject.Find("Canvas_down");
        this.Canvas_wallC = GameObject.Find("Canvas_wallC");
    }

    public void LBslide()
    {
        StartCoroutine(Ls());
    }

    public IEnumerator Ls()
    {
        if (Canvas_wallC.GetComponent<Wallc>().togglespot == 0)
        {
            Canvas_wallC.GetComponent<Wallc>().togglespot = 1;
            scaleSpot.isOn = true;
            yield return new WaitForSeconds(0.7f);
        }
        if (Canvas_wallC.GetComponent<Wallc>().togglemodel == 0)
        {
            Canvas_wallC.GetComponent<Wallc>().togglemodel = 1;
            ModelToggle.isOn = true;
            yield return new WaitForSeconds(0.7f);
        }
        Canvas_up.GetComponent<Canvas>().enabled = false;
        Canvas_down.GetComponent<Canvas>().enabled = false;
        Canvas_wallC.GetComponent<Canvas>().enabled = true;
    }


    int coll = 0;

    public void OnTriggerEnter2D(Collider2D other)
    {
        coll = 1;//모델슬라이드가 열리면 1
    }
    public void OnTriggerExit2D(Collider2D other)
    {
        coll = 0; //모델슬라이드가 닫히면 0
    }

    public void Scaleanislide()
    {
        if (ScaleToggle.isOn)
        {
            scaletoggle = 1;
            this.animator.SetTrigger("Size_up");
            this.animator.SetTrigger("Size_stop");
            this.open = 0;
            this.coldable = 0;
            gameobject.GetComponent<BoxCollider>().enabled = true;//////////////////////////////////
            Debug.Log("pulled!");
        }
        else
        {
            scaletoggle = 0;
            this.animator.SetTrigger("Size_down");
            this.open = 1;

            this.coldable = 1;
            Debug.Log("pulled!");
        }
    }


    public void Posanislide()
    {
        if (PosToggle.isOn)
        {
            postoggle = 1;
            this.animator.SetTrigger("Pos_up");
            this.animator.SetTrigger("Pos_stop");
            this.open = 0;
            this.coldable = 0;

            gameobject.GetComponent<BoxCollider>().enabled = true;//////////////////////////////////////////
            Debug.Log("pulled!");
        }
        else
        {
            postoggle = 0;
            this.animator.SetTrigger("Pos_down");
            this.open = 2;

            this.coldable = 1;
            Debug.Log("pulled!");
        }
    }

    public void Rotanislide()
    {
        if (RotToggle.isOn)
        {
            rottoggle = 1;
            this.animator.SetTrigger("Rot_up");
            this.animator.SetTrigger("Rot_stop");
            this.open = 0;
            this.coldable = 0;
            gameobject.GetComponent<BoxCollider>().enabled = true;
            Debug.Log("pulled!");
        }
        else
        {
            rottoggle = 0;
            this.animator.SetTrigger("Rot_down");
            this.open = 3;

            this.coldable = 1;
            Debug.Log("pulled!");
        }
    }

    public void Alup()
    {
        if (this.open == 1)
        {
            ScaleToggle.isOn = true;
            scaletoggle = 1;
            this.open = 0;
            this.animator.SetTrigger("Size_up");
            this.animator.SetTrigger("Size_stop");
            this.animator.SetTrigger("allupt");
        }
        else if (this.open == 2)
        {
            PosToggle.isOn = true;
            postoggle = 1;
            this.open = 0;
            this.animator.SetTrigger("Pos_up");
            this.animator.SetTrigger("Pos_stop");
            this.animator.SetTrigger("allupt");
        }
        else if (this.open == 3)
        {
            RotToggle.isOn = true;
            rottoggle = 1;
            this.open = 0;
            this.animator.SetTrigger("Rot_up");
            this.animator.SetTrigger("Rot_stop");
            this.animator.SetTrigger("allupt");
        }
        else if (this.open == 0)
        {
            this.open = 0;
            this.animator.SetTrigger("allupt");
        }
        else
        {

        }
    }

    int run = 0;
    int run2 = 0;

    int urun = 0;
    int urun2 = 0;

    int arun = 0;
    int arun2 = 0;

    int lb = 0; //거리버튼 활성화 여부 0= 비활성화 1= 활성화
    int mt = 0; //무브툴 활성화 여부 0= 비활성화 1= 활성화
    private void Update()
    {

        this.gameobject = GameObject.Find(objtouch.GetComponent<ObjTouch>().objname);//게임오브젝트 갱신

        if (this.coldable == 1)//오브젝트 선택하고 툴 열시에 콜라이더 비활성화 /갱신
        {
            gameobject.GetComponent<BoxCollider>().enabled = false;
        }
        //////////////////////////////////////////////////////////


        if (objtouch.GetComponent<ObjTouch>().select == 1) ///////////////////////////////////////////오브젝트를 선택했을떄
        {
            if (coll == 1)//모델슬라이드가 열렸을떄
            {
                if (this.urun == 0)//한번만실행 (모델슬라이드와 상호작용)
                {
                    this.urun = 1;
                    //this.animator.SetTrigger("allupt");//무브툴 비활성화
                    Alup();
                    mt = 0;//무브툴 정보갱신
                    this.urun2 = 0;
                }
            }
            else if (coll == 0) //모델슬라이드가 닫혔을떄
            {
                if (urun2 == 0)//한번만실행 (모델슬라이드와 상호작용)
                {
                    this.urun2 = 1;// 변수갱신
                    this.animator.SetTrigger("alldownt");//무브툴 활성화
                    mt = 1;//무브툴 정보갱신
                    this.urun = 0;//변수갱신
                }

                if (this.run == 0)//한번만 실행 (셀렉트변수와 상호작용)
                {
                    this.run = 1;
                    ///////////////////////////////////////////////////////////////무브툴 활성화

                    this.animator.SetTrigger("alldownt");//무브툴 활성화
                    mt = 1;//무브툴 정보갱신
                    if (lb == 1) //거리버튼이 활성화 되어있는 경우
                    {
                        this.animator.SetTrigger("auclou"); //거리 버튼 비활성화 (거리버튼이 활성화 되어있는경우)
                        lb = 0; //거리버튼 정보갱신
                    }
                    this.run2 = 0;
                }
                    
                ///////////////////////////////////////
            }
        }
        else ////////////////////////////////////////////////////////////////////////////////////////오브젝트를 선택해제했을떄
        {
            if (coll == 1)//모델슬라이드가 열렸을떄
            {
                if (this.arun == 0)//한번만실행 (모델슬라이드와 상호작용)
                {
                    this.arun = 1;
                    this.animator.SetTrigger("auclou"); //거리버튼 비활성화
                    lb = 0;//거리버튼 정보갱신
                    this.arun2 = 0;
                }
            }
            else if (coll == 0) //모델슬라이드가 닫혔을떄
            {
                if(arun2 == 0)
                {
                    this.arun2 = 1;
                    this.animator.SetTrigger("auclg"); //거리버튼 활성화
                    lb = 1;//거리버튼 정보갱신
                    this.arun = 0;
                }
                
                if (this.run2 == 0)//한번만 실행 (셀렉트변수와 상호작용)
                {
                    this.run2 = 1;
                    ///////////////////////////////////////////////////////////////거리버튼 활성화
                    this.animator.SetTrigger("auclg"); //거리버튼 활성화
                    lb = 1;//거리버튼 정보갱신
                    if (mt == 1) // 무브툴이 활성화되어있는경우
                    {
                        this.animator.SetTrigger("allupt"); //무브툴 비활성화 (무브툴이 활성화 되어있는경우)
                        mt = 0;//무브툴 정보갱신
                    }
                    ////////////////////////////////////////
                    this.run = 0;
                }
            }
        }
    }

            /*int lb = 0;//거리 측정 버튼의 활성화 여부 0 는 비왛성화  1 은 호ㅘㄹ성화

            private void Update()
            {

                this.gameobject = GameObject.Find(objtouch.GetComponent<ObjTouch>().objname);//게임오브젝트 갱신

                if (this.coldable == 1)//오브젝트 선택하고 툴 열시에 콜라이더 비활성화 /갱신
                {
                    gameobject.GetComponent<BoxCollider>().enabled = false;
                }
                //////////////////////////////////////////////////////////

                if (objtouch.GetComponent<ObjTouch>().select == 1) //오브젝트를 선택했을떄
                {
                    if (coll == 1) //모델슬라이드가 열렸을떄
                    {
                        //활성화된무브툴을 비활성화시킴/   한번만
                        if (this.urun == 0)
                        {
                            this.urun = 1;
                            Alup();
                            this.animator.SetTrigger("auclg");
                            lb = 0; //거리측정 버튼 할성화 여부 갱신 (비활성화)
                            this.urun2 = 0;
                        }
                        //////////////////////////////////
                    }
                    else if (coll == 0) //모델슬라이드가 닫혔을떄
                    {
                        //값초기화
                        if (this.urun2 == 0)
                        {
                            this.urun2 = 1;
                            this.animator.SetTrigger("auclou");
                            lb = 1; //거리측정 버튼 할성화 여부 갱신 (활성화)
                            this.urun = 0;
                        }
                        ////////////////

                        //무브툴을 내리는 명령(보이기)  한번만
                        if (this.run == 0)
                        {
                            this.run = 1;
                            this.animator.SetTrigger("alldownt");
                            this.animator.SetTrigger("allstopt");
                            this.run2 = 0;
                        }
                        //////
                    }
                }
                else //선택해제 했을때
                {
                    if (coll == 1) //모델슬라이드가 열렸을떄
                    {
                        if (lb == 1)//만약에 활성화 되있다면
                        {
                            //활성화된거리측정버튼을 비활성화시킴/   한번만
                            if (this.arun == 0)
                            {
                                this.arun = 1;
                                //(위쪽에 거리측정버튼 활성화)
                                this.animator.SetTrigger("auclg");
                                lb = 0; //거리측정 버튼 할성화 여부 갱신 (비활성화)
                                this.arun2 = 0;
                            }
                            /////////////////
                        }
                    }
                    else if (coll == 0) //모델슬라이드가 닫혔을떄
                    {
                        if (lb == 0)//만약에 비활성화 되있다면
                        {
                            //비활성화된거리측정버튼을 활성화시킴/   한번만
                            if (this.arun2 == 0)
                            {
                                //값초기화
                                this.arun2 = 1;
                                this.animator.SetTrigger("auclou");
                                lb = 1; //거리측정 버튼 할성화 여부 갱신 (활성화)
                                this.arun = 0;
                                ////////////////
                            }
                            ///////////////////
                        }


                        //무브툴을 올리는 명령(숨기기)  한번만
                        if (this.run2 == 0)
                        {
                            this.run2 = 1;
                            Alup();
                            this.animator.SetTrigger("auclg");
                            lb = 0; //거리측정 버튼 할성화 여부 갱신 (비활성화)
                            this.run = 0;
                        }
                        /////
                    }
                }
            }*/

            /*
            public void Scaleanislide()
            {
                if (ScaleToggle.isOn)
                {
                    scaletoggle = 1;
                    this.animator.SetTrigger("Size_up");
                    this.animator.SetTrigger("Size_stop");
                    this.open = 0;
                    this.coldable = 0;
                    gameobject.GetComponent<BoxCollider>().enabled = true;
                    os = 0;
                    Debug.Log("pulled!");
                }
                else
                {
                    scaletoggle = 0;
                    this.animator.SetTrigger("Size_down");
                    this.open = 1;

                    this.coldable = 1;
                    Debug.Log("pulled!");
                }
            }


            public void Posanislide()
            {
                if (PosToggle.isOn)
                {
                    postoggle = 1;
                    this.animator.SetTrigger("Pos_up");
                    this.animator.SetTrigger("Pos_stop");
                    this.open = 0;
                    this.coldable = 0;

                    gameobject.GetComponent<BoxCollider>().enabled = true;
                    os = 0;
                    Debug.Log("pulled!");
                }
                else
                {
                    postoggle = 0;
                    this.animator.SetTrigger("Pos_down");
                    this.open = 2;

                    this.coldable = 1;
                    Debug.Log("pulled!");
                }
            }

            public void Rotanislide()
            {
                if (RotToggle.isOn)
                {
                    rottoggle = 1;
                    this.animator.SetTrigger("Rot_up");
                    this.animator.SetTrigger("Rot_stop");
                    this.open = 0;
                    this.coldable = 0;
                    gameobject.GetComponent<BoxCollider>().enabled = true;
                    os = 0;
                    Debug.Log("pulled!");
                }
                else
                {
                    rottoggle = 0;
                    this.animator.SetTrigger("Rot_down");
                    this.open = 3;

                    this.coldable = 1;
                    Debug.Log("pulled!");
                }
            }

            public void Alup() {
                if (this.open == 1)
                {
                    ScaleToggle.isOn = true;
                    scaletoggle = 1;
                    this.open = 0;
                    this.animator.SetTrigger("Size_up");
                    this.animator.SetTrigger("Size_stop");
                    this.animator.SetTrigger("allupt");
                }
                else if (this.open == 2)
                {
                    PosToggle.isOn = true;
                    postoggle = 1;
                    this.open = 0;
                    this.animator.SetTrigger("Pos_up");
                    this.animator.SetTrigger("Pos_stop");
                    this.animator.SetTrigger("allupt");
                }
                else if (this.open == 3)
                {
                    RotToggle.isOn = true;
                    rottoggle = 1;
                    this.open = 0;
                    this.animator.SetTrigger("Rot_up");
                    this.animator.SetTrigger("Rot_stop");
                    this.animator.SetTrigger("allupt");
                }
                else if (this.open == 0)
                {
                    this.open = 0;
                    this.animator.SetTrigger("allupt");
                }
                else
                {

                }
            }

            public int auciinfo = 0;

            public void OnTriggerEnter2D(Collider2D other)
            {
                if (allupInfo == 0)
                {
                    Debug.Log("goal");
                    Planesu.GetComponent<BoxCollider>().enabled = false;
                    os = 1;
                    Alup();
                    //this.animator.SetTrigger("auclg");
                    allupInfo = 1;
                }
                else if (allupInfo == 1){
                    this.animator.SetTrigger("auclg");
                    auciinfo = 1;
                }
            }
            public void OnTriggerExit2D(Collider2D other)
            {
                if (allupInfo == 0)
                {
                    if (auciinfo == 0)
                    {
                        this.open = 0;
                        Debug.Log("goal");
                        Planesu.GetComponent<BoxCollider>().enabled = true;
                        os = 0;
                        this.animator.SetTrigger("alldownt");
                        this.animator.SetTrigger("allstopt");
                        allupInfo = 0;
                    }
                }
                else if(allupInfo == 1)
                {

                    this.animator.SetTrigger("auclou");
                    auciinfo = 0;
                }
            }



            int run = 0;
            int run2 = 0;

            private void Update()
            {

                this.gameobject = GameObject.Find(objtouch.GetComponent<ObjTouch>().objname);

                if (objtouch.GetComponent<ObjTouch>().select == 1)
                {
                    if (this.run == 0)
                    {
                        this.run = 1;
                        //this.GetComponent<BoxCollider2D>().offset = new Vector2(0,880);
                        Planesu.GetComponent<BoxCollider>().enabled = true;
                        os = 0;
                        this.animator.SetTrigger("alldownt");
                        this.animator.SetTrigger("allstopt");
                        allupInfo = 0;
                        this.run2 = 0;
                    }
                }
                else
                {
                    if (this.run2 == 0)
                    {
                        this.run2 = 1;
                        //this.GetComponent<BoxCollider2D>().offset = new Vector2(0, 88000);
                        Planesu.GetComponent<BoxCollider>().enabled = false;
                        os = 1;
                        Alup();
                        //this.animator.SetTrigger("auclg");
                        allupInfo = 1;
                        this.run = 0;
                    }
                }


                if(this.coldable == 1)
                {
                    gameobject.GetComponent<BoxCollider>().enabled = false;
                    os = 1;
                }
            }*/
        }
