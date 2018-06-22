using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraRightButton : MonoBehaviour {

    public GameObject Camera;
    public Sprite RightArrow1;
    public Sprite RightArrow2;

    void Start() {
        if(PlayerPrefs.GetInt("nTotalStars") == 70) {
            GetComponent<Image>().sprite = RightArrow2;
        } else {
            GetComponent<Image>().sprite = RightArrow1;
        }
    }

    public void OnClick() {
        Camera.GetComponent<CameraComponent>().Move2Right();
        GetComponent<AudioSource>().Play();
    }
}
