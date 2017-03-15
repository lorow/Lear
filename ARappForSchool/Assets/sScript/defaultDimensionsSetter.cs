using UnityEngine;
using System.Collections;

public class defaultDimensionsSetter : MonoBehaviour {

	void Awake()
	{
		transform.rotation = Quaternion.Euler(Vector3.zero);
		transform.position = new Vector3(0,0.26f, 0);
		transform.localScale = new Vector3(.5f,.5f,.5f);
	}
}
