using UnityEngine;
using UnityEngine.Video;

//  Cables: brdg
//  videos: ed
//  control: bb

public enum VideoType {
    INTRO = 14,
    FELICITACION = 0,
    FINAL = 13,
    INITIAL = 1
}

public class Main : MonoBehaviour {
    public VideoPContext context;

    public VideoClip[] clips;

    void Awake() {
        context = new VideoPContext(new VideoIntro(), GetComponent<VideoPlayer>(), clips);
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.E)) {
            context.Button1();
            print("E key was pressed");
        }
        if (Input.GetKeyDown(KeyCode.D)) {
            context.Button2();
            print("D key was pressed");
        }
        if (Input.GetKeyDown(KeyCode.B)) {
            context.TransitionTo(new VideoIntro());
        }
    }
}
