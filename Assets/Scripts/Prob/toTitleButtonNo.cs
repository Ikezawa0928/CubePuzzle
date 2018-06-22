using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toTitleButtonNo : MonoBehaviour {

    public GameObject FlashScreen;
    public GameObject ConfirmButton;
    public GameObject ControllCube;
    public GameObject Camera;
    public AudioClip SE;

    public void OnClick() {
        FlashScreen.GetComponent<FlashScreen>().State2Shine();
        ConfirmButton.GetComponent<ButtonAppear>().Disappear();
        ControllCube.GetComponent<ControllCube>().State2Stop();
        AudioSource.PlayClipAtPoint(SE, new Vector3(Camera.transform.position.x, Camera.transform.position.y-1, Camera.transform.position.z));
    }
}
