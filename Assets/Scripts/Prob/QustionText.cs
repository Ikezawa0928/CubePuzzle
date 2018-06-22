using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QustionText : MonoBehaviour {

    public GameObject ProbSetting;
    private int StageNumber;

	void Start () {
        StageNumber = ProbSetting.GetComponent<ProbSetting>().StageNumber;
        GetComponent<Text>().text = "Question. " + StageNumber.ToString("00");

        if(PlayerPrefs.GetInt("nTotalStars") == 70) {
            GetComponent<Text>().color = Color.white;
        }
	}
}
