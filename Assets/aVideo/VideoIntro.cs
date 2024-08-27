using UnityEngine;

class VideoIntro : State {
	public VideoIntro() {
	}

	public override void Handle1() {
		Debug.Log("ConcreteStateB handles request1.");
		this._videoPContext.TransitionTo(new VideoBien((int)VideoType.INITIAL));
	}

	public override void Handle2() {
		Debug.Log("ConcreteStateB handles request2.");
		this._videoPContext.TransitionTo(new VideoBien((int)VideoType.INITIAL));
	}

	public override void HandleStop() {
		// this._videoPContext.TransitionTo(new VideoBien((int)VideoType.INITIAL));
	}
	public override int getIndex() {
		return (int)VideoType.INTRO;
	}
}