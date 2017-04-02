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

public class GeneralCreator : MonoBehaviour {



    public RectTransform prefarb;
    public RectTransform content;
    public RectTransform clone;
    //based on input from json
    private void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            clone = Instantiate(prefarb, content);
            clone.transform.localScale = new Vector3(1, 1, 1);
            clone.GetComponent<FriendsManager>().handleContent("T");
        }
        clone.GetComponent<FriendsManager>().hasContent();
    }
}
