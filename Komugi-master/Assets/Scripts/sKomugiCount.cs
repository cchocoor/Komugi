using UnityEngine;
using System.Collections;

public class sKomugiCount : MonoBehaviour {

	private static int getKomugiCounts = 0;

	void InitScore() {
		getKomugiCounts = 0;
	}
	// Use this for initialization
	void Start () {

	}

	void getKomugiCount(int count) {
		getKomugiCounts = count; 
	}
	// Update is called once per frame
	void Update () {
		GetComponent<GUIText>().text = "吸収した回数:" + getKomugiCounts.ToString();
	}
}
