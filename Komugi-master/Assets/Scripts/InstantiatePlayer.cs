using UnityEngine;
using System.Collections;

public class InstantiatePlayer : MonoBehaviour {

	private sKomugi skomugiCount;
	public GameObject skomugi;
	private sKomugi skomugiScript;

	int dethCount = 0;

	public static int komugiCount = 1;
	public static bool isAttack;

	//int count;
	int maxCount = 5;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("CreateSKomugi", 1.0f, 1.0f);
	}
	
	// Update is called once per frame
	void Update () {
		dethCount = sKomugi.dethCount;
	}

	void CreateSKomugi() {
//		Debug.Log ("dethCount"+dethCount);
		if (dethCount + komugiCount  < 21) {
			if (komugiCount <= maxCount) {
				Instantiate (skomugi, new Vector3 (Random.Range (-2.0F, 2.0f), Random.Range (-4.0F, 2.0F), 0), Quaternion.identity);
				komugiCount++;
			} 
		} 
	}

	void attackFlag(bool isAttack) {
		komugiCount--;
		isAttack = false;
	}



}
