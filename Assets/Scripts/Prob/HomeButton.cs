using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeButton : MonoBehaviour {

    public GameObject FlashScreenBack;
    public GameObject ConfirmButton;
    public GameObject ControllCube;

    public void OnClick() {
        FlashScreenBack.SetActive(true);
        ConfirmButton.SetActive(true);
        FlashScreenBack.GetComponent<FlashScreen>().ScreenDark(0.4f,3) ;
        ConfirmButton.GetComponent<ButtonAppear>().Appear();
        ControllCube.GetComponent<ControllCube>().State2Freeze();
        GetComponent<AudioSource>().Play();
    }
}
