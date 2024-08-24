using UnityEngine.Video;

public abstract class State {
	protected VideoPContext _videoPContext;
	protected VideoClip _clip;
	protected int _index;

	public State(VideoClip clip, int index) {
		this._clip = clip;
		this._index = index;
	}
	public State() { }
	public State(int index) {
		this._index = index;
	}

	public void SetContext(VideoPContext context) {
		this._videoPContext = context;
	}

	public abstract void Handle1();

	public abstract void Handle2();
	public abstract void HandleStop();

	public virtual int getIndex() {
		return _index;
	}
}