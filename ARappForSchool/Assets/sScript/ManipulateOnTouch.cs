using UnityEngine;
public class ManipulateOnTouch : MonoBehaviour {
public GameObject manipulateObject;
public float speed = 0.60f;
Vector3 initialScale = Vector3.zero;
float initialFingerDistance = 0;
float currentFingerDistance = 0;
float scaleFactor = 0;

Touch touchZero;
Touch touchOne;
	void controllDragging() 
	{
		if (Input.touchCount >= 0)
		{
			touchZero = Input.GetTouch(0);
			touchOne = Input.GetTouch(1);
		}
		 if(Input.touchCount == 1) // dealing with one finger
		{
			if (touchZero.phase == TouchPhase.Began) // choosing the gameObject by Raycasting
			{
				RaycastHit hit;
				Vector3 touchPosition = new Vector3(touchZero.position.x, touchZero.position.y ,0);
				Ray ray = Camera.main.ScreenPointToRay (touchPosition);

				if(Physics.Raycast(ray,out hit, 1000))
					{
						manipulateObject = hit.collider.gameObject;							
					}
			}
			if(touchZero.phase == TouchPhase.Moved)// actual rotating
			{
				manipulateObject.transform.Rotate(-Vector3.up, touchZero.deltaPosition.x * speed );
				manipulateObject.transform.Rotate(Vector3.right, -touchZero.deltaPosition.y * speed);
			}
		}
		if (Input.touchCount == 2) // scaling
		{

			if(touchZero.phase == TouchPhase.Began || touchOne.phase == TouchPhase.Began)
			{
				initialScale = manipulateObject.transform.localScale;
				initialFingerDistance = Vector2.Distance(touchZero.position, touchOne.position);
			}
			if(touchZero.phase == TouchPhase.Moved && touchOne.phase == TouchPhase.Moved)
			{
				currentFingerDistance = Vector2.Distance(touchZero.position, touchOne.position);
				scaleFactor = currentFingerDistance / initialFingerDistance;
				manipulateObject.transform.localScale = initialScale * scaleFactor;
			}
			if(touchZero.phase == TouchPhase.Ended || touchOne.phase == TouchPhase.Ended)
			{
				initialScale = manipulateObject.transform.localScale;
				initialFingerDistance = 0.0f;
			}
		}
	}
	
}
