using UnityEngine;
using System.Collections;

public class sKomugi : MonoBehaviour {

	public static int dethCount = 0;
	public static bool isAttack = false;
	public GameObject InstaKomugi;
	public GameObject sKomugiCount;
	public GameObject Komugi;
	private SoundManager snd;
	public GameObject TapCount;
	public GameObject kyusyuCount;
	public GameObject shadow;
	public GameObject koneCount;
	public GameObject deathCount;

	// Flag
	private bool deathFlag;

	// Timer

//	private float timer = 0;


	// Use this for initialization
	void Start () {
		TapCount = GameObject.Find ("TapCount");
		kyusyuCount = GameObject.Find ("sKomugiCount");
		snd = GameObject.Find("SoundManager").GetComponent<SoundManager>();
		InstaKomugi = GameObject.Find ("InstantiateKomugi");
		Komugi = GameObject.Find ("Komugi");
		shadow = GameObject.Find ("shadow");
		koneCount = GameObject.Find ("KoneCount");
		deathCount = GameObject.Find ("DeathCount");
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log ("Update:::::"+dethCount);
	}

	void InitScore() {
		dethCount = 0;
	}

	// <sKomugi deth>*******************************************************************************************************
	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.tag == "Player") {
			dethCount++;
			deathCount.SendMessage("CatchDeathCount",dethCount);
			isAttack =  true;
			//Komugi.transform.localScale = new Vector3(2.0f,2.0f,2.0f);
			Komugi.GetComponent<Animation>().Play("Scaling");
			Destroy  (gameObject);
			InstaKomugi.SendMessage("attackFlag",isAttack);
			kyusyuCount.SendMessage ("getKomugiCount",dethCount);
			snd.PlaySE((int)eSE.EFFECT_02);
		}
		if (dethCount == 20) {
			deathFlag = true;
			Komugi.SendMessage("KomugiTransScale",deathFlag);
		}
	}
	// </sKomugi deth>*******************************************************************************************************
}
