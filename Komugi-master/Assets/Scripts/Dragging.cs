using UnityEngine;
using System.Collections;

public class Dragging : MonoBehaviour {

	public bool isDragging = false;
	public float timeCount = 0.0f;
	 //private Vector3 offset;

	// Use this for initialization
	void Start () {
		transform.ResetTransform ();
	}
	
	// Update is called once per frame
	void Update () {

		isDragging = true;

		if (Input.touchCount > 0 && Input.touches [0].phase == TouchPhase.Moved || Input.GetMouseButtonDown (0)) {
			
			timeCount += Time.deltaTime;
			
			if( 0.5f < timeCount && isDragging) {
				Vector2 touch_first = Input.GetTouch(0).position;
				Vector2 touch_second = touch_first;
				Vector3 touch_pos = Camera.main.ScreenToWorldPoint(touch_second);
				transform.position = new Vector3(touch_pos.x,touch_pos.y,0);
				isDragging = false;
			}
		}
	
	}

	void OnMouseDrag() {

		Vector3 currentScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
		Vector3 currentPosition = Camera.main.ScreenToWorldPoint(currentScreenPoint);
		transform.position = new Vector3(currentPosition.x,currentPosition.y,0);
		
		
		isDragging = false;
	}
}
