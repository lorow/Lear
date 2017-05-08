using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class bottomBarManager : MonoBehaviour
{
    [SerializeField]
    private TMPro.TextMeshProUGUI title;

    [SerializeField]
    private List<GameObject> bottomBarButtons;
    public List<GameObject> BottomBarButtons
    {
        get { return bottomBarButtons; }
        set { bottomBarButtons = value; }
    }

    [SerializeField]
    private ScreenManagerHub screenNanager;

    private void Start()
    {
        getBottomBarButtons();
        prepareButtonHelper();
        AddListeners();
    }

    void AddListeners()
    {
        //To be honest, I have no idea why any loop isn't working here. Every single one throws index error. 
        BottomBarButtons[0].GetComponent<Button>().onClick.AddListener(() => screenNanager.ChangeScreen(screenNanager.InvocableScreens[0]));
        BottomBarButtons[1].GetComponent<Button>().onClick.AddListener(() => screenNanager.ChangeScreen(screenNanager.InvocableScreens[1]));
        BottomBarButtons[2].GetComponent<Button>().onClick.AddListener(() => screenNanager.ChangeScreen(screenNanager.InvocableScreens[2]));
        BottomBarButtons[3].GetComponent<Button>().onClick.AddListener(() => screenNanager.ChangeScreen(screenNanager.InvocableScreens[3]));
        BottomBarButtons[4].GetComponent<Button>().onClick.AddListener(() => screenNanager.ChangeScreen(screenNanager.InvocableScreens[4]));

        BottomBarButtons[0].GetComponent<Button>().onClick.AddListener(() => BottomBarButtons[0].GetComponent<bottomBarHelper>().handleColorTransition());
        BottomBarButtons[1].GetComponent<Button>().onClick.AddListener(() => BottomBarButtons[1].GetComponent<bottomBarHelper>().handleColorTransition());
        BottomBarButtons[2].GetComponent<Button>().onClick.AddListener(() => BottomBarButtons[2].GetComponent<bottomBarHelper>().handleColorTransition());
        BottomBarButtons[3].GetComponent<Button>().onClick.AddListener(() => BottomBarButtons[3].GetComponent<bottomBarHelper>().handleColorTransition());
        BottomBarButtons[4].GetComponent<Button>().onClick.AddListener(() => BottomBarButtons[4].GetComponent<bottomBarHelper>().handleColorTransition());

        BottomBarButtons[0].GetComponent<Button>().onClick.AddListener(() => BottomBarButtons[0].GetComponent<bottomBarHelper>().setTitle(title));
        BottomBarButtons[1].GetComponent<Button>().onClick.AddListener(() => BottomBarButtons[1].GetComponent<bottomBarHelper>().setTitle(title));
        BottomBarButtons[2].GetComponent<Button>().onClick.AddListener(() => BottomBarButtons[2].GetComponent<bottomBarHelper>().setTitle(title));
        BottomBarButtons[3].GetComponent<Button>().onClick.AddListener(() => BottomBarButtons[3].GetComponent<bottomBarHelper>().setTitle(title));
        BottomBarButtons[4].GetComponent<Button>().onClick.AddListener(() => BottomBarButtons[4].GetComponent<bottomBarHelper>().setTitle(title));
       /*
        * But if you really want to try, here you go
        * ow and increment this counter if you fail 
        * Attepmt : 0
        for (int i = 0; i < 5; i++)
        {
            BottomBarButtons[i].GetComponent<Button>().onClick.AddListener(() => screenNanager.ChangeScreen(screenNanager.InvocableScreens[i]));
            BottomBarButtons[i].GetComponent<Button>().onClick.AddListener(() => BottomBarButtons[i].GetComponent<bottomBarHelper>().handleColorTransition());
            BottomBarButtons[i].GetComponent<Button>().onClick.AddListener(() => BottomBarButtons[i].GetComponent<bottomBarHelper>().setTitle(title));
        }
     */
    }

    void prepareButtonHelper()
    {
        foreach (GameObject button in bottomBarButtons)
        {
            button.GetComponent<bottomBarHelper>().BottomBarMgr = this;
        }
    }

    void getBottomBarButtons()
    {
        foreach (Transform child in transform) { BottomBarButtons.Add(child.gameObject); }
    }

}
