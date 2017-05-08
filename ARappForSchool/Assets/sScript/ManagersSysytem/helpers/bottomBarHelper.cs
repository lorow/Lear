
using UnityEngine;
using UnityEngine.UI;

public class bottomBarHelper : MonoBehaviour {

    [SerializeField]
    private GPASCoreManager _GPASManager;
    [SerializeField]
    private string title;
    public GPASCoreManager GPASManager
    {
        get { return _GPASManager; }
        set { _GPASManager = value; }
    }

    public bottomBarManager BottomBarMgr
    {
        get { return bottomBarMgr; }
        set { bottomBarMgr = value; }
    }

    [SerializeField]
    bottomBarManager bottomBarMgr;

    [SerializeField]
    Color colorAfterClick;

    public void handleColorTransition()
    {
        turnAllWhite();
        lerpToDesiredColor();
    }
    void turnAllWhite()
    {
        foreach (GameObject button in bottomBarMgr.BottomBarButtons)
        {
            _GPASManager.ImageCore.lerpColor(button.GetComponent<Image>(), Color.white, .3f);
        } 
    }
    void lerpToDesiredColor()
    {
        _GPASManager.ImageCore.lerpColor(gameObject.GetComponent<Image>(), colorAfterClick, .6f);
    }
   public void setTitle(TMPro.TextMeshProUGUI Title)
    {
        Title.text = title;
    }
}
