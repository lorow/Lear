using UnityEngine;

[RequireComponent(typeof(UIAnimations))]
[RequireComponent(typeof(AnchorSystemStructMgr))]
[RequireComponent(typeof(TextManager))]

public class StateManager : MonoBehaviour {

    public enum states {
                        none,
                        animateText,
                        showButtons,
                        HandleScreens,
                        };

    public states state;

    public UIAnimations anims;
    public TextManager textManager;
    public AnchorSystemStructMgr anchors;
    public ButtonsManager buttonsManager;
    [SerializeField]
    private GameObject objectToManipulate;

    public float desiredTime;

    //get and initialize all of the needed managers
    void Start()
    {
        anchors = this.GetComponent<AnchorSystemStructMgr>();
        textManager = this.GetComponent<TextManager>();
        textManager.init();
        buttonsManager = this.GetComponent<ButtonsManager>();
        buttonsManager.Init();
    }

    void Update()
    {
        switch (state)
        {
            case states.none:
                break;

            case states.animateText:
                desiredTime = 2;
                objectToManipulate = anchors.getGameobject("textPosAnch");
                if (textManager.timer(desiredTime))
                {
                    textManager.fadeText(1, 3);
                    if (textManager.testAlphaText(0.80f))
                        anims.move(textManager.text.transform, objectToManipulate.transform, 1.5f);
                }

                if (textManager.actualTime >= 2)
                    changeState(states.showButtons);
                break;

            case states.showButtons:
                if (textManager.timer(2))
                    buttonsManager.animateButtons();
                if (buttonsManager.testAlpha(0.90f))
                {
                    buttonsManager.madeClickable();
                    changeState(states.HandleScreens);
                }
                break;

            case states.HandleScreens:
                break;
        }

    }
    void changeState(states State) { state = State; }
}
