    using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HomeScreenManager : MonoBehaviour
{
#region courseVars
    [SerializeField]
    GameObject[] courseButtons;
    [SerializeField]
    GameObject[] dots;
    [SerializeField]
    GameObject courseContent;
    [SerializeField]
    GameObject newsContent;
    [SerializeField]
    int clickCounter = 0;
    [SerializeField]
    float size = 1050;
    [SerializeField]
    Color dotColor;
#endregion
    [Space]
#region newsVars
    [Space]
#endregion
    [SerializeField]
    GPASCoreManager GPASManager;

    private void Awake()
    {
        HandleRecentCourses();
        HandleNews();
    }

    #region recent courses
    void HandleRecentCourses()
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
            if(clickCounter > 0)
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
#endregion

#region news
    void HandleNews()
    {

    }
    void SwapPositions()
    {

    }
    void UpdateContent()
    {

    }
    #endregion

#region json module 
    enum requestType
    {
        none,
        updateCourses,
        updateNews
    };
    requestType req = requestType.none;
    #endregion
#region gesture controller
    void HandelGestures()
    {

    }
    void PullDownGesture()
    {

    }
    void HoldGesture()
    {

    }
#endregion
}
