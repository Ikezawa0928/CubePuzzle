using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperParticleSE : MonoBehaviour {

    private AudioSource SE;

	void Start () {
        SE = GetComponent<AudioSource>();
        SE.volume = 0;
	}
	
	void Update () {
        SE.volume += 0.01f;
	}
}
