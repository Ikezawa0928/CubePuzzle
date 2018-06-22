using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transport : MonoBehaviour {

    private GameObject Cube;
    private ControllCube ControllCube;
    public Texture[] texture;
    private int nTexture;
    private int i, j;
    public GameObject Partner;
    private float Partner_x;
    private float Partner_z;

    private AudioSource TransportSE;

    void Start() {
        nTexture = texture.Length;
        i = 0;
        j = 0;
        Cube = GameObject.Find("ControllCube");
        ControllCube = Cube.GetComponent<ControllCube>();
        Partner_x = Partner.transform.position.x;
        Partner_z = Partner.transform.position.z;

        TransportSE = GetComponent<AudioSource>();
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
                ControllCube.State2Transport(Partner_x, Partner_z);
                TransportSE.Play();
            }
        }
    }
}