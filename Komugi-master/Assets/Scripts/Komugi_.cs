using UnityEngine;
using System.Collections;

public class Komugi_ : MonoBehaviour {
	
	// GameObject,Sprite
	private GameObject tap;
	private GameObject KomugiObject;
	private SpriteRenderer shadow;
	private SoundManager snd;
	public AudioClip audioClip;
	AudioSource audioSource;
	private GameObject KoneCount;
	public GameObject kyusyuCount;
	public GameObject deathCount;

	// Flag
	bool DragMode = false;
	private bool isDragging = false;
	private bool dragModeFlag = false;
	private bool KoneModeFlag = false; 
	private bool isKonekone = false;
	private bool timerFlag = false;

	// Time Count
	float timeCount = 0.0f;
	float jumpTime = 0.0f;
	float dragTime = 0;
	private float tappedTime = 0;
	private float timer = 0;

	// Score Count 
	public static int tapCount = 0;
	public int amount = 1;
	private int KCount = 0;
	int KyusyuCount = 0;
	int dethCount = 0;

	// Touch Position
	Vector2 touch_first;
	Vector2 touch_second;
	Vector3 touch_pos;
	Vector3 currentScreenPoint;
	Vector3 currentPosition;
	private Vector2 mouseDownPos;

	// Audio Start
	int audioCount = 0;

	


	void Start () {

//		KomugiObject = GameObject.Find ("KomugiObject");
		//shadow = GameObject.Find ("shadow").GetComponent<SpriteRenderer> ();
//		snd = GameObject.Find("SoundManager").GetComponent<SoundManager>();
//		tap = GameObject.Find ("TapCount");
//		KoneCount = GameObject.Find ("KoneCount");
//		kyusyuCount = GameObject.Find ("sKomugiCount");
//		deathCount = GameObject.Find ("DeathCount");


//		audioSource = gameObject.GetComponent<AudioSource> ();
//		audioSource.clip = audioClip;
		//transform.ResetTransform ();

//		audioSource.Stop();
//		animation.Stop("Scaling");
//		animation.Stop("jump");
//		shadow.animation.Stop ("shadowJump");
//		KomugiObject.animation.Stop("jump&walking");
	}
	
	// Update is called once per frame
	void Update () {
		//isDragging = false;

		jumpTime += Time.deltaTime;
		dethCount = sKomugi.dethCount;

		/* Nomal Jump */
		if(jumpTime >= 3.0) {
			transform.position = new Vector3(touch_pos.x,touch_pos.y,0);
			transform.position = new Vector3 (currentPosition.x, currentPosition.y, 0);
//			animation.Play("jump");
//			KomugiObject.animation.Stop("jump&walking");
			//shadow.animation.Play ("shadowJump");
			jumpTime = 0;
			if(timerFlag) {
//				animation.Stop("jump");
				transform.localScale = new Vector3(2.0f,2.0f,2.0f);
				Debug.Log ("animation Stop!");
			}
		}

//		if(dragModeFlag && mouseDownPos.x == Input.mousePosition.x && mouseDownPos.y == Input.mousePosition.y ||dragModeFlag && Input.touchCount > 0 && Input.mousePosition.x == Input. GetTouch(0).position.x && Input.mousePosition.y == Input. GetTouch(0).position.y ){
//			isDragging = true;
//			KCount = 0;
//		}

//		if (KoneModeFlag && mouseDownPos.x == Input.mousePosition.x || KoneModeFlag && Input.touchCount > 0 && Input.mousePosition.x == Input.GetTouch (0).position.x) {
//			isKonekone = true;
//		} else if (Input.GetTouch (0).position.x == null) {
//			isKonekone = false;	
//		}

		//<Drag Mode> *************************************************************************************
//		if(isDragging){
//			Debug.Log ("isDragging");
////			if (audioCount == 1) {
//////				audioSource.Play ();   
////			}
//			currentScreenPoint = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 0);
//			currentPosition = Camera.main.ScreenToWorldPoint (currentScreenPoint);
//			transform.position = new Vector3 (currentPosition.x-0.1f, currentPosition.y+0.1f, 0);
//			
////			shadow.animation.Stop ("shadowJump");
//
////			KomugiObject.animation.Play("jump&walking");
//			
//			jumpTime = 0;
////			animation.Stop ("Konekone");
////			animation.Stop("jump");
//			isKonekone = false;
////			shadow.SendMessage("drag",isDragging); //tashiro
//		}
		//</Drag Mode> *************************************************************************************

		//<KoneKone Mode> *************************************************************************************
		if (isKonekone) {
			//currentScreenPoint = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 0);
			//currentPosition = Camera.main.ScreenToWorldPoint (currentScreenPoint);
			transform.position = new Vector3 (transform.position.x, transform.position.y, 0);
//			animation.Play ("Konekone");
//			animation.Stop ("jump");
			KCount++;
			if(KCount == 5) {
				amount = 1;
				KoneCount.SendMessage("CatchKoneCount", amount);
			}
			isDragging = false;
		}
		
		//</KoneKone Mode> *************************************************************************************

		//<timer>*************************************************************************
		if (timerFlag) {
			timer += Time.deltaTime;
//			Debug.Log (timer);
			if(timer >= 3.0f) {

				KyusyuCount = 0;
				tap.SendMessage ("InitScore");
				kyusyuCount.SendMessage ("InitScore");
				KoneCount.SendMessage ("InitScore");
				Application.LoadLevel("Start");
				sKomugi.dethCount = 0;
			}
		}
		//</ timer>*************************************************************************
	}

	void OnMouseDown () {
		 /*Tap Event*/
//		snd.PlaySE((int)eSE.EFFECT_03);
//		animation.Play("Scaling");
//		animation.Stop("jump");
//		animation.Stop ("Konekone");
		//shadow.animation.Stop ("shadowJump");
		KomugiObject.GetComponent<Animation>().Stop("jump&walking");
		tapCount++;
		tap.SendMessage ("CatchTapCount",tapCount);	
		timeCount = 0;
		mouseDownPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
		jumpTime = 0;
		tappedTime = 0;

	}

	void OnMouseDrag() {

		currentScreenPoint = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 0);
		currentPosition = Camera.main.ScreenToWorldPoint (currentScreenPoint);
		transform.position = new Vector3 (currentPosition.x-0.1f, currentPosition.y+0.1f, 0);

//		KoneModeFlag = true;
//
//		tappedTime += Time.deltaTime;
//		if(tappedTime > 1.0f){
//			dragModeFlag = true;
//			audioCount++;
//		}
	}

	void OnMouseUp() {
//		audioSource.Stop ();  
		audioCount = 0;
		tappedTime = 0;
		isDragging = false;
		dragModeFlag = false;
		isKonekone = false;
		KoneModeFlag = false;
//		animation.Stop ("Konekone");
		KCount = 0;
	}

	void KomugiTransScale(bool deathFlag) {
		if (deathFlag) {
			timerFlag = true;
		}
	}

}
