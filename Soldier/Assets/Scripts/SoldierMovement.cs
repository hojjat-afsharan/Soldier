using UnityEngine;

public class SoldierMovement : MonoBehaviour {

	private void Start () 
	{
		//transform.position = new Vector2(transform.position.x , transform.position.y +1);
	}
	
	private void Update () 
	{
		if (Input.GetMouseButtonDown(0))
		{
			CheckTouchedPlace();
		}
	}

	private static void CheckTouchedPlace()
	{
		var pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);
		if (hit != null && hit.collider != null)
		{
			Debug.Log("I'm hitting " + hit.collider.name);
		}
	}
}
