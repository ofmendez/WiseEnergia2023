using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
//  Cables: b rdg
//  videos: ed
//  control: bb
public class Main2 : MonoBehaviour {
    public float ammountFill = 0.01f;
    public LifeBar lifeBar1;
    public LifeBar lifeBar2;
    public LifeBar lifeBar3;
    public Image mainBar;
    public Image message1;
    public Image message2;
    public Image endAction2;
    public Image endAction3;
    VideoPlayer videoPlayer;
    TimeCounter timeCounter;
    

    void Awake() {
        videoPlayer = FindObjectOfType<VideoPlayer>(true);
        timeCounter = FindObjectOfType<TimeCounter>();
        videoPlayer.loopPointReached += EndReached;
    }
    void Update() {
        if (Input.GetKeyDown(KeyCode.R)) {
            lifeBar1.Inject(ammountFill);
            mainBar.fillAmount = lifeBar1.bar.fillAmount/3f;
            if(lifeBar1.bar.fillAmount >= 0.99f) 
                message1.gameObject.SetActive(true);
            if(!timeCounter.isRunning)
                timeCounter.StartTimer();
        }

        if (Input.GetKeyDown(KeyCode.D) && lifeBar1.bar.fillAmount >= 0.99f) {
            lifeBar2.Inject(ammountFill);
            mainBar.fillAmount = (1+lifeBar2.bar.fillAmount)/3f;
            if(lifeBar2.bar.fillAmount >= 0.99f) 
                message2.gameObject.SetActive(true);
            if(lifeBar2.bar.fillAmount >= 0.8f)
                endAction2.gameObject.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.G) && lifeBar2.bar.fillAmount >= 0.99f) {
            lifeBar3.Inject(ammountFill);
            mainBar.fillAmount = (2+lifeBar3.bar.fillAmount)/3f;
            if(lifeBar3.bar.fillAmount >= 0.8f) 
                endAction3.gameObject.SetActive(true);
            if(lifeBar3.bar.fillAmount >= 0.99f) {
                videoPlayer.gameObject.SetActive(true);
                videoPlayer.Play();
            }
        }
    }

    void EndReached(VideoPlayer vp) {
        ResetScene();
    }

    private void ResetScene() {
        mainBar.fillAmount = 0;
        lifeBar1.bar.fillAmount = 0;
        lifeBar2.bar.fillAmount = 0;
        lifeBar3.bar.fillAmount = 0;
        message1.gameObject.SetActive(false);
        message2.gameObject.SetActive(false);
        endAction2.gameObject.SetActive(false);
        endAction3.gameObject.SetActive(false);
        videoPlayer.gameObject.SetActive(false);
        timeCounter.ResetTimer();
    }
}
