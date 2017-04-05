using UnityEngine;

/// <summary>
/// how to do it properly: solution by tired mind to fresh morning mind!
/// 
/// 1. delete all this junk
/// 2. write json parser
/// 3. add reference to it here
/// 4. add all possible managers here 
/// 5. ask parser for type
/// 6. based on the answear, decide which manager to use
/// 7. use it
/// </summary>

public class GeneralCreator : MonoBehaviour
{
    public JSONParser jparser;

    #region managers
    public NwesManager news;
    public FriendsManager friends;
    public CourseManager courses;
    #endregion
    private RectTransform pl;
    // here will be network manager
    #region prefarbs
    public RectTransform newsPrefarb;
    public RectTransform friendsPrefarb;
    #endregion

    #region contents
    public RectTransform newsContent;
    public RectTransform friendsContent;
    #endregion

    public RectTransform clone;

    public GameObject FriendsEmpty;
    public GameObject NewsEmpty;

    string type = "Courses";
    private void Start()
    {
        //debug
        //type = jparser.getType();
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
        int amount = jparser.getAmount();
        //create that much clones;
        for(int i = 0; i < amount; i++)
        {
            clone = Instantiate(friendsPrefarb, friendsContent);
            clone.transform.localScale = new Vector3(1, 1, 1);
            friends = clone.GetComponent<FriendsManager>();
            friends.handleContent("test");
        }
        friends.hasContent(FriendsEmpty);
    }
    private void handleCourses()
    {
        int amount = jparser.getAmount();
        for (int i = 0; i < amount; i++)
        {
            courses.handleContent("test");
        }
    }
    private void handleNews()
    {

        int amount = jparser.getAmount();
        for (int i = 0; i < amount; i++)
        {
            clone = Instantiate(newsPrefarb, newsContent);
            clone.transform.localScale = new Vector3(1, 1, 1);
            news = clone.GetComponent<NwesManager>();
            news.handleContent("awd", "wadawd");
        }
        news.hasContent(NewsEmpty);
    }
    private void handleRanking()
    {

    }
}

