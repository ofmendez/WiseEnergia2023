using UnityEngine;
using UnityEngine.Video;

public class VideoPContext {
	State _state = null;
	VideoClip[] _clips;
	VideoPlayer _player;
	public VideoPContext(State state, VideoPlayer player, VideoClip[] clips) {
		this._clips = clips;
		this._player = player;
		this.TransitionTo(state);
		_player.loopPointReached += EndReached;
	}

	public void TransitionTo(State state) {
		Debug.Log($"VideoPContext: Transition to {state.GetType().Name}.");
		this._state = state;
		this._state.SetContext(this);
		_player.clip = _clips[state.getIndex()];
		_player.Play();
	}

	public void Button1() {
		this._state.Handle1();
	}

	public void Button2() {
		this._state.Handle2();
	}

	void EndReached(VideoPlayer vp) {
		this._state.HandleStop();
	}

}