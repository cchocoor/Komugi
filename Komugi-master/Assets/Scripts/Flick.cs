using UnityEngine;
using System.Collections;

public class Flick : MonoBehaviour {
	private bool isFlick;
	private bool isClick;
	private Vector3 touchStartPos;
	private Vector3 touchEndPos;
	private int direction;
	private GameObject KoneCount;
	public int amount;

	public void Start() {
		KoneCount = GameObject.Find ("KoneCount");
	}
	
	public void Update () {
		if(Input.GetKeyDown (KeyCode.Mouse0))
		{
			isFlick = true;
			touchStartPos = new Vector3(Input.mousePosition.x ,
			                            Input.mousePosition.y ,
			                            Input.mousePosition.z);
			Invoke ("FlickOff" , 0.2f);
		}
		if(Input.GetKey (KeyCode.Mouse0))
		{
			touchEndPos = new Vector3(Input.mousePosition.x ,
			                          Input.mousePosition.y ,
			                          Input.mousePosition.z);
			if(touchStartPos != touchEndPos )
			{
				ClickOff ();
			}
		}
		if(Input.GetKeyUp (KeyCode.Mouse0))
		{
			touchEndPos = new Vector3(Input.mousePosition.x ,
			                          Input.mousePosition.y ,
			                          Input.mousePosition.z);
			if(IsFlick ())
			{
				float directionX = touchEndPos.x - touchStartPos.x;
				float directionY = touchEndPos.y - touchStartPos.y;
				if(Mathf.Abs (directionX) < Mathf.Abs (directionY))
				{
					if(0 < directionY)
					{
						Debug.Log ("Flick : Up");
						direction = 8;
						GetComponent<Animation>().Play ("Konekone");
						GetComponent<Animation>().Stop ("jump");
						amount++;
						KoneCount.SendMessage("CatchKoneCount", amount);

					}
					else
					{
						Debug.Log ("Flick : Down");
						direction = 2;
						GetComponent<Animation>().Play ("Konekone");
						GetComponent<Animation>().Stop ("jump");
						amount++;
						KoneCount.SendMessage("CatchKoneCount", amount);
					}
				}
				else
				{
					FlickOff();
				}
			}
		}
	}
	public void FlickOff()
	{
		direction = 5;
		isFlick = false;
	}
	
	public bool IsFlick()
	{
		return isFlick;
	}

	public void ClickOff()
	{
		isClick = false;
	}
}
