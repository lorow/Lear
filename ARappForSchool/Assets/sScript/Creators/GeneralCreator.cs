using UnityEngine;

/// <summary>
/// how to do it properly: solution by tired mind to fresh morning mind!
/// 
/// 1. delete all this junk
/// 2. write json parses
/// 3. add reference to it here
/// 4. add all possible managers here 
/// 5. ask parser for type
/// 6. based on the answear, decide which manager to use
/// 7. use it
/// 
/// but first, write those fucking managers and this parser
/// </summary>

public class GeneralCreator : MonoBehaviour
{
    //public RectTransform prefarb;
    //public RectTransform content;
    //public RectTransform clone;
    //based on input from json
    //private void Start()
    //{
    //for (int i = 0; i < 5; i++)
    //{
    //  clone = Instantiate(prefarb, content);
    //    clone.transform.localScale = new Vector3(1, 1, 1);
    //      clone.GetComponent<FriendsManager>().handleContent("T");
    //    }
    //      clone.GetComponent<FriendsManager>().hasContent();
    //    }

    public JSONParser jparser;

    #region managers
    public NwesManager news;
    public FriendsManager friends;
    #endregion
    private RectTransform pl;
    // here will be network manager
    #region prefarbs
    public RectTransform newsPrefarb;
    public RectTransform friendsPrefarb;
    #endregion

    public RectTransform clone;

    string type;
    private void Start()
    {
        type = jparser.getType();
        switch(type)
        {
            case "Friends":
                handleFriends();
                break;
            case "News":
                handleNews();
                break;
            case "Courses":
                handleCourses();
                break;
            case "Ranking":
                handleRanking();
                break;
        }
    }

    private void handleFriends()
    {

    }
    private void handleCourses()
    {

    }
    private void handleNews()
    {

    }
    private void handleRanking()
    {

    }
}

