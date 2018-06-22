using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slide : MonoBehaviour {

    private ControllCube Cube;
    public Texture[] texture;
    private int nTexture;
    private int i, j;

    private AudioSource SlideSE;

    void Start() {
        nTexture = texture.Length;
        i = 0;
        j = 0;

        Cube = GameObject.Find("ControllCube").GetComponent<ControllCube>();

        SlideSE = GetComponent<AudioSource>();
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
            if(Cube.isCubeStop()) {
                if(transform.eulerAngles.y < 5 || 355 < transform.eulerAngles.y) {
                    Cube.State2UpSlide();
                } else if(85 < transform.eulerAngles.y && transform.eulerAngles.y < 95) {
                    Cube.State2RightSlide();
                } else if(175 < transform.eulerAngles.y && transform.eulerAngles.y < 185) {
                    Cube.State2DownSlide();
                } else if(265 < transform.eulerAngles.y && transform.eulerAngles.y < 275) {
                    Cube.State2LeftSlide();
                }
                SlideSE.Play();
            }
        }
    }
}
