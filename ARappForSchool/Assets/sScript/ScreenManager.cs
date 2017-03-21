using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class ScreenManager : MonoBehaviour {

    public Button button;

    public GameObject screenToShow;
    public GameObject screenToHide;

    public GameObject AnchToShow;
    public GameObject AnchToHide;

    private void Start()
    {
        button = this.GetComponent<Button>();
        button.onClick.AddListener(() => MoveScreen(1));
    }

    public void MoveScreen( int time)
    {
        screenToShow.transform.DOMove(AnchToShow.transform.position, time);
        //add timer here
        screenToHide.transform.DOMove(AnchToHide.transform.position, time);
    }
}
