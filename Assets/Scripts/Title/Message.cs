using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Message : MonoBehaviour {

    private int time;
    private int interval;
    private Vector4 Color1;
    private Vector4 Color2;
    private AudioSource audio;
    private bool check;

    void Start() {
        time = 0;
        Color1 = GetComponent<Text>().color;
        Color2 = new Vector4(Color1.x, Color1.y, Color1.z, 0);
        interval = 20;
        audio = GetComponent<AudioSource>();
        check = true;
    }

    void Update() {
        time++;
        if((time/interval)%2 == 0) {
            GetComponent<Text>().color = Color1;
        } else {
            GetComponent<Text>().color = Color2;
        }

        if(Input.GetKeyDown(KeyCode.Mouse0)) {
            if(check) {
                check = false;
                interval = 4;
                Invoke("toStageSelect", 1.5f);
                audio.Play();
            }
        }
    }

    void toStageSelect() {
        GameObject.Find("TitleController").GetComponent<TitleController>().State2StageSelect();
    }
}
