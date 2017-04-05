using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// this script handles utilities which couldn't be placed in any of ther scripts
/// </summary>

public class TextManager : MonoBehaviour { 
    [SerializeField]
    public Text text;
    public FadeManager fManager;

    private float time = 0;
    public float actualTime;

    public void init()
    {
        initText(); // init the text
        fManager = this.GetComponent<FadeManager>();
    }

    public float getAlpha(Material mat) { return mat.color.a; }

    #region text
    public void initText()
    {
        fManager.init(text);
    }

    public void fadeText(int alpha, float duration)
    {
        fManager.FadeMat(alpha, duration, text.material);
    }

    public bool testAlphaText(float val)
    {
        if (getAlpha(text.GetComponent<Text>().material) >= val)
            return true;
        return false;
    }
    #endregion

#region timer
    //just a timer
    public bool timer(float desiredTime)
    {
        actualTime = time;
        if (time <= desiredTime)
        {
            time += Time.deltaTime;
            return true;
        }
        time = 0;
        return false;
    }
    #endregion
}
