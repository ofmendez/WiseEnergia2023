using System.Collections.Generic;
using UnityEngine;

class VideoBien : State {
	public VideoBien(int i) : base(i) {
	}

	public override void Handle1() {
		Dictionary<int, int> dictG = new(){
				{1,3},
				{7,9},
		};
		if (dictG.ContainsKey(_index))
			this._videoPContext.TransitionTo(new VideoFelicitacion(dictG[_index]));


		Dictionary<int, int> dictB = new(){
				{3,4},
				{5,6},
		};
		if (dictB.ContainsKey(_index))
			this._videoPContext.TransitionTo(new VideoMal(dictB[_index]));
	}

	public override void Handle2() {
		Dictionary<int, int> dictG = new(){
				{3,5},
				{5,7}
		};
		if (dictG.ContainsKey(_index))
			this._videoPContext.TransitionTo(new VideoFelicitacion(dictG[_index]));

		Dictionary<int, int> dictB = new(){
				{1,2},
				{7,8},
		};
		if (dictB.ContainsKey(_index))
			this._videoPContext.TransitionTo(new VideoMal(dictB[_index]));

	}

	public override void HandleStop() {
		if (_index == (int)VideoType.FINAL)
			this._videoPContext.TransitionTo(new VideoIntro());

		Debug.Log("Fin Pregunta");
	}
}