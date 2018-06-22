using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickConverter : MonoBehaviour {

    private Flicker FlickScript;
    public GameObject Camera;
    public GameObject ControllCube;
    public GameObject nFlickText;
    private ControllCube CubeScript;
    public GameObject ProbSetting;
    private int nStageHeight;
    private int nStageWidth;
    private AudioSource RollSE;

	void Start () {
        FlickScript = GetComponent<Flicker>();
        CubeScript = ControllCube.GetComponent<ControllCube>();
        nStageHeight = ProbSetting.GetComponent<ProbSetting>().NStageHeight;
        nStageWidth = ProbSetting.GetComponent<ProbSetting>().NStageWidth;
        RollSE = GetComponent<AudioSource>();
	}
	
	void Update () {
        switch(FlickScript.Direction) {
            case "up":
                if(355 < Camera.transform.eulerAngles.y || Camera.transform.eulerAngles.y < 5) {
                    if(Mathf.Abs(ControllCube.transform.position.z + 1) < nStageHeight / 2.0f) {
                        if(CubeScript.isCubeStop()) {
                            nFlickText.GetComponent<nFlickText>().FlickCount();
                            Invoke("SoundPlay", 4 * Time.deltaTime);
                        }
                        CubeScript.State2Up();
                    }
                    FlickScript.Direction = "";
                } else if(85 < Camera.transform.eulerAngles.y && Camera.transform.eulerAngles.y < 95) {
                    if(Mathf.Abs(ControllCube.transform.position.x + 1) < nStageWidth / 2.0f) {
                        if(CubeScript.isCubeStop()) {
                            nFlickText.GetComponent<nFlickText>().FlickCount();
                            Invoke("SoundPlay", 4 * Time.deltaTime);
                        }
                        CubeScript.State2Right();
                    }
                    FlickScript.Direction = "";
                } else if(175 < Camera.transform.eulerAngles.y && Camera.transform.eulerAngles.y < 185) {
                    if(Mathf.Abs(ControllCube.transform.position.z - 1) < nStageHeight / 2.0f) {
                        if(CubeScript.isCubeStop()) {
                            nFlickText.GetComponent<nFlickText>().FlickCount();
                            Invoke("SoundPlay", 4 * Time.deltaTime);
                        }
                        CubeScript.State2Down();
                    }
                    FlickScript.Direction = "";
                } else if(265 < Camera.transform.eulerAngles.y && Camera.transform.eulerAngles.y < 275) {
                    if(Mathf.Abs(ControllCube.transform.position.x - 1) < nStageWidth / 2.0f) {
                        if(CubeScript.isCubeStop()) {
                            nFlickText.GetComponent<nFlickText>().FlickCount();
                            Invoke("SoundPlay", 4 * Time.deltaTime);
                        }
                        CubeScript.State2Left();
                    }
                    FlickScript.Direction = "";
                }
                break;
            case "down":
                if(355 < Camera.transform.eulerAngles.y || Camera.transform.eulerAngles.y < 5) {
                    if(Mathf.Abs(ControllCube.transform.position.z - 1) < nStageHeight / 2.0f) {
                        if(CubeScript.isCubeStop()) {
                            nFlickText.GetComponent<nFlickText>().FlickCount();
                            Invoke("SoundPlay", 4 * Time.deltaTime);
                        }
                        CubeScript.State2Down();
                    }
                    FlickScript.Direction = "";
                } else if(85 < Camera.transform.eulerAngles.y && Camera.transform.eulerAngles.y < 95) {
                    if(Mathf.Abs(ControllCube.transform.position.x - 1) < nStageWidth / 2.0f) {
                        if(CubeScript.isCubeStop()) {
                            nFlickText.GetComponent<nFlickText>().FlickCount();
                            Invoke("SoundPlay", 4 * Time.deltaTime);
                        }
                        CubeScript.State2Left();
                    }
                    FlickScript.Direction = "";
                } else if(175 < Camera.transform.eulerAngles.y && Camera.transform.eulerAngles.y < 185) {
                    if(Mathf.Abs(ControllCube.transform.position.z + 1) < nStageHeight / 2.0f) {
                        if(CubeScript.isCubeStop()) {
                            nFlickText.GetComponent<nFlickText>().FlickCount();
                            Invoke("SoundPlay", 4 * Time.deltaTime);
                        }
                        CubeScript.State2Up();
                    }
                    FlickScript.Direction = "";
                } else if(265 < Camera.transform.eulerAngles.y && Camera.transform.eulerAngles.y < 275) {
                    if(Mathf.Abs(ControllCube.transform.position.x + 1) < nStageWidth / 2.0f) {
                        if(CubeScript.isCubeStop()) {
                            nFlickText.GetComponent<nFlickText>().FlickCount();
                            Invoke("SoundPlay", 4 * Time.deltaTime);
                        }
                        CubeScript.State2Right();
                    }
                    FlickScript.Direction = "";
                }
                break;
            case "right":
                if(355 < Camera.transform.eulerAngles.y || Camera.transform.eulerAngles.y < 5) {
                    if(Mathf.Abs(ControllCube.transform.position.x + 1) < nStageWidth / 2.0f) {
                        if(CubeScript.isCubeStop()) {
                            nFlickText.GetComponent<nFlickText>().FlickCount();
                            Invoke("SoundPlay", 4 * Time.deltaTime);
                        }
                        CubeScript.State2Right();
                    }
                    FlickScript.Direction = "";
                } else if(85 < Camera.transform.eulerAngles.y && Camera.transform.eulerAngles.y < 95) {
                    if(Mathf.Abs(ControllCube.transform.position.z - 1) < nStageHeight / 2.0f) {
                        if(CubeScript.isCubeStop()) {
                            nFlickText.GetComponent<nFlickText>().FlickCount();
                            Invoke("SoundPlay", 4 * Time.deltaTime);
                        }
                        CubeScript.State2Down();
                    }
                    FlickScript.Direction = "";
                } else if(175 < Camera.transform.eulerAngles.y && Camera.transform.eulerAngles.y < 185) {
                    if(Mathf.Abs(ControllCube.transform.position.x - 1) < nStageWidth / 2.0f) {
                        if(CubeScript.isCubeStop()) {
                            nFlickText.GetComponent<nFlickText>().FlickCount();
                            Invoke("SoundPlay", 4 * Time.deltaTime);
                        }
                        CubeScript.State2Left();
                    }
                    FlickScript.Direction = "";
                } else if(265 < Camera.transform.eulerAngles.y && Camera.transform.eulerAngles.y < 275) {
                    if(Mathf.Abs(ControllCube.transform.position.z + 1) < nStageHeight / 2.0f) {
                        if(CubeScript.isCubeStop()) {
                            nFlickText.GetComponent<nFlickText>().FlickCount();
                            Invoke("SoundPlay", 4 * Time.deltaTime);
                        }
                        CubeScript.State2Up();
                    }
                    FlickScript.Direction = "";
                }
                break;
            case "left":
                if(355 < Camera.transform.eulerAngles.y || Camera.transform.eulerAngles.y < 5) {
                    if(Mathf.Abs(ControllCube.transform.position.x - 1) < nStageWidth / 2.0f) {
                        if(CubeScript.isCubeStop()) {
                            nFlickText.GetComponent<nFlickText>().FlickCount();
                            Invoke("SoundPlay", 4 * Time.deltaTime);
                        }
                        CubeScript.State2Left();
                    }
                    FlickScript.Direction = "";
                } else if(85 < Camera.transform.eulerAngles.y && Camera.transform.eulerAngles.y < 95) {
                    if(Mathf.Abs(ControllCube.transform.position.z + 1) < nStageHeight / 2.0f) {
                        if(CubeScript.isCubeStop()) {
                            nFlickText.GetComponent<nFlickText>().FlickCount();
                            Invoke("SoundPlay", 4 * Time.deltaTime);
                        }
                        CubeScript.State2Up();
                    }
                    FlickScript.Direction = "";
                } else if(175 < Camera.transform.eulerAngles.y && Camera.transform.eulerAngles.y < 185) {
                    if(Mathf.Abs(ControllCube.transform.position.x + 1) < nStageWidth / 2.0f) {
                        if(CubeScript.isCubeStop()) {
                            nFlickText.GetComponent<nFlickText>().FlickCount();
                            Invoke("SoundPlay", 4 * Time.deltaTime);
                        }
                        CubeScript.State2Right();
                    }
                    FlickScript.Direction = "";
                } else if(265 < Camera.transform.eulerAngles.y && Camera.transform.eulerAngles.y < 275) {
                    if(Mathf.Abs(ControllCube.transform.position.z - 1) < nStageHeight / 2.0f) {
                        if(CubeScript.isCubeStop()) {
                            nFlickText.GetComponent<nFlickText>().FlickCount();
                            Invoke("SoundPlay", 4 * Time.deltaTime);
                        }
                        CubeScript.State2Down();
                    }
                    FlickScript.Direction = "";
                }
                break;
        }
	}

    void SoundPlay() {
        RollSE.Play();
    }
}
