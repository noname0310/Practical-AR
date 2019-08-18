using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;

public class ScreenShot : MonoBehaviour
{
    private AndroidUltimatePluginController androidUltimatePluginController;

    Animator animator;

    public Toggle ScaleToggle;
    public Toggle PosToggle;
    public Toggle RotToggle;
    public Image Fcanvas;

    public Image downFcanvas;
    public Button sutter;
    public Image shotoutput;
    public Toggle modeltogle;
    public Toggle scalespot;

    public GameObject canavas_up;
    public GameObject canavas_down;


    Camera mainCamera;
    RenderTexture renderTex;
    Texture2D screenshot;
    Texture2D LoadScreenshot;
    int width = Screen.width;   // for Taking Picture
    int height = Screen.height; // for Taking Picture
    string fileName;
    string screenShotName = "screenshot" + System.DateTime.Now.ToString("yyyy-MM-dd-HHmmss") + ".png";
    private bool isProcessing = false;
    public string mensaje;


    void Start()
    {
        androidUltimatePluginController = AndroidUltimatePluginController.GetInstance();
        this.animator = GetComponent<Animator>();
    }

    public void Snapshot()
    {
        //Inv();
        StartCoroutine(CaptureScreen());
        //this.animator.SetTrigger("shot");
        //this.animator.SetTrigger("shott");
        //V();
    }

    public void Inv()
    {
        /*ScaleToggle.gameObject.SetActive (false);
        PosToggle.gameObject.SetActive(false);
        RotToggle.gameObject.SetActive(false);
        sutter.gameObject.SetActive(false);
        modeltogle.gameObject.SetActive(false);
        scalespot.gameObject.SetActive(false);
        downFcanvas.gameObject.GetComponent<Image>().enabled = false;
        Fcanvas.gameObject.GetComponent<Image>().enabled = false;*/
        canavas_up.GetComponent<Canvas>().enabled = false;
        canavas_down.GetComponent<Canvas>().enabled = false;
    }

    public void V()
    {
        /*ScaleToggle.gameObject.SetActive(true);
        PosToggle.gameObject.SetActive(true);
        RotToggle.gameObject.SetActive(true);
        sutter.gameObject.SetActive(true);
        modeltogle.gameObject.SetActive(true);
        scalespot.gameObject.SetActive(true);
        downFcanvas.gameObject.GetComponent<Image>().enabled = true;
        Fcanvas.gameObject.GetComponent<Image>().enabled = true;*/
        canavas_up.GetComponent<Canvas>().enabled = true;
        canavas_down.GetComponent<Canvas>().enabled = true;
    }

    public IEnumerator CaptureScreen()
    {
        Inv();
        yield return new WaitForSeconds(0.5f);

        isProcessing = true;
        // wait for graphics to render
        yield return new WaitForEndOfFrame();
        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- PHOTO
        // create the texture
        Texture2D screenTexture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, true);
        // put buffer into texture
        screenTexture.ReadPixels(new Rect(0f, 0f, Screen.width, Screen.height), 0, 0);
        // apply
        screenTexture.Apply();
        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- PHOTO
        byte[] dataToSave = screenTexture.EncodeToPNG();
        string destination = Path.Combine(Application.persistentDataPath, System.DateTime.Now.ToString("yyyy-MM-dd-HHmmss") + ".png");
        File.WriteAllBytes(destination, dataToSave);
        if (!Application.isEditor)
        {
            // block to open the file and share it ------------START
            AndroidJavaClass intentClass = new AndroidJavaClass("android.content.Intent");
            AndroidJavaObject intentObject = new AndroidJavaObject("android.content.Intent");
            intentObject.Call<AndroidJavaObject>("setAction", intentClass.GetStatic<string>("ACTION_SEND"));
            AndroidJavaClass uriClass = new AndroidJavaClass("android.net.Uri");
            AndroidJavaObject uriObject = uriClass.CallStatic<AndroidJavaObject>("parse", "file://" + destination);
            intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_STREAM"), uriObject);

            intentObject.Call<AndroidJavaObject>("setType", "text/plain");
            intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_TEXT"), "" + mensaje);
            intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_SUBJECT"), "SUBJECT");

            intentObject.Call<AndroidJavaObject>("setType", "image/jpeg");
            AndroidJavaClass unity = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            AndroidJavaObject currentActivity = unity.GetStatic<AndroidJavaObject>("currentActivity");

            currentActivity.Call("startActivity", intentObject);
        }
        isProcessing = false;
        sutter.enabled = true;

