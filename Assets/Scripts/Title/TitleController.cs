using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NendUnityPlugin.AD;

public class TitleController : MonoBehaviour {

    public GameObject[] Titles;
    public GameObject Button1;
    public GameObject Button2;
    public GameObject StageSelect1;
    public GameObject StageSelect2;
    public GameObject StageSelect3;
    public GameObject StageSelect4;

    private enum STATE { Title, StageSelect };
    private static STATE state = STATE.Title;

    private int TotalStars;
    public static int AdTime = 0;

    private void Start() {
        #if UNITY_IOS
        NendAdInterstitial.Instance.Load("d57ced582714e6dfffda25a7f9d864da40461896","712655");
        #elif UNITY_ANDROID
        NendAdInterstitial.Instance.Load("e7c37441fe1d734cab05e0e317788a89054b6602","712656");
        #endif

		PlayerPrefs.SetInt("nTotalStars", 71); //デバッグ用 配信するときは外す
		TotalStars = PlayerPrefs.GetInt("nTotalStars");
	}

    void Update () {
        switch(state) {
            case STATE.Title:
                foreach(var Title in Titles) {
                    Title.SetActive(true);
                }
                Button1.SetActive(false);
                Button2.SetActive(false);
                StageSelect1.SetActive(false);
                StageSelect2.SetActive(false);
                StageSelect3.SetActive(false);
                StageSelect4.SetActive(false);
                break;
            case STATE.StageSelect:
                foreach(var Title in Titles) {
                    Title.SetActive(false);
                }
                Button1.SetActive(true);
                Button2.SetActive(true);
                if(TotalStars < 15) {
                    StageSelect1.SetActive(true);
                    StageSelect2.SetActive(false);
                    StageSelect3.SetActive(false);
                    StageSelect4.SetActive(false);
                    if(SnapScrollRect.hIndex == 0) {
                        Button1.SetActive(false);
                    } else if(SnapScrollRect.hIndex == 3) {
                        Button2.SetActive(false);
                    }
                } else if(TotalStars < 30) {
                    StageSelect1.SetActive(false);
                    StageSelect2.SetActive(true);
                    StageSelect3.SetActive(false);
                    StageSelect4.SetActive(false);
                    if(SnapScrollRect.hIndex == 0) {
                        Button1.SetActive(false);
                    } else if(SnapScrollRect.hIndex == 3) {
                        Button2.SetActive(false);
                    }
                } else if(TotalStars < 50) {
                    StageSelect1.SetActive(false);
                    StageSelect2.SetActive(false);
                    StageSelect3.SetActive(true);
                    StageSelect4.SetActive(false);
                    if(SnapScrollRect.hIndex == 0) {
                        Button1.SetActive(false);
                    } else if(SnapScrollRect.hIndex == 3) {
                        Button2.SetActive(false);
                    }
                } else {
                    StageSelect1.SetActive(false);
                    StageSelect2.SetActive(false);
                    StageSelect3.SetActive(false);
                    StageSelect4.SetActive(true);
                    if(SnapScrollRect.hIndex == 0) {
                        Button1.SetActive(false);
                    } else if(SnapScrollRect.hIndex == 3) {
                        Button2.SetActive(false);
                    }
                }
                break;
        }
	}

    public void State2Title() {
        state = STATE.Title;
    }

    public void State2StageSelect() {
        state = STATE.StageSelect;
    }
}
