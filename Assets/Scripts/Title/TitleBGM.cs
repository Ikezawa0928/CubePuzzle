using UnityEngine;
using System.Collections;

public class TitleBGM : MonoBehaviour {

    public bool dontDestroyEnabled = true;

    private static GameObject instance = null;

    public static GameObject Instance {
        get { return instance; }
    }

    void Awake() {
        if(instance != null && instance != this) {
            Destroy(this.gameObject);
            return;
        } else {
            instance = this.gameObject;
        }
        DontDestroyOnLoad(this.gameObject);
    }

}
