using UnityEngine;

public class SoldierMovement : MonoBehaviour {

	public Vector3 startMarker;
	public Vector3 endMarker;

	// Movement speed in units/sec.
	public float speed = 0.01F;

	// Time when the movement started.
	private float startTime;

	// Total distance between the markers.
	private float journeyLength;
	private bool movablePlaceTouched = false;
	private RaycastHit2D hit;
	
	private void Start () 
	{
		// Keep a note of the time the movement started.
		startTime = Time.time;

		
	}
	
	private void Update () 
	{
		if (Input.GetMouseButtonDown(0))
		{
			CheckTouchedPlace();
		}

		if (movablePlaceTouched)
		{
			MoveToMovablePlace();
		}
	}

	private void MoveToMovablePlace()
	{
		//TODO: player lerp to a position
//		if (startMarker == endMarker)
//			movablePlaceTouched = false;

		startMarker = transform.position;
		endMarker = hit.collider.transform.position;
		// Calculate the journey length.
		journeyLength = Vector3.Distance(startMarker, endMarker);

		// Distance moved = time * speed.
		float distCovered = (Time.time - startTime) * speed;

		// Fraction of journey completed = current distance divided by total distance.
		float fracJourney = distCovered / journeyLength;

		// Set our position as a fraction of the distance between the markers.
		transform.position = Vector3.Lerp(startMarker, endMarker, fracJourney);
	}

	private void CheckTouchedPlace()
	{
		var pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		hit = Physics2D.Raycast(pos, Vector2.zero);
		if (hit != null && hit.collider != null)
		{
			if (hit.collider.CompareTag("MovablePlaces"))
			{
				movablePlaceTouched = true;
			}
		}
	}
}
