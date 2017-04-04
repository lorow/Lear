using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class FriendsManager : MonoBehaviour {

    [SerializeField]
    private TextMeshProUGUI name;
    [SerializeField]
    private TextMeshProUGUI pointsCount;
    [SerializeField]
    private TextMeshProUGUI FCCount; // finished courses count
    [SerializeField]
    private TextMeshProUGUI DSLCount; // days spent on learining count
    [SerializeField]
    private RawImage profilePic;
    [SerializeField]
    private RectTransform emptyMessange;

    public void handleContent(string Name,string PC = "00", string FCC = "00", string DSLC = "00", Texture pp = null)
    {
        setName(Name);
        setPointsCount(PC);
        setFFC(FCC);
        setDSL(DSLC);
        setPP(pp);
    }
    public void hasContent()
    {
        emptyMessange = GameObject.FindGameObjectWithTag("FriendEmpty").GetComponent<RectTransform>();
        emptyMessange.gameObject.SetActive(false);
    }
    
    private void setName(string n)
    {
        if (n != null)
            name.text = n;
    }
    private void setPointsCount(string ptn)
    {
        if (ptn != null)
            pointsCount.text = ptn;
    }
    private void setFFC(string FCC)
    {
        if (FCC != null)
            FCCount.text = FCC;
    }
    private void setDSL(string DSL)
    {
        if (DSL!= null)
            DSLCount.text = DSL;
    }
    private void setPP(Texture PP)
    {
           profilePic.texture = PP;
    }
}
