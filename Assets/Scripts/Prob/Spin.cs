using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour {

    private GameObject Cube;
    private ControllCube ControllCube;
    public Texture[] texture;
    private int nTexture;
    private int i, j;
   
    private AudioSource SpinSE;

    void Start() {
        nTexture = texture.Length;
        i = 0;
        j = 0;
        Cube = GameObject.Find("ControllCube");
        ControllCube = Cube.GetComponent<ControllCube>();

		SpinSE = GetComponent<AudioSource>();
    }

    void Update() {
        i++;
        if(i % 3 == 0) {
            j++;
        }
        GetComponent<Renderer>().material.mainTexture = texture[j % nTexture];
    }

    void OnCollisionStay(Collision collision) {
        if(collision.gameObject.tag == "Cube") {
            if(ControllCube.isCubeStop()) {
				ControllCube.State2Spin();
				SpinSE.Play();
            }
        }
    }
}