using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllCube : MonoBehaviour {

    private enum STATE { up, down, right, left, up_slide, down_slide, right_slide, left_slide, stop, freeze, transport, spin};
    private STATE state = STATE.stop;
    private STATE pre_state = STATE.stop;

    private Vector3 Position;
    private Vector3 Angle;
    private Rigidbody rigidbody;

    private Vector3 InitPosition;
    private Vector3 InitAngle;

    private int nRotate = 4;
    private int nSlide = 10;
    private int nTransport = 11;
    private int nSpin = 6;
    private int transport_time;
    private int move_time;
    private int spin_time;

    private Vector3 RotatePosition;

    public GameObject nFlickText;

    private MeshRenderer mesh;
    private MeshRenderer child_mesh;
    private Color color;
    private Color child_color;
    private float transport_x;
    private float transport_z;

    void Start() {
        Position = transform.position;
        Angle = transform.eulerAngles;
        InitPosition = Position;
        InitAngle = Angle;
        state = STATE.stop;
        rigidbody = GetComponent<Rigidbody>();
        mesh = GetComponent<MeshRenderer>();
        child_mesh = transform.GetChild(0).GetComponent<MeshRenderer>();
        transport_time = nTransport;
        color = mesh.material.color;
        child_color = child_mesh.material.color;
        spin_time = nSpin;
    }

    void Update() {
        switch(state) {
            case STATE.stop:
                transform.position = Position;
                transform.eulerAngles = Angle;
                rigidbody.velocity = Vector3.zero;
                break;
            case STATE.up:
                transform.RotateAround(RotatePosition, Vector3.right, 90.0f / nRotate);
                move_time--;
                if(move_time == 0) {
                    State2Stop();
                }
                break;
            case STATE.down:
                transform.RotateAround(RotatePosition, Vector3.left, 90.0f / nRotate);
                move_time--;
                if(move_time == 0) {
                    State2Stop();
                }
                break;
            case STATE.right:
                transform.RotateAround(RotatePosition, Vector3.back, 90.0f / nRotate);
                move_time--;
                if(move_time == 0) {
                    State2Stop();
                }
                break;
            case STATE.left:
                transform.RotateAround(RotatePosition, Vector3.forward, 90.0f / nRotate);
                move_time--;
                if(move_time == 0) {
                    State2Stop();
                }
                break;
            case STATE.up_slide:
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 1.0f / nSlide);
                move_time--;
                if(move_time == 0) {
                    State2Stop();
                }
                break;
            case STATE.down_slide:
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 1.0f / nSlide);
                move_time--;
                if(move_time == 0) {
                    State2Stop();
                }
                break;
            case STATE.right_slide:
                transform.position = new Vector3(transform.position.x + 1.0f / nSlide, transform.position.y, transform.position.z);
                move_time--;
                if(move_time == 0) {
                    State2Stop();
                }
                break;
            case STATE.left_slide:
                transform.position = new Vector3(transform.position.x - 1.0f / nSlide, transform.position.y, transform.position.z);
                move_time--;
                if(move_time == 0) {
                    State2Stop();
                }
                break;
            case STATE.freeze :
                break;
            case STATE.transport :
                if(transport_time > 6) {
                    color.a /= 2;
                    child_color.a /= 2;
                    mesh.material.color = color;
                    child_mesh.material.color = child_color;
                } else if (transport_time == 6) {
                    transform.position = new Vector3(transport_x, 0.03f, transport_z);
                } else if(transport_time < 6) {
                    color.a *= 2;
                    child_color.a *= 2;
                    mesh.material.color = color;
                    child_mesh.material.color = child_color;
                }
                transport_time--;
                if(transport_time == 0) {
                    transport_time = nTransport;
                    State2Stop();
                }
                break;

			case STATE.spin :
				transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y+30, transform.eulerAngles.z);
                spin_time--;
                if(spin_time == 0) {
                    spin_time = nSpin;
                    State2Stop();
					transform.position = new Vector3(transform.position.x, 0.03f, transform.position.z);
                }
                break;
        }
    }	

    public void State2Up() {
        if(state == STATE.stop) {
            state = STATE.up;
            move_time = nRotate;
            RotatePosition = new Vector3(Position.x, Position.y - 0.5f, Position.z + 0.5f);
            Position = new Vector3(Position.x, Position.y / 2, Position.z + 1);
        }
    }

    public void State2Down() {
        if(state == STATE.stop) {
            state = STATE.down;
            move_time = nRotate;
            RotatePosition = new Vector3(Position.x, Position.y - 0.5f, Position.z - 0.5f);
            Position = new Vector3(Position.x, Position.y / 2, Position.z - 1);
        }
    }

    public void State2Right() {
        if(state == STATE.stop) {
            state = STATE.right;
            move_time = nRotate;
            RotatePosition = new Vector3(Position.x + 0.5f, Position.y - 0.5f, Position.z);
            Position = new Vector3(Position.x + 1, Position.y / 2, Position.z);
        }
    }

    public void State2Left() {
        if(state == STATE.stop) {
            state = STATE.left;
            move_time = nRotate;
            RotatePosition = new Vector3(Position.x - 0.5f, Position.y - 0.5f, Position.z);
            Position = new Vector3(Position.x - 1, Position.y / 2, Position.z);
        }
    }

    public void State2UpSlide() {
        if(state == STATE.stop) {
            state = STATE.up_slide;
            Position = new Vector3(Position.x, Position.y / 2, Position.z + 1);
            move_time = nSlide;
        }
    }

    public void State2DownSlide() {
        if(state == STATE.stop) {
            state = STATE.down_slide;
            Position = new Vector3(Position.x, Position.y / 2, Position.z - 1);
            move_time = nSlide;
        }
    }

    public void State2RightSlide() {
        if(state == STATE.stop) {
            state = STATE.right_slide;
            Position = new Vector3(Position.x + 1, Position.y / 2, Position.z);
            move_time = nSlide;
        }
    }

    public void State2LeftSlide() {
        if(state == STATE.stop) {
            state = STATE.left_slide;
            Position = new Vector3(Position.x - 1, Position.y / 2, Position.z);
            move_time = nSlide;
        }
    }

    public void State2Transport(float x, float z) {
        if(state == STATE.stop) {
            state = STATE.transport;
            transport_x = x;
            transport_z = z;
            Position = new Vector3(transport_x, 0.03f, transport_z);
        }
    }

    public void State2Spin() {
        if(state == STATE.stop) {
			state = STATE.spin;
			Position = new Vector3(transform.position.x, 0.03f, transform.position.z);
        }
    }

    public void State2Stop() {
        if(transform.eulerAngles.x < 45 || 315 < transform.eulerAngles.x) {
            Angle.x = 0;
        } else if(45 < transform.eulerAngles.x && transform.eulerAngles.x < 135) {
            Angle.x = 90;
        } else if(135 < transform.eulerAngles.x && transform.eulerAngles.x < 225) {
            Angle.x = 180;
        } else if(225 < transform.eulerAngles.x && transform.eulerAngles.x < 315) {
            Angle.x = 270;
        }
        if(transform.eulerAngles.y < 45 || 315 < transform.eulerAngles.y) {
            Angle.y = 0;
        } else if(45 < transform.eulerAngles.y && transform.eulerAngles.y < 135) {
            Angle.y = 90;
        } else if(135 < transform.eulerAngles.y && transform.eulerAngles.y < 225) {
            Angle.y = 180;
        } else if(225 < transform.eulerAngles.y && transform.eulerAngles.y < 315) {
            Angle.y = 270;
        }
        if(transform.eulerAngles.z < 45 || 315 < transform.eulerAngles.z) {
            Angle.z = 0;
        } else if(45 < transform.eulerAngles.z && transform.eulerAngles.z < 135) {
            Angle.z = 90;
        } else if(135 < transform.eulerAngles.z && transform.eulerAngles.z < 225) {
            Angle.z = 180;
        } else if(225 < transform.eulerAngles.z && transform.eulerAngles.z < 315) {
            Angle.z = 270;
        };
        move_time = 0;
        pre_state = state;
        state = STATE.stop;
    }

    public void State2Freeze() {
        if(state == STATE.stop) {
            state = STATE.freeze; //ゲームの一時停止用 
                                  //State2Stop()かCubeReset()しか読み込めない
        }
    }

    public void CubeBack() {
        switch(pre_state) {
            case STATE.up :
                State2Down();
                break;
            case STATE.down :
                State2Up();
                break;
            case STATE.right :
                State2Left();
                break;
            case STATE.left :
                State2Right();
                break;
            case STATE.up_slide :
                State2DownSlide();
                break;
            case STATE.down_slide:
                State2UpSlide();
                break;
            case STATE.right_slide:
                State2LeftSlide();
                break;
            case STATE.left_slide:
                State2RightSlide();
                break;
        }
    }

    public void CubeReset() {
        State2Stop();
        transform.position = InitPosition;
        transform.eulerAngles = InitAngle;
        Position = InitPosition;
        Angle = InitAngle;
        nFlickText.GetComponent<nFlickText>().FlickReset();
    }

    public bool isCubeStop() {
        return state == STATE.stop;
    }
}
