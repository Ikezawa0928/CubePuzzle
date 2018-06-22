using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraLeftButton : MonoBehaviour {

    public GameObject Camera;
    public Sprite LeftArrow1;
    public Sprite LeftArrow2;

    void Start() {
        if(PlayerPrefs.GetInt("nTotalStars") == 70) {
            GetComponent<Image>().sprite = LeftArrow2;
        } else {
            GetComponent<Image>().sprite = LeftArrow1;
        }
    }

    public void OnClick() {
        Camera.GetComponent<CameraComponent>().Move2Left();
        GetComponent<AudioSource>().Play();
    }
}
