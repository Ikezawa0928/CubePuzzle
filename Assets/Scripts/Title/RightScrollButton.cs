using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RightScrollButton : MonoBehaviour {

    public GameObject[] ScrollMask;
    private GameObject Scroll;
    private int H;
    public Sprite[] texture;
    private int nTexture;
    private int i, j;

    void Start() {
        nTexture = texture.Length;
        i = 0;
        j = 0;

        var n = PlayerPrefs.GetInt("nTotalStars");
        if(n < 15) {
            Scroll = ScrollMask[0];
        } else if(n < 30) {
            Scroll = ScrollMask[1];
        } else if(n < 50) {
            Scroll = ScrollMask[2];
        } else {
            Scroll = ScrollMask[3];
        }
    }

    void Update() {
        i++;
        if(i % 6 == 0) {
            j++;
        }
        if(PlayerPrefs.GetInt("nTotalStars") == 70) {
            GetComponent<Image>().sprite = texture[(j % (nTexture / 2)) + (texture.Length / 2)];
        } else {
            GetComponent<Image>().sprite = texture[j % (nTexture / 2)];
        }
    }

    public void Onclick() {
        H = SnapScrollRect.hIndex;
        if(H < 3) {
            Scroll.GetComponent<SnapScrollRect>().ScrollTo(H + 1, 0);
            i = 0;
            j = 0;
        }
    }

}
