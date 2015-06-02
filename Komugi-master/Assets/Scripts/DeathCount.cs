using UnityEngine;
using System.Collections;

public class DeathCount : MonoBehaviour {
		
	private static int deathCount = 0;
		
	void InitScore() {
		deathCount = 0;
	}
	// Use this for initialization
	void Start () {			
	}	
	void CatchDeathCount(int amount) {
		deathCount += amount; 
	}
	// Update is called once per frame
	void Update () {
		//guiText.text = "こねた回数:" + koneCount.ToString();
	}
}