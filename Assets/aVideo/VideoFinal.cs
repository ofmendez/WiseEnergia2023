using UnityEngine;

class VideoFinal : State {
    public VideoFinal() {
    }

    public override void Handle1() {
        Debug.Log("ConcreteStateB handles request1.");
    }

    public override void Handle2() {
        Debug.Log("ConcreteStateB handles request2.");
    }

    public override void HandleStop() {
        this._videoPContext.TransitionTo(new VideoIntro());
    }
    public override int getIndex() {
        return (int)VideoType.FINAL;
    }
}