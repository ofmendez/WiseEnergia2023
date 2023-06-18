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
        Dictionary<int, int> dictB = new Dictionary<int, int>(){
            {3,1},
            {5,2},
            {7,4},
            {9,6},
            {11,8},
            {12,10}
        };
        if (dictB.ContainsKey(_index))
            this._videoPContext.TransitionTo(new VideoBien(dictB[_index]));
    }
}