using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class toTitleButtonYes : MonoBehaviour {

    public GameObject FlashScreen;

    public void OnClick() {
        FlashScreen.SetActive(true);
        FlashScreen.GetComponent<FlashScreen>().ScreenDark(1.2f, 10);
        Invoke("Scene2Title", 12*Time.deltaTime);
        GetComponent<AudioSource>().Play();
    }

    void Scene2Title() {
        TitleController.AdTime++;
        SceneManager.LoadScene("Title");
    }
}
