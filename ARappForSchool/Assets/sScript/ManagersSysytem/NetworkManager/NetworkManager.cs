using UnityEngine;
using System.Collections;
public class NetworkManager : MonoBehaviour
{

    //public string postaddres;
    public string answear;

    public void postMessange(string addres,string data)
    {
        string acaddr = addres + data;
        StartCoroutine(postReq(acaddr));
    }

    private IEnumerator postReq(string addr)
    {
        WWW postName = new WWW(addr);
        yield return postName;
        answear = postName.text;
    }
}
