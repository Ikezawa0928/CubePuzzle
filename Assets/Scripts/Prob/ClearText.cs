using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ClearText : MonoBehaviour {

    public GameObject CongratsMessage1;
    public GameObject CongratsMessage2;
    public GameObject CongratsMessage3;
    public GameObject FlashScreen;
    public GameObject nFlickText;
    public GameObject Paper;
    public GameObject ProbSetting;

    private int StageNumber;
    private string StageTitle;

    private int time;
    private Text ThisText;
    private int fontsize;

    private bool check;
    private int check_time;

    void Start() {
        time = 0;
        ThisText = GetComponent<Text>();
        fontsize = 6;
        check = false;
        check_time = 0;
        StageNumber = ProbSetting.GetComponent<ProbSetting>().StageNumber;
        StageTitle = "Prob" + StageNumber.ToString("00");
        if(nFlickText.GetComponent<nFlickText>().GetNFlick() == nFlickText.GetComponent<nFlickText>().GetMaxFlick()) {
            Instantiate(Paper, Vector3.zero, Quaternion.Euler(0, 0, 0));
            if(PlayerPrefs.GetInt(StageTitle) < 2) {
                var n = PlayerPrefs.GetInt("nTotalStars");
                PlayerPrefs.SetInt("nTotalStars", n + 1);
                PlayerPrefs.SetInt(StageTitle, 2);
                check = true;
            }
        } else {
            if(PlayerPrefs.GetInt(StageTitle) < 1) {
                PlayerPrefs.SetInt(StageTitle, 1);
            }
        }
    }

    void Update() {
        time += 8;
        if(time < 90) {
            fontsize = (int)(fontsize * 1.375f);
            ThisText.fontSize = fontsize;
            transform.localPosition = new Vector3(15, -280 * Mathf.Sin(time * Mathf.Deg2Rad) + 305, 0);
        } else {
            if(Input.GetKeyDown(KeyCode.Mouse0)) {
                if(nFlickText.GetComponent<nFlickText>().GetNFlick() == nFlickText.GetComponent<nFlickText>().GetMaxFlick()) {
                    if(check) {
                        var n = PlayerPrefs.GetInt("nTotalStars");
                        if(n == 15) {
                            check_time++;
                            if(check_time >= 2) {
                                check = false;
                            }
                            CongratsMessage1.SetActive(true);
                        } else if(n == 30) {
                            check_time++;
                            if(check_time >= 2) {
                                check = false;
                            }
                            CongratsMessage2.SetActive(true);
                        } else if(n == 50) {
                            check_time++;
                            if(check_time >= 2) {
                                check = false;
                            }
                            CongratsMessage3.SetActive(true);
                        } else {
                            FlashScreen.SetActive(true);
                            FlashScreen.GetComponent<FlashScreen>().ScreenDark(1.2f, 12);
                            Invoke("Scene2Title", 15 * Time.deltaTime);
                        }
                    } else {
                        FlashScreen.SetActive(true);
                        FlashScreen.GetComponent<FlashScreen>().ScreenDark(1.2f, 12);
                        Invoke("Scene2Title", 15 * Time.deltaTime);
                    }
                } else {
                    FlashScreen.SetActive(true);
                    FlashScreen.GetComponent<FlashScreen>().ScreenDark(1.2f, 12);
                    Invoke("Scene2Title", 15 * Time.deltaTime);
                }
            }
        }
    }

    void Scene2Title() {
        if(PlayerPrefs.GetInt("nTotalStars") == 69) {
            TitleController.AdTime = 0;
            SceneManager.LoadScene("Congrats");
        } else {
            TitleController.AdTime++;
            SceneManager.LoadScene("Title");
        }
    }
}
