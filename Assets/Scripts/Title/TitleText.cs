using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleText : MonoBehaviour {

    void Start() {
        this.gameObject.GetComponent<Text>().text = "<color=#ffff80>C</color>" + "<color=#80ff80>U</color>" + "<color=#80ffff>B</color>" + "<color=#ff8080>E</color>" + "\n" + 
            "<color=#80ff80>P</color>" + "<color=#ff80ff>U</color>" + "<color=#ffff80>Z</color>" + "<color=#ff8080>Z</color>" + "<color=#80ff80>L</color>" + "<color=#80ffff>E</color>";
    }

    void Update() {

    }
}
