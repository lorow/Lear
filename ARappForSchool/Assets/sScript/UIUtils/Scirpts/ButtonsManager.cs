using UnityEngine;
using UnityEngine.UI;
public class ButtonsManager : MonoBehaviour {

    public FadeManager fManager;

    public GameObject[] Buttons;

    public float getAlpha(Material mat) { return mat.color.a; }
    public void Init()
    {
        fManager = this.GetComponent<FadeManager>();
        Color col = new Color(255, 255, 255, 0);
        for (int i = 0; i < Buttons.Length; ++i)
            Buttons[i].GetComponent<Image>().material.color = col;
    }

    private float time = 0;
    public float actualTime;

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

    public void animateButtons()
    {
        foreach (GameObject button in Buttons)
        {
            button.GetComponent<Button>().interactable = false;
            fManager.FadeMat(1, 5, button.GetComponent<Image>().material);
        }
    }
    public bool testAlpha(float val)
    {
        if (getAlpha(Buttons[0].GetComponent<Image>().material) >= val)
            return true;
        return false;
    }
    public void madeClickable()
    {
        foreach (GameObject button in Buttons)
            button.GetComponent<Button>().interactable = true;
    }
}
