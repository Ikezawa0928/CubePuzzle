using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutSurface : MonoBehaviour {

    private GameObject Cube;
    public Material[] CubeMaterial;
    public Material[] SurfaceMaterial;

    public GameObject FlashScreen;
    public GameObject Camera;

    private bool once;
    private AudioSource OutSE;

	void Start () {
        Cube = transform.root.gameObject;

        int RondomNumber = Random.Range(0, CubeMaterial.Length);
        Cube.GetComponent<Renderer>().material = CubeMaterial[RondomNumber];
        GetComponent<Renderer>().material = SurfaceMaterial[RondomNumber];

        once = true;
        OutSE = GetComponent<AudioSource>();
	}

    void Update() {
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        transform.localPosition = new Vector3(0, 0.5f, 0);
        transform.localEulerAngles = Vector3.zero;
    }

    void OnCollisionStay(Collision collision) {
        if(collision.gameObject.tag == "Stage") {
            if(Cube.GetComponent<ControllCube>().isCubeStop()) {
                if(once) {
                    once = false;
                    Cube.GetComponent<ControllCube>().State2Freeze();
                    FlashScreen.SetActive(true);
                    FlashScreen.GetComponent<FlashScreen>().ScreenDark(2.0f, 30);
                    Invoke("CubeReset", 30 * Time.deltaTime);
                    Invoke("OutSEPlay", 1 * Time.deltaTime);
                }
            }
        }
    }

    void OutSEPlay() {
        OutSE.Play();
    }

    void CubeReset() {
        once = true;
        Cube.GetComponent<ControllCube>().CubeReset();
        Camera.GetComponent<CameraComponent>().CameraReset();
        FlashScreen.GetComponent<FlashScreen>().State2Shine();
    }
}
