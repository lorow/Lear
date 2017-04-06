using UnityEngine;
using System.Collections;
public class NetworkManager : MonoBehaviour {

    public string postaddres; // addres of communication
    public JSONParser parser;
    public GeneralCreator GCreator;
    public string answear;
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
        parser.init();
        parser.addData("type", "login");
        parser.addData("login", login);
        parser.addData("passwd", passwd);
        Debug.Log(parser.getSerializedData());
        postM(parser.getSerializedData());  
    }
    public void register(string login, string email, string passwd, string spasswd)
    {
        parser.init();
        parser.addData("type", "register");
        parser.addData("login", login);
        parser.addData("email", email);
        parser.addData("passwd", passwd);
        parser.addData("spasswd", spasswd);
        postM(parser.getSerializedData());
    }

    public void getCourses()
    {
        //give me json with data here
        parser.init();
        parser.addData("type", "courses");
        parser.addData("secType", "request");
        parser.addData("id", "admin");
        postM(parser.getSerializedData());
        handleData();
    }
    public void getNews()
    {
        parser.init();
        parser.addData("type", "news");
        parser.addData("secType", "request");
        parser.addData("id", "admin");
        postM(parser.getSerializedData());
        handleData();
    }
    public void getFriends()
    {
        parser.init();
        parser.addData("type", "friends");
        parser.addData("secType", "request");
        parser.addData("id", "admin");
        postM(parser.getSerializedData());
        handleData();
    }
    public void handleData()
    {
        parser.deserialize(answear); // deserialize answear
        if(parser.getType() == "courses")
        {
             switch (parser.getType())
             {
                    case "friends":
                        GCreator.handleFriends(
                            parser.getDataAsInt("amount"),
                            parser.getDataAsString("string"),
                            parser.getDataAsString("PC"),
                            parser.getDataAsString("FCC"),
                            parser.getDataAsString("DSLC"),
                            null
                            //get texture here
                            );
                        break;

                    case "news":
                        GCreator.handleNews(
                            parser.getDataAsInt("amount"),
                            parser.getDataAsString("title"),
                            parser.getDataAsString("content"),
                            parser.getDataAsInt("karmaCount"),
                            parser.getDataAsInt("commentCount")
                            );
                        break;

                    case "courses":
                    for (int i = 0; i < parser.getDataAsInt("amount"); i++)
                    {

                        GCreator.handleCourses(
                            parser.getDataAsInt("amount"),
                            parser.getDataAsStringFromChild(("tile" + i),"title"),
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
