using UnityEngine;
using System.Collections;

public class Komugi2 : MonoBehaviour {
	
	private Vector3 screenPoint;
	public static int tapCount = 0;
	private GameObject tap;
	public static bool isTouchingFlag = false;
	
	public bool isDragging = false;
	public float timeCount = 0.0f;
	public float jumpTime = 0.0f;
	//private Vector3 offset;
	private SpriteRenderer shadow;
	private SoundManager snd;
	
	Vector2 touch_first;
	Vector2 touch_second;
	Vector3 touch_pos;
	Vector3 currentScreenPoint;
	Vector3 currentPosition;
	int audioCount = 0;
	
	// Use this for initialization
	void Start () {
		GetComponent<AudioSource>().Stop();
		shadow = GameObject.Find ("shadow").GetComponent<SpriteRenderer> ();
		snd = GameObject.Find("SoundManager").GetComponent<SoundManager>();
		transform.ResetTransform ();
		GetComponent<Animation>().Stop("Scaling");
		shadow.GetComponent<Animation>().Stop ("shadowJump");
		tap = GameObject.Find ("TapCount");
	}
	
	// Update is called once per frame
	void Update () {
		isDragging = false;
		
		jumpTime += Time.deltaTime;
		
		/* Jump */
		if(jumpTime >= 3.0) {
			transform.position = new Vector3(touch_pos.x,touch_pos.y,0);
			transform.position = new Vector3 (currentPosition.x, currentPosition.y, 0);
			GetComponent<Animation>().Play("jump");
			shadow.GetComponent<Animation>().Play ("shadowJump");
			jumpTime = 0;
		}
	}
	
	void OnMouseDown () {
		snd.PlaySE((int)eSE.EFFECT_03);
		GetComponent<Animation>().Play("Scaling");
		GetComponent<Animation>().Stop("jump");
		shadow.GetComponent<Animation>().Stop ("shadowJump");
		tapCount++;
		tap.SendMessage ("CatchTapCount",tapCount);	
		timeCount = 0;
	}
	
	void OnMouseDrag() {
		audioCount++;
		StartCoroutine (wait ());
		if (audioCount == 1) {
			GetComponent<AudioSource>().Play ();   
		}
	}
	
	IEnumerator wait(){
		yield return new WaitForSeconds(0.5f);

		currentScreenPoint = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 0);
		currentPosition = Camera.main.ScreenToWorldPoint(currentScreenPoint);
		//currentPosition = Camera.main.ScreenToWorldPoint (currentScreenPoint) + this.offset;
		transform.position = new Vector3 (currentPosition.x, currentPosition.y, 0);

//		touch_first = Input.GetTouch(0).position;
//		touch_second = touch_first;
//		touch_pos = Camera.main.ScreenToWorldPoint(touch_second);
//		transform.position = new Vector3(touch_pos.x,touch_pos.y,0);

//		Debug.Log ("touchPos"+transform.position);
		
		shadow.GetComponent<Animation>().Stop ("shadowJump");
		GetComponent<Animation>().Stop("jump");
		jumpTime = 0;
		shadow.SendMessage ("drag", isDragging);
	}   
	
	void OnMouseUp() {
		/*
		if (!isDragging) {
			shadow.SendMessage("undrag");	
		}
		*/
		GetComponent<AudioSource>().Stop ();  
		audioCount = 0;
	}
	
}
