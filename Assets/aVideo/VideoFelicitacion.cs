using UnityEngine;

class VideoFelicitacion : State {
	public VideoFelicitacion(int i) : base(i) {
	}

	public override void Handle1() {
		Debug.Log("ConcreteStateB handles request1.");
	}

	public override void Handle2() {
		Debug.Log("ConcreteStateB handles request2.");
	}

	public override void HandleStop() {
		if (_index == (int)VideoType.FINAL)
			this._videoPContext.TransitionTo(new VideoFinal());
		else
			this._videoPContext.TransitionTo(new VideoBien(_index));
	}

	public override int getIndex() {
		return (int)VideoType.FELICITACION;
	}
}