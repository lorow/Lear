using UnityEngine;
using UnityEngine.UI;

public class SingleCourseManager : MonoBehaviour {

    public RawImage image;
    [SerializeField]
    GameObject error;

    public void showError(bool show)
    {
        error.SetActive(show);
    }
}
