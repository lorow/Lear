using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class singleCourse : MonoBehaviour {

    [SerializeField]
    private TextMeshProUGUI title;
    [SerializeField]
    private RawImage background;
    
    public void setTitle(string T)
    {
        if (T != null)
            title.text = T;
    }
    public void setBackground(Texture tex)
    {
        if (tex != null)
            background.texture = tex;
    }


}
