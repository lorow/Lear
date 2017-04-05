using System.Collections.Generic;
using UnityEngine;

public class ScreenManagerHub : MonoBehaviour {
    [SerializeField]
    List<GameObject> screens; // home is on, rest is off
    public GameObject start;
    private void Start()
    {
        turnOff(start);

    }

    void turnOff(GameObject screenToLeave)
    {
        for (int i = 0; i < screens.Count; i++)
            if(screens[i] != screenToLeave)
                screens[i].SetActive(false);
    }

    public void changeScreen(GameObject screen)
    {
        turnOff(screen); // turn off every single screen, even if it was already off
        //and then the desired screen back on
        if(screen != null)
            screen.SetActive(true);
    }


}
