using System.Collections.Generic;
using UnityEngine;

public class ScreenManagerHub : MonoBehaviour
{
    [SerializeField]
    public List<GameObject> InvocableScreens
    {
        get { return invocableScreens; }
        set { invocableScreens = value; }
    }

    [SerializeField]
    private List<GameObject> invocableScreens;

    [SerializeField]
    List<GameObject> allScreens;

    [SerializeField]
    private GameObject specialScreen;

    [SerializeField]
    private GameObject baseScreen;

    private void Awake()
    {
        ChangeScreen(baseScreen);
    }

    void TurnOff(GameObject screenToLeave)
    {
        for (int i = 0; i < allScreens.Count; i++)
            if (allScreens[i] != screenToLeave && allScreens[i] != specialScreen)
                allScreens[i].SetActive(false);
    }

    public void TurnOnSelf(GameObject This)
    {
        This.SetActive(true);
    }
    public void TurnOffSelf(GameObject This)
    {
        This.SetActive(false);
    }

    public void ChangeScreen(GameObject screen)
    {
        TurnOff(screen);
        if (screen != null)
            screen.SetActive(true);
    }
}