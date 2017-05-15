using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(NetworkManager))]

public class RecentCoursesManager : BaseController {

    HomeScreenManager homeScreen;

    [SerializeField]
    GameObject[] courseButtons;
    [SerializeField]
    GameObject[] dots;
    [SerializeField]
    GameObject courseContent;
    [SerializeField]
    int clickCounter = 0;
    [SerializeField]
    float size = 1050;
    [SerializeField]
    Color dotColor;

    [Space]

    [SerializeField]
    GPASCoreManager GPASManager;

    [SerializeField]
    SingleCourseManager[] scmanagers;

    NetworkManager networkManager;

    private void Awake()
    {
        networkManager = gameObject.GetComponent<NetworkManager>();
    }

    public void HandleRecentCourses()
    {
        HandleButtons();
    }
    void HandleButtons()
    {
        courseButtons[0].GetComponent<Button>().onClick.AddListener(() => PrepareButtons(0));
        courseButtons[1].GetComponent<Button>().onClick.AddListener(() => PrepareButtons(1));
    }

    void PrepareButtons(int decOrInc)
    {
        if (decOrInc == 0)
        {
            MoveContent(decOrInc, courseContent.transform);
        }
        else
        {
            MoveContent(decOrInc, courseContent.transform);
        }
        HandleDots(clickCounter);
    }

    void MoveContent(int direction, Transform transform)
    {
        //put this in coroutine or smth
        Vector3 newPos = Vector3.zero;
        if (direction == 0)
        {
            if (clickCounter > 0)
            {
                DecCounter();
                newPos = new Vector3(transform.position.x + size, transform.position.y, transform.position.z);
                GPASManager.ImageCore.move(transform, newPos);
            }
        }
        else
        {
            if (clickCounter < 2)
            {
                IncCounter();
                newPos = new Vector3(transform.position.x - size, transform.position.y, transform.position.z);
                GPASManager.ImageCore.move(transform, newPos);
            }
        }
    }

    void IncCounter()
    {
        if (clickCounter == 2)
            clickCounter = 0;
        else
            clickCounter++;
    }
    void DecCounter()
    {
        if (clickCounter == 0)
            clickCounter = 2;
        else
            clickCounter--;
    }

    void HandleDots(int whichDot)
    {
        TurnWhite(dots.Length);
        Colorize(whichDot);
    }
    void Colorize(int which)
    {
        GPASManager.ImageCore.lerpColor(dots[which].GetComponent<Image>(), dotColor);
    }
    void TurnWhite(int size)
    {
        for (int i = 0; i < size; i++)
            GPASManager.ImageCore.lerpColor(dots[i].GetComponent<Image>(), Color.white);
    }

    public override void updateContent(JSONParser parser)
    {
        Debug.Log("updating Curses");
    }
    
    string prepareRequest(int index)
    {
        string req = " { \"type\" : \" courseImageReq \", " +
            "\"index\" : "  + index + "}";
        return req;
    }

    void prepareCourses(JSONParser pars)
    {
        for (int i = 0; i < 3; i++)
        {
            //assuming that returned messange will be a link to an image
            networkManager.postMessange(homeScreen.addres,prepareRequest(i));
            pars.getDataAsString(networkManager.answear);

        }
    }

}
