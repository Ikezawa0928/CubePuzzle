using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CongratsButton : MonoBehaviour {

    public GameObject Screen;
    private int nClick = 0;

    private void Start() {
        PlayerPrefs.SetInt("nTotalStars", 70);
    }

    public void OnClick() {
        nClick++;
        if(nClick > 2) {
            Screen.SetActive(true);
            Screen.GetComponent<CongratsScreen>().toDark();
        }
    }
}
