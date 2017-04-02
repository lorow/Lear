using UnityEngine;

public class AutofocusController : MonoBehaviour {

    private void LateUpdate()
    {
        Vuforia.CameraDevice.Instance.SetFocusMode(Vuforia.CameraDevice.FocusMode.FOCUS_MODE_CONTINUOUSAUTO);
    }
}
