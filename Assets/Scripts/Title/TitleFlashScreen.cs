using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using NendUnityPlugin.AD;

public class TitleFlashScreen : MonoBehaviour {

    private enum STATE { toShine, toDark , stop};
    private STATE state = STATE.toShine;

    private float speed;
    private Color ScreenColor;

    private int random;

    void Start() {
        state = STATE.stop;
        speed = 6;
        ScreenColor.a = 1.2f;
        Invoke("State2Shine", 0.3f);
        random = Random.Range(20, 40);
    }

    void Update () {
        switch(state) {
            case STATE.toShine :
                if(ScreenColor.a > 0) {
                    ScreenColor.a -= speed * 0.01f;
                } else {
                    if(TitleController.AdTime > random / 10) {
                        TitleController.AdTime = 0;
                        NendAdInterstitial.Instance.Show();
                    }
                    this.gameObject.SetActive(false);
                }
                break;
            case STATE.toDark :
                if(ScreenColor.a < 1.2f) {
                    ScreenColor.a += speed * 0.01f;
                }
                break;
            case STATE.stop :
                break;
        }
        GetComponent<Image>().color = ScreenColor;
	}

    public void State2Shine() {
        state = STATE.toShine;
    }

    public void State2Dark() {
        state = STATE.toDark;
    }

    public void State2Stop() {
        state = STATE.stop;
    }

    public void ScreenDark(float DarkPoint, int DarkTime) {
        speed = DarkPoint / (DarkTime * 0.01f);
        State2Dark();
        Invoke("State2Stop", DarkTime*Time.deltaTime);
    }

    public void ScreenFlash(int FlashTime) {
        speed = 120 / Mathf.CeilToInt(FlashTime / 2.0f);
        State2Dark();
        Invoke("State2Shine", Mathf.CeilToInt(FlashTime / 2.0f)*Time.deltaTime);
    }
}
