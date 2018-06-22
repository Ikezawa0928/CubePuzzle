using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clear : MonoBehaviour {

    public GameObject FlashScreen;
    public GameObject ClearText;

    private GameObject Cube;
    private ControllCube ControllCube;
    public Texture[] texture;
    private int nTexture;
    private int i, j;

    private AudioSource ClearSE;

    void Start() {
        nTexture = texture.Length;
        i = 0;
        j = 0;

        Cube = GameObject.Find("ControllCube");
        ControllCube = Cube.GetComponent<ControllCube>();
        ClearText.SetActive(false);

        ClearSE = GetComponent<AudioSource>();
    }

    void Update() {
        i++;
        if(i % 2 == 0) {
            j++;
        }
        GetComponent<Renderer>().material.mainTexture = texture[j % nTexture];
    }

    void OnCollisionStay(Collision collision) {
        if(collision.gameObject.tag == "Cube") {
            if(ControllCube.isCubeStop()) {
                ControllCube.State2Freeze();
                ClearText.SetActive(true);
                FlashScreen.SetActive(true);
                FlashScreen.GetComponent<FlashScreen>().ScreenDark(0.4f, 3);
                ClearSE.Play();
            }
        }
    }
}
