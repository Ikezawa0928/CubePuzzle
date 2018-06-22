using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroyEffect : MonoBehaviour {

	void Start () {
        Invoke("Destroy", 3.0f);
	}

    void Destroy() {
        Destroy(this.gameObject);
    }
}
