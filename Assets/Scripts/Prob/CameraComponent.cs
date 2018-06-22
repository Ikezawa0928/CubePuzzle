using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraComponent : MonoBehaviour {

    private enum STATE { toLeft, toRight, stop };
    private STATE state = STATE.stop;

    public Button CameraLeftButton;
    public Button CameraRightButton;

    private int nRotate = 6;
    private int rotate;
    private Vector3 Angle;
    private Vector3 InitAngle;

	void Start () {
        rotate = nRotate;
        Angle = transform.eulerAngles;
        InitAngle = Angle;
        if(PlayerPrefs.GetInt("nTotalStars") == 70) {
            transform.GetChild(0).GetComponent<Camera>().backgroundColor = new Color(0.196f, 0.196f, 0.196f);
        }
	}
	
	void Update () {
        switch(state) {
            case STATE.toLeft :
                CameraLeftButton.interactable = false;
                CameraRightButton.interactable = false;
                rotate--;
                transform.RotateAround(Vector3.zero, Vector3.up, 90.0f / nRotate);
                if(rotate == 0) {
                    state = STATE.stop;
                    CameraLeftButton.interactable = true;
                    CameraRightButton.interactable = true;
                    rotate = nRotate;
                }
                break;
            case STATE.toRight :
                CameraLeftButton.interactable = false;
                CameraRightButton.interactable = false;
                rotate--;
                transform.RotateAround(Vector3.zero, Vector3.up, -90.0f / nRotate);
                if(rotate == 0) {
                    state = STATE.stop;
                    CameraLeftButton.interactable = true;
                    CameraRightButton.interactable = true;
                    rotate = nRotate;
                }
                break;
            case STATE.stop :
                transform.eulerAngles = Angle;
                break;
        }
		
	}

    public void Move2Left() {
        state = STATE.toLeft;
        Angle = new Vector3(Angle.x, Angle.y + 90, Angle.z);
    }

    public void Move2Right() {
        state = STATE.toRight;
        Angle = new Vector3(Angle.x, Angle.y - 90, Angle.z);
    }

    public void CameraReset() {
        Angle = InitAngle;
        transform.eulerAngles = InitAngle;
    }
}
