using UnityEngine;
using System.Collections;

public class startBtn : MonoBehaviour {

//	public GameObject TapCount;
//	public GameObject kyusyuCount;
//	public GameObject koneCount;
//	public GameObject sKomugi;

	// Use this for initialization
	void Start () {
//		TapCount = GameObject.Find ("TapCount");
//		kyusyuCount = GameObject.Find ("sKomugiCount");
//		koneCount = GameObject.Find ("KoneCount");
//
//		TapCount.SendMessage ("InitScore");
//		kyusyuCount.SendMessage ("InitScore");
//		koneCount.SendMessage ("InitScore");
//		sKomugi = GameObject.Find ("skomugi(clone)");
//		sKomugi.SendMessage ("InitScore");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI() {
		if (GUI.Button (new Rect  (Screen.width - 300,Screen.height - 180,250,150), "START")) {
			
			Application.LoadLevel("Main");
			
		}
	}
}
