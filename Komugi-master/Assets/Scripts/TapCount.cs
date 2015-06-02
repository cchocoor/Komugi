using UnityEngine;
using System.Collections;

public class TapCount : MonoBehaviour {

	private static int tapCount = 0;

	void InitScore() {
		tapCount = 0;
	}
	// Use this for initialization
	void Start () {

	}

	void CatchTapCount(int count) {
		tapCount = count; 
	}
	// Update is called once per frame
	void Update () {
		GetComponent<GUIText>().text = "たたいた回数:" + tapCount.ToString();
	}
}
