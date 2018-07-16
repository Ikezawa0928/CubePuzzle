using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageGenerator : MonoBehaviour {

	public GameObject Force;
	public GameObject Slide;
	public GameObject Back;
	public GameObject Spin;
	public GameObject Transport;
	public int StageWidth;
	public int StageHeight;
	private int[] Stage;
	private GameObject map;

	private int frame;

	// Use this for initialization
	void Start () {
		frame = 0;

		var StageSize = StageWidth * StageHeight;
		Stage = new int[StageSize];
		for (var i = 0; i < StageSize; i++) {
			Stage[i] = 0;
		}

		var random1 = Random.Range(1.0f, (float)StageWidth);
		var random2 = Random.Range(1.0f, (float)StageHeight);

		var nTrap = (int)(random1 * random2);

		var existTransport = Random.Range(0, 9);
		if (existTransport < 6)
		{
			nTrap -= 2;

			var nTransport = 0;
			var TrapPosition = Random.Range(1, StageSize - 2);
			if (Stage[TrapPosition] == 0)
			{
				Stage[TrapPosition] = 14;
				nTransport++;
			}

			while (nTransport < 2)
			{
				TrapPosition = Random.Range(1, StageSize - 2);
				if (Stage[TrapPosition] == 0)
				{
					Stage[TrapPosition] = 14;
					nTransport++;
				}
			}
		}

        /*
        ru = 1, rr = 2, rd = 3, rl = 4
        su = 5, sr = 6, sd = 7, sl = 8
        ba = 9, sp = 10, tp = 11
        */

		var j = 0;
		while(j < nTrap) {
			var TrapPosition = Random.Range(1, StageSize - 2);
			if(Stage[TrapPosition] == 0) {
				var setTrap = false;
				do
				{
					setTrap = false;
					Stage[TrapPosition] = Random.Range(1, 14);
					if (Stage[TrapPosition] == 1 && TrapPosition < StageWidth)
					{
						setTrap = true;
					}
					if (Stage[TrapPosition] == 2 && TrapPosition % StageWidth == 0)
					{
						setTrap = true;
					}
					if (Stage[TrapPosition] == 3 && TrapPosition > StageWidth * StageHeight - 1 - StageWidth)
					{
						setTrap = true;
					}
					if (Stage[TrapPosition] == 4 && TrapPosition % StageWidth == StageWidth - 1)
					{
						setTrap = true;
					}
					if (Stage[TrapPosition] == 5 && TrapPosition < StageWidth)
					{
						setTrap = true;
					}
					if (Stage[TrapPosition] == 6 && TrapPosition % StageWidth == 0)
					{
						setTrap = true;
					}
					if (Stage[TrapPosition] == 7 && TrapPosition > StageWidth * StageHeight - 1 - StageWidth)
					{
						setTrap = true;
					}
					if (Stage[TrapPosition] == 8 && TrapPosition % StageWidth == StageWidth - 1)
					{
						setTrap = true;
					}
				}
				while (setTrap);
				j++;
			}
		}

		map = GameObject.Find("Stage");
		for (var k = StageSize - 1; 0 < k; k--) {
			if(Stage[k] != 0) {
				Destroy(map.transform.GetChild(k).gameObject);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		frame++;

		var x = ((StageWidth / 2.0f) - 0.5f) - (frame%StageWidth);
		var y = -0.5005f;
		var z = ((StageHeight/ 2.0f) - 0.5f) - (frame/StageWidth);

		Vector3 position = new Vector3(x, y, z);
		if (frame < Stage.Length)
		{
			switch (Stage[frame])
			{
				case 1:
					Instantiate(Force, position, Quaternion.Euler(new Vector3(0, 0, 0)));
					break;
				case 2:
                    Instantiate(Force, position, Quaternion.Euler(new Vector3(0, 90, 0)));
                    break;
				case 3:
                    Instantiate(Force, position, Quaternion.Euler(new Vector3(0, 180, 0)));
                    break;
				case 4:
                    Instantiate(Force, position, Quaternion.Euler(new Vector3(0, 270, 0)));
                    break;
				case 5:
					Instantiate(Slide, position, Quaternion.Euler(new Vector3(0, 0, 0)));
                    break;
                case 6:
					Instantiate(Slide, position, Quaternion.Euler(new Vector3(0, 90, 0)));
                    break;
                case 7:
					Instantiate(Slide, position, Quaternion.Euler(new Vector3(0, 180, 0)));
                    break;
                case 8:
					Instantiate(Slide, position, Quaternion.Euler(new Vector3(0, 270, 0)));
                    break;
				case 9:
					Instantiate(Back, position, Quaternion.identity);
					break;
				case 10:
					Instantiate(Back, position, Quaternion.identity);
                    break;
				case 11:
					Instantiate(Spin, position, Quaternion.identity);
                    break;
                case 12:
					Instantiate(Spin, position, Quaternion.identity);
                    break;
				case 13:
                    Instantiate(Spin, position, Quaternion.identity);
                    break;
				case 14:
					Instantiate(Transport, position, Quaternion.identity);
					break;
				default:
					break;
			}
		}
	}
}
