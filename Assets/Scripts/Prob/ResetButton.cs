using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetButton : MonoBehaviour {

    public GameObject FlashScreen;
    public GameObject ControllCube;
    public GameObject Camera;

    public void OnClick() {
        FlashScreen.SetActive(true);
        FlashScreen.GetComponent<FlashScreen>().ScreenFlash(40);
        Invoke("CubeReset", 20*Time.deltaTime);
        GetComponent<AudioSource>().Play();
    }

    void CubeReset() {
        ControllCube.GetComponent<ControllCube>().CubeReset();
        Camera.GetComponent<CameraComponent>().CameraReset();
    }
}
