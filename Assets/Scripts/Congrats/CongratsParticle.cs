using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CongratsParticle : MonoBehaviour {

    public GameObject[] FireWorks;
    [SerializeField] private float rate;

    private void Start() {
        Destroy(GameObject.Find("DontDestroyForBGM"));
    }

    void Update () {
        Invoke("EffectAppear", 2);
	}

    void EffectAppear() {
        var random = Random.Range(0, 100);
        if(random > rate) {
            int index = Random.Range(0, FireWorks.Length);
            Instantiate(FireWorks[index], new Vector3(0, -4.9f, 0), Quaternion.Euler(-90, 0, 0));
        }
    }
}