        yield return new WaitForSeconds(0.5f);
        this.animator.SetTrigger("shot");
        this.animator.SetTrigger("shott");
        V();
        /*yield return null; // Wait till the last possible moment before screen rendering to hide the UI

        GameObject.Find("Canvas").GetComponent<Canvas>().enabled = false;
        yield return new WaitForEndOfFrame(); // Wait for screen rendering to complete
        if (Screen.orientation == ScreenOrientation.Portrait || Screen.orientation == ScreenOrientation.PortraitUpsideDown)
        {
            mainCamera = Camera.main.GetComponent<Camera>(); // for Taking Picture
            renderTex = new RenderTexture(width, height, 24);
            mainCamera.targetTexture = renderTex;
            RenderTexture.active = renderTex;
            mainCamera.Render();
            screenshot = new Texture2D(width, height, TextureFormat.RGB24, false);
            screenshot.ReadPixels(new Rect(0, 0, width, height), 0, 0);
            screenshot.Apply(); //false
            RenderTexture.active = null;
            mainCamera.targetTexture = null;
        }
        if (Screen.orientation == ScreenOrientation.LandscapeLeft || Screen.orientation == ScreenOrientation.LandscapeRight)
        {
            mainCamera = Camera.main.GetComponent<Camera>(); // for Taking Picture
            renderTex = new RenderTexture(height, width, 24);
            mainCamera.targetTexture = renderTex;
            RenderTexture.active = renderTex;
            mainCamera.Render();
            screenshot = new Texture2D(height, width, TextureFormat.RGB24, false);
            screenshot.ReadPixels(new Rect(0, 0, height, width), 0, 0);
            screenshot.Apply(); //false
            RenderTexture.active = null;
            mainCamera.targetTexture = null;
        }
        // on Win7 - C:/Users/Username/AppData/LocalLow/CompanyName/GameName
        // on Android - /Data/Data/com.companyname.gamename/Files
        File.WriteAllBytes("mnt/sdcard/DCIM/Camara"+ screenShotName, screenshot.EncodeToPNG());
        GameObject.Find("Canvas").GetComponent<Canvas>().enabled = true; // Show UI after we're done*/
    }
    /*int resWidth = 1280;
    int resHeight = 752;
    public Camera ARCamera;
    public Image shotOutput;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Press()
    {
        //take a screenshot
        Capture.TakeScreenShot();
        
        //you need to wait a small amount of time for the screenshot to be saved
        Invoke("Get", 0.5f);

        shotOutput.sprite = Capture.GetScreenShot_Sprite();
    }



    /*
    public Sprite TakeHiResShot()
    {
        string date = System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
        string myFilename = "myScreenshot_" + date + ".png";
        // debugText.text = ": " + myFilename;
        string myDefaultLocation = Application.persistentDataPath + "/" + myFilename;
        //EXAMPLE OF DIRECTLY ACCESSING THE Camera FOLDER OF THE GALLERY
        //string myFolderLocation = "/storage/emulated/0/DCIM/Camera/";
        //EXAMPLE OF BACKING INTO THE Camera FOLDER OF THE GALLERY
        //string myFolderLocation = Application.persistentDataPath + "/../../../../DCIM/Camera/";
        //EXAMPLE OF DIRECTLY ACCESSING A CUSTOM FOLDER OF THE GALLERY
        string myFolderLocation = "/storage/emulated/0/DCIM/AR/";
        string myScreenshotLocation = myFolderLocation + myFilename;
        //ENSURE THAT FOLDER LOCATION EXISTS
        if (!System.IO.Directory.Exists(myFolderLocation))
        {
            System.IO.Directory.CreateDirectory(myFolderLocation);
        }
        //TAKE THE SCREENSHOT AND AUTOMATICALLY SAVE IT TO THE DEFAULT LOCATION.

        //  캔버스 포함 전체 스크린샷!!
        //Application.CaptureScreenshot(myScreenshotLocation);
        //
        //
        //


        
        //  캔버스 제외 카메라에 보이는 부분만 스크린 샷!!
        RenderTexture rt = new RenderTexture(resWidth, resHeight, 24);
        ARCamera.targetTexture = rt;
        Texture2D screenShot = new Texture2D(resWidth, resHeight, TextureFormat.RGB24, false);
        Rect rec = new Rect(0, 0, screenShot.width, screenShot.height);
        ARCamera.Render();
        RenderTexture.active = rt;
        screenShot.ReadPixels(new Rect(0, 0, resWidth, resHeight), 0, 0);
        screenShot.Apply();

        TempImage = Sprite.Create(screenShot, rec, new Vector2(0, 0), .01f);

        ARCamera.targetTexture = null;
        RenderTexture.active = null; // JC: added to avoid errors
        Destroy(rt);

        byte[] bytes = screenShot.EncodeToPNG();
        System.IO.File.WriteAllBytes(myScreenshotLocation, bytes);
        


    // 안드로이드 갤러리, 사진첩 업데이트 부분
    // 요거 안하면 "내파일" 에서는 보이지만 갤러리 및 사진첩 어플에서는 보이지 않는 문제가 생김!!!  

    //MOVE THE SCREENSHOT WHERE WE WANT IT TO BE STORED
    //  System.IO.File.Move(myDefaultLocation, myScreenshotLocation);
    //REFRESHING THE ANDROID PHONE PHOTO GALLERY IS BEGUN
    AndroidJavaClass classPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject objActivity = classPlayer.GetStatic<AndroidJavaObject>("currentActivity");
        AndroidJavaClass classUri = new AndroidJavaClass("android.net.Uri");
        // "android.intent.action.MEDIA_SCANNER_SCAN_FILE" <--- 요거 햇갈림.. 원래 찾은건 "android.intent.action.MEDIA_MOUNTED" 요렇게 하라고 나와있는데 안되서 저렇게 하니 됨.
        AndroidJavaObject objIntent = new AndroidJavaObject("android.content.Intent", new object[2] { "android.intent.action.MEDIA_SCANNER_SCAN_FILE", classUri.CallStatic<AndroidJavaObject>("parse", "file://" + myScreenshotLocation) });
        objActivity.Call("sendBroadcast", objIntent);
        // debugText.text = "Complete! - " + myScreenshotLocation;
        //REFRESHING THE ANDROID PHONE PHOTO GALLERY IS COMPLETE
        //AUTO LAUNCH/VIEW THE SCREENSHOT IN THE PHOTO GALLERY!!!
        // Application.OpenURL(myScreenshotLocation);
        //AFTERWARDS IF YOU MANUALLY GO TO YOUR PHOTO GALLERY,
        //YOU WILL SEE THE FOLDER WE CREATED CALLED "myFolder"
        // count++;

        //return TempImage;
    }
    */
}