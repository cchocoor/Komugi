using UnityEngine;
using System.Collections;

public class Komugi_1 : MonoBehaviour {

	Vector3 currentScreenPoint;
	Vector3 currentPosition;
	public Transform target;

	// Use this for initialization
	void Start () {
		Debug.Log (1);
	}
	
	// Update is called once per frame
	void Update () {
		transform.LookAt(target);
//		if (Input.GetMouseButtonDown (0)) {
//			Vector3 curScreenSpace =new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
//			Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenSpace);
//			transform.position = new Vector3 (curPosition.x, curPosition.y-4.0f, 0);
//		}
	}

//	void OnMouseDown() {
//		currentScreenPoint = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 0);
//		currentPosition = Camera.main.ScreenToWorldPoint (currentScreenPoint);
//		transform.position = new Vector3 (currentPosition.x - 0.1f, currentPosition.y + 0.1f, 0);
//		Debug.Log (transform.position);
//	}
}
