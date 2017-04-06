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


    public void handleFriends(int amount,string Name, string PC = "00", string FCC = "00", string DSLC = "00", Texture pp = null)
    {
        //create that much clones;
        for(int i = 0; i < amount; i++)
        {
            clone = Instantiate(friendsPrefarb, friendsContent);
            clone.transform.localScale = new Vector3(1, 1, 1);
            friends = clone.GetComponent<FriendsManager>();
            friends.handleContent(Name, PC, FCC, DSLC, pp);
        }
        friends.hasContent(FriendsEmpty);
    }
    public void handleCourses(int amount,string title, Texture tex = null)
    {
        for (int i = 0; i < amount; i++)
        {
            courses.handleContent(title,tex);
        }
    }
    public void handleNews(int amount,string title, string content, int karmaCou = 0, int commentCou = 0)
    {
        for (int i = 0; i < amount; i++)
        {
            clone = Instantiate(newsPrefarb, newsContent);
            clone.transform.localScale = new Vector3(1, 1, 1);
            news = clone.GetComponent<NwesManager>();
            news.handleContent(title, content, karmaCou, commentCou);
        }
        news.hasContent(NewsEmpty);
    }
    public void handleRanking()
    {

    }
}

