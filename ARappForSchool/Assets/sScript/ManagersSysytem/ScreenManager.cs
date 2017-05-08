using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class ScreenManager : MonoBehaviour {

    public Button button;

    public GameObject screenToShow;
    public GameObject screenToHide;

    public GameObject AnchToShow;
    public GameObject AnchToHide;

    public float speed = 1;

    private void Start()
    {
        button = this.GetComponent<Button>();
        button.onClick.AddListener(() => MoveScreen(speed));
    }

    public void MoveScreen( float time)
    {
        if(screenToShow != null && AnchToShow != null)
            screenToShow.transform.DOMove(AnchToShow.transform.position, time);
        
        if (screenToHide != null && AnchToHide != null)
            screenToHide.transform.DOMove(AnchToHide.transform.position, time);
    }
}
