using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Force : MonoBehaviour {

    private ControllCube Cube;
    public Texture[] texture;
    private int nTexture;
    private int i, j;

    private AudioSource ForceSE;

    private enum STATE { force, stop };
    private STATE state = STATE.stop;
    private int time = 4;
    private int rotate_time;
    private Vector3 point;
    private Vector3 axis;

    private Vector3 Position;
    private Vector3 Angle;

    void Start() {
        nTexture = texture.Length;
        i = 0;
        j = 0;
        Cube = GameObject.Find("ControllCube").GetComponent<ControllCube>();
        ForceSE = GetComponent<AudioSource>();
        rotate_time = time * 2;
        Position = transform.position;
        Angle = transform.eulerAngles;
    }

    void Update() {
        i++;
        if(i % 2 == 0) {
            j++;
        }
        GetComponent<Renderer>().material.mainTexture = texture[j % nTexture];

        if(state == STATE.force) {
            if(rotate_time > time) {
                transform.RotateAround(point, axis,  90.0f / time);
                rotate_time--;
            } else if(rotate_time > 0) {
                transform.RotateAround(point, axis, -90.0f / time);
                rotate_time--;
            } else if(rotate_time <= 0) {
                rotate_time = time * 2;
                state = STATE.stop;
            }
        } else if(state == STATE.stop) {
            transform.position = Position;
            transform.eulerAngles = Angle;
            GetComponent<BoxCollider>().enabled = true;
        }
    }

    void OnCollisionStay(Collision collision) {
        if(collision.gameObject.tag == "Cube") {
            if(Cube.isCubeStop()) {
                if(transform.eulerAngles.y < 5 || 355 < transform.eulerAngles.y) {
                    Cube.State2Up();
                    point = new Vector3(transform.position.x, transform.position.y, transform.position.z + 0.45f);
                    axis = Vector3.right;
                    state = STATE.force;
                } else if(85 < transform.eulerAngles.y && transform.eulerAngles.y < 95) {
                    Cube.State2Right();
                    point = new Vector3(transform.position.x + 0.45f, transform.position.y, transform.position.z);
                    axis = Vector3.back;
                    state = STATE.force;
                } else if(175 < transform.eulerAngles.y && transform.eulerAngles.y < 185) {
                    Cube.State2Down();
                    point = new Vector3(transform.position.x, transform.position.y, transform.position.z - 0.45f);
                    axis = Vector3.left;
                    state = STATE.force;
                } else if(265 < transform.eulerAngles.y && transform.eulerAngles.y < 275) {
                    Cube.State2Left();
                    point = new Vector3(transform.position.x - 0.45f, transform.position.y, transform.position.z);
                    axis = Vector3.forward;
                    state = STATE.force;
                }
                ForceSE.Play();
                Invoke("DisableCollision", 1 * Time.deltaTime);
            }
        }
    }

    void DisableCollision() {
        GetComponent<BoxCollider>().enabled = false;
    }
}
