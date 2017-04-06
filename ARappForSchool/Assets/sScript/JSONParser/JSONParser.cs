using UnityEngine;
using SimpleJSON;

/// <summary>
/// a little something to explain expressions used in our JSON file:
/// 
///     Type = determines which builder should be used (what data this file contains)
///     Name = just name of something, it can be anything. From the name of the course, to name of the friend
///     FCCount = Finished Courses count
///     DSLCount = Days spent on learning
///     PC = Profile pic (contains link do download)
///     PointsCount = points in ranking
///     RP = place in the ranking
///     messangeText = it's the whole content of news
///     KC = karma count, int, for news
///     CC = comment count, int, for news
///     amount = how many diffrent objects are there, stored in an array
///     
/// types: 
/// {
/// Friends
/// News
/// Courses
/// Ranking
/// ..
/// }
/// 
/// TODO:
/// handle courses
/// </summary>

public class JSONParser : MonoBehaviour {

    public string JsonContent = "{}";
    private JSONNode JSONParsed;
    public JSONNode NodeToSerialize;

    private string initialJson = "{}";

    public void init()
    {
        NodeToSerialize = JSON.Parse(initialJson);
    }

    public void deserialize(string json)
    {
        JSONParsed = JSON.Parse(json); // parsed object
    }

    public string getType()
    {
        return JSONParsed["Type"].Value; ;
    }

    public int getAmount()
    {
        return JSONParsed["amount"].AsInt;
    }

    public string getName()
    {
        return JSONParsed["Name"].Value;
    }

    public string getDataFromChildren(string children, string data)
    {
        return JSONParsed[children][data].Value;
    }

    public int getDataAsInt(string data)
    {
        return JSONParsed[data].AsInt;
    }
    public int getDataAsIntFromChild(string child,string data)
    {
        return JSONParsed[child][data].AsInt;
    }
    public string getDataAsString(string data)
    {
        return JSONParsed[data].Value;
    }
    public string getDataAsStringFromChild(string child,string data)
    {
        return JSONParsed[child][data].Value;
    }

    public string getSerializedData()
    {
        return NodeToSerialize.ToString();
    }
    public void addData(string where, string what)
    {
        NodeToSerialize[where] = what;
    }
    public void addDataToChildren(string where, string children, string whereInChildren , string what)
    {
        NodeToSerialize[where][children][whereInChildren] = what;
    }
}
