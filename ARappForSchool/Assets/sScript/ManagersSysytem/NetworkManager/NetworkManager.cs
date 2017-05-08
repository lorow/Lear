using UnityEngine;
using System.Collections;
public class NetworkManager : MonoBehaviour
{

    public string postaddres { get; set; }
    public string answear { get; set; }

    [SerializeField]
    private JSONParser parser;
    public JSONParser Parser
    {
        get { return parser; }
        set { parser = value; }
    }

    [SerializeField]
    private GeneralCreator gCreator;
    public GeneralCreator GCreator
    {
        get {return gCreator;}
        set {gCreator = value;}
    }

    public void Start()
    {
        login("test", "haslo");
    }

    public void postM(string data)
    {
        string acaddr = postaddres + data;
        Debug.Log(acaddr);
        StartCoroutine(postReq(acaddr));
    }

    private IEnumerator postReq(string addr)
    {
        WWW postName = new WWW(addr);
        yield return postName;

        answear = postName.text;
        Debug.Log("test" + postName.text);
    }

    public void login(string login, string passwd)
    {
        Parser.init();
        Parser.addData("type", "login");
        Parser.addData("login", login);
        Parser.addData("passwd", passwd);
        Debug.Log(Parser.getSerializedData());
        postM(Parser.getSerializedData());
    }
    public void register(string login, string email, string passwd, string spasswd)
    {
        Parser.init();
        Parser.addData("type", "register");
        Parser.addData("login", login);
        Parser.addData("email", email);
        Parser.addData("passwd", passwd);
        Parser.addData("spasswd", spasswd);
        postM(Parser.getSerializedData());
    }

    public void getCourses()
    {
        Parser.init();
        Parser.addData("type", "courses");
        Parser.addData("secType", "request");
        Parser.addData("id", "admin");
        postM(Parser.getSerializedData());
        handleData();
    }
    public void getNews()
    {
        Parser.init();
        Parser.addData("type", "news");
        Parser.addData("secType", "request");
        Parser.addData("id", "admin");
        postM(Parser.getSerializedData());
        handleData();
    }
    public void getFriends()
    {
        Parser.init();
        Parser.addData("type", "friends");
        Parser.addData("secType", "request");
        Parser.addData("id", "admin");
        postM(Parser.getSerializedData());
        handleData();
    }
    public void handleData()
    {
        Parser.deserialize(answear);
        if (Parser.getType() == "courses")
        {
            switch (Parser.getType())
            {
                case "friends":
                    GCreator.handleFriends(
                        Parser.getDataAsInt("amount"),
                        Parser.getDataAsString("string"),
                        Parser.getDataAsString("PC"),
                        Parser.getDataAsString("FCC"),
                        Parser.getDataAsString("DSLC"),
                        null
                        //get texture here
                        );
                    break;

                case "news":
                    GCreator.handleNews(
                        Parser.getDataAsInt("amount"),
                        Parser.getDataAsString("title"),
                        Parser.getDataAsString("content"),
                        Parser.getDataAsInt("karmaCount"),
                        Parser.getDataAsInt("commentCount")
                        );
                    break;

                case "courses":
                    for (int i = 0; i < Parser.getDataAsInt("amount"); i++)
                    {

                        GCreator.handleCourses(
                            Parser.getDataAsInt("amount"),
                            Parser.getDataAsStringFromChild(("tile" + i), "title"),
                            //get texture here
                            null
                            );
                    }
                    break;

                case "ranking":
                    GCreator.handleRanking();
                    break;
            }
        }
    }
}
