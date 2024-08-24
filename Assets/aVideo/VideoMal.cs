using UnityEngine;
using System.Collections.Generic;


class VideoMal : State {
	public VideoMal(int i) : base(i) {
	}

	public override void Handle1() {
		Debug.Log("ConcreteStateB handles request1.");
	}

	public override void Handle2() {
		Debug.Log("ConcreteStateB handles request2.");
	}

	public override void HandleStop() {
		Dictionary<int, int> dictB = new(){
				{2,3},
				{4,5},
				{6,7},
				{8,9}
				// {11,8},
				// {12,10}
		};
		if (_index == (int)VideoType.FINAL)
			this._videoPContext.TransitionTo(new VideoFinal());
		else if (dictB.ContainsKey(_index))
			this._videoPContext.TransitionTo(new VideoBien(dictB[_index]));
	}
}