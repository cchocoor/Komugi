using UnityEngine;
using System.Collections;

public class shadow : MonoBehaviour {
	public GameObject Komugi;
	public GameObject komugiObject;

	// Use this for initialization
	void Start () {
		Komugi = GameObject.Find ("Komugi");
		komugiObject = GameObject.Find ("KomugiObject");

	}
	
	// Update is called once per frame
	void Update () {

	}

	void drag(bool isDragging) {
		transform.parent = Komugi.transform;
		transform.position = new Vector3 (transform.parent.position.x,transform.parent.position.y-0.6f,0);
	}
	
	void undrag() {
		transform.parent = null;
		transform.parent = komugiObject.transform;
		//transform.position = new Vector3 (komugiObject.transform.position.x,komugiObject.transform.position.y-0.6f,0);
	}
}
