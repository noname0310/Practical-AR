using UnityEngine;
using System.Collections;
using System.IO;

public class takeScreenShot : MonoBehaviour
{
    public GameObject canavas_up;
    public GameObject canavas_down;

    Animator animator;

    void Start()
    {
        this.animator = GetComponent<Animator>();
    }

    public void Go()
    {
        StartCoroutine(Invreal());
        StartCoroutine(TakeScreenshot());
        StartCoroutine(Vreal());

    }

    public void Inv()
    {
        canavas_up.GetComponent<Canvas>().enabled = false;
        canavas_down.GetComponent<Canvas>().enabled = false;
    }

    public void V()
    {
        canavas_up.GetComponent<Canvas>().enabled = true;
        canavas_down.GetComponent<Canvas>().enabled = true;
    }

    private IEnumerator Invreal()
    {
        Inv();
        yield return new WaitForSeconds(1.5f);
    }
    private IEnumerator Vreal()
    {
        yield return new WaitForSeconds(1.5f);
        V();
        this.animator.SetTrigger("shot");
        this.animator.SetTrigger("shott");
    }
    private IEnumerator TakeScreenshot()
    {
        //Inv();

        yield return new WaitForEndOfFrame();

        string date = System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
        string myFilename = "screenshot" + date + ".png";
        string myDefaultLocation = Application.persistentDataPath + "/" + myFilename;
        string myFolderLocation = "/storage/emulated/0/DCIM/PractialAR";
        string myScreenshotLocation = myFolderLocation + "/" + myFilename;

        if (!Directory.Exists(myFolderLocation))
        {
            Directory.CreateDirectory(myFolderLocation);
        }

#if UNITY_2017_1_OR_NEWER
        ScreenCapture.CaptureScreenshot(myFilename);
#else
        Application.CaptureScreenshot(myFilename);
#endif

        AndroidJavaClass classPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject objActivity = classPlayer.GetStatic<AndroidJavaObject>("currentActivity");
        AndroidJavaClass classUri = new AndroidJavaClass("android.net.Uri");

        // 안드로이드 Media scan 실행
        // android.intent.action.MEDIA_MOUNTED는 4.4+ 이후부터 퍼미션 문제가 있으므로
        // android.intent.action.MEDIA_SCANNER_SCAN_FILE intent를 사용.
        // myDefaultLocation 경로 파일을 먼저 scan 진행
        AndroidJavaObject objIntent = new AndroidJavaObject("android.content.Intent", new object[2] { "android.intent.action.MEDIA_SCANNER_SCAN_FILE", classUri.CallStatic<AndroidJavaObject>("parse", "file://" + myDefaultLocation) });
        objActivity.Call("sendBroadcast", objIntent);
        // 파일 스캔이 완료할 수 있도록 충분한 시간 대기하기
        // 만약 문제가 발생할 경우 대기시간을 조정.
        yield return new WaitForSeconds(1f);

        // 파일 옮기기
        File.Move(myDefaultLocation, myScreenshotLocation);

        // DCIM 스크린샷 파일도 마찬가지로 scan하기
        AndroidJavaObject objIntent2 = new AndroidJavaObject("android.content.Intent", new object[2] { "android.intent.action.MEDIA_SCANNER_SCAN_FILE", classUri.CallStatic<AndroidJavaObject>("parse", "file://" + myScreenshotLocation) });
        objActivity.Call("sendBroadcast", objIntent2);
        yield return new WaitForSeconds(0.5f);

        Application.OpenURL(myScreenshotLocation);

        //this.animator.SetTrigger("shot");
        //this.animator.SetTrigger("shott");
        //V();
    }
}