using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class nFlickText : MonoBehaviour {

    private int nFlick;
    public GameObject ProbSetting;
    private int MaxFlick;
    private Text ThisText;

	void Start () {
        ThisText = GetComponent<Text>();
        nFlick = 0;
        MaxFlick = ProbSetting.GetComponent<ProbSetting>().MaxFlick;
        if(PlayerPrefs.GetInt("nTotalStars") == 70) {
            GetComponent<Text>().color = Color.white;
        }
	}
	
	void Update () {
        if(nFlick <= MaxFlick) {
            ThisText.text = "<color=#00ff00>" + nFlick + "</color>" + " / " + MaxFlick;
        } else if(nFlick <= MaxFlick * 1.5f) {
            ThisText.text = "<color=#ffff00>" + nFlick + "</color>" + " / " + MaxFlick;
        } else {
            ThisText.text = "<color=#ff0000>" + nFlick + "</color>" + " / " + MaxFlick;
        }
	}

    public void FlickCount() {
        nFlick++;
    }

    public void FlickReset() {
        nFlick = 0;
    }

    public int GetNFlick() {
        return nFlick;
    }

    public int GetMaxFlick() {
        return MaxFlick;
    }
}
