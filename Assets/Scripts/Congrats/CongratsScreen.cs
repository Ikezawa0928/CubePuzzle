using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CongratsScreen : MonoBehaviour {

    private enum STATE { Stay, Shine, Dark };
    private STATE state;
    private Color ScreenColor;

	void Start () {
        ScreenColor = GetComponent<Image>().color;
        ScreenColor.a = 1.2f;
        state = STATE.Shine;	
    }
	
	void Update () {
        if(state == STATE.Shine) {
            ScreenColor.a -= 0.02f;
            GetComponent<Image>().color = ScreenColor;
            if(ScreenColor.a < 0.02f) {
                state = STATE.Stay;
            }
        } else if(state == STATE.Dark) {
            ScreenColor.a += 0.08f;
            GetComponent<Image>().color = ScreenColor;
            if(ScreenColor.a > 1.2f) {
                SceneManager.LoadScene("Title");
            }
        } else if(state == STATE.Stay) {
            this.gameObject.SetActive(false);
        }
	}

    public void toDark() {
        state = STATE.Dark;
    }
}
