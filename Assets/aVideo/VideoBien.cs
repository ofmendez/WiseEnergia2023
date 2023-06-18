using System.Collections.Generic;
using UnityEngine;

class VideoBien : State {
    public VideoBien(int i) : base(i) {
    }

    public override void Handle1() {
        Dictionary<int, int> dictG = new Dictionary<int, int>(){
            {1,2},
            {4,6},
            {6,8},
            {8,10}
        };
        if (dictG.ContainsKey(_index))
            this._videoPContext.TransitionTo(new VideoFelicitacion(dictG[_index]));


        Dictionary<int, int> dictB = new Dictionary<int, int>(){
            {2,5},
            {10,12},
        };
        if (dictB.ContainsKey(_index))
            this._videoPContext.TransitionTo(new VideoMal(dictB[_index]));
    }

    public override void Handle2() {
        Dictionary<int, int> dictG = new Dictionary<int, int>(){
            {2,4},
            {10,13}
        };
        if (dictG.ContainsKey(_index))
            this._videoPContext.TransitionTo(new VideoFelicitacion(dictG[_index]));

        Dictionary<int, int> dictB = new Dictionary<int, int>(){
            {1,3},
            {4,7},
            {6,9},
            {8,11}
        };
        if (dictB.ContainsKey(_index))
            this._videoPContext.TransitionTo(new VideoMal(dictB[_index]));

    }

    public override void HandleStop() {
        Debug.Log("Fin Pregunta");
    }
}