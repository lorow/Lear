using UnityEngine;
using TMPro;
public class NwesManager : MonoBehaviour {

    [SerializeField]
    private TextMeshProUGUI titleText;
    [SerializeField]
    private TextMeshProUGUI messangeText;
    [SerializeField]
    private TextMeshProUGUI karmaCount;
    [SerializeField]
    private TextMeshProUGUI commentCount;
    [SerializeField]
    private GameObject emptyMesaange;

    public string shorted = "";

    public void handleContent(string title, string content, int karmaCou = 0, int commentCou = 0)
    {
        setTitle(title);
        setContent(content);
        setKarmaCount(karmaCou);
        setCommentCount(commentCou);
    }
    public void hasContent(GameObject empty)
    {   
        if(empty != null)
            emptyMesaange = empty;
        emptyMesaange.SetActive(false);
    }

    private void setTitle(string title)
    {
        if (title != null)
            titleText.text = title;
    }
    private void setContent(string content)
    {
        if (content != null)
        {
            if (content.Length <= 345)
                messangeText.text = content;
            else
            {
                //shorted   = "";
                for (int i = 0; i < 345; i++)
                    shorted += content[i];
                Debug.Log(shorted);
            }
        }
    }
    private void setKarmaCount(int karma)
    {
            karmaCount.text = karma.ToString();
    }
    private void setCommentCount(int count)
    {
            commentCount.text = count.ToString();
    }
}
