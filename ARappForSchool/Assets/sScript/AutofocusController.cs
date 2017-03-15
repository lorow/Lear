using UnityEngine;
using System.Collections;
using Vuforia;

public class AutofocusController : MonoBehaviour {
	
	// Update is called once per frame
	void Update ()
	{
		CameraDevice.Instance.SetFocusMode (CameraDevice.FocusMode.FOCUS_MODE_CONTINUOUSAUTO);
	}
}
