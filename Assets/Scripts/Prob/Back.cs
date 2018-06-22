using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Back : MonoBehaviour {

    private GameObject Cube;
    private ControllCube ControllCube;
    public Texture[] texture;
    private int nTexture;
    private int i, j;

    private Vector3 Point;

    private AudioSource BackSE;

    void Start() {
        nTexture = texture.Length;
        i = 0;
        j = 0;
        Cube = GameObject.Find("ControllCube");
        ControllCube = Cube.GetComponent<ControllCube>();

        BackSE = GetComponent<AudioSource>();
    }

    void Update() {
        i++;
        if(i % 15 == 0) {
            j++;
        }
        GetComponent<Renderer>().material.mainTexture = texture[j % nTexture];
    }

    void OnCollisionStay(Collision collision) {
        if(collision.gameObject.tag == "Cube") {
            if(ControllCube.isCubeStop()) {
                ControllCube.CubeBack();
                BackSE.Play();
            }
        }
    }
}
