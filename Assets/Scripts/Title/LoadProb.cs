using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadProb : MonoBehaviour {

    [SerializeField] private int StarNumber;
    private string ProbTitle;
    private int ProbState;
    public GameObject FlashScreen;
    public Sprite Circle;
    public Sprite ShadowStar;
    public Sprite Star;


    void Start() {
        ProbTitle = "Prob" + StarNumber.ToString("00");
        ProbState = PlayerPrefs.GetInt(ProbTitle);
        if(ProbState == 0) {
            this.GetComponent<Image>().sprite = Circle;
        } else if(ProbState == 1) {
            this.GetComponent<Image>().sprite = ShadowStar;
        } else if(ProbState == 2) {
            this.GetComponent<Image>().sprite = Star;
        }
    }

    public void OnClick() {
        FlashScreen.SetActive(true);
        FlashScreen.GetComponent<TitleFlashScreen>().ScreenDark(1.2f, 10);
        Invoke("Scene2Prob", 12 * Time.deltaTime);
    }

    private void Scene2Prob() {
        SceneManager.LoadScene(ProbTitle);
    }
}
