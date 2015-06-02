using UnityEngine;
using System.Collections;

public class KoneCount : MonoBehaviour {

	private static int koneCount = 0;

	void InitScore() {
		koneCount = 0;
	}
	// Use this for initialization
	void Start () {

	}

	void CatchKoneCount(int amount) {
		koneCount += amount; 
	}
	// Update is called once per frame
	void Update () {
		GetComponent<GUIText>().text = "こねた回数:" + koneCount.ToString();
	}
}
