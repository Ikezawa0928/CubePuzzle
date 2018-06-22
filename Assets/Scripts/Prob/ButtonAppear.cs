using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAppear : MonoBehaviour {

    private enum STATE { appear, disappear };
    private STATE state = STATE.appear;

	void Start () {
        state = STATE.appear;
	}
	
	void Update () {
        switch(state) {
            case STATE.appear :
                if(transform.localScale.y < 1) {
                    transform.localScale = new Vector3(1, transform.localScale.y + 0.5f, 1);
                }
                break;
            case STATE.disappear :
                if(transform.localScale.y > 0) {
                    transform.localScale = new Vector3(1, transform.localScale.y - 0.5f, 1);
                } else {
                    this.gameObject.SetActive(false);
                }
                break;
        }
	}

    public void Disappear() {
        state = STATE.disappear;
    }

    public void Appear() {
        state = STATE.appear;
    }
}
