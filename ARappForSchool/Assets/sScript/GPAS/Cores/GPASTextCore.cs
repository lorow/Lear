using UnityEngine;
using TMPro;
using DG.Tweening;

public class GPASTextCore : MonoBehaviour
{

    public void lerpTextColor(TextMeshProUGUI GUIText, Color desiredColor, float speed = 1)
    {
        if (GUIText == null || desiredColor == null)
            Debug.LogError("One of the following : text component or desired color or both of them are null, fix this before anything");
        else
        {
            GUIText.DOColor(desiredColor, speed);
        }
    }
    public void fadeText(TextMeshProUGUI GUIText, bool fadeout = false, float speed = 1)
    {
        if (GUIText == null)
            Debug.LogError("Text gui component is null, fix this before anything");
        else
        {
            int alpha = fadeout ? 1 : 0;
            Color temp = new Color(GUIText.color.r, GUIText.color.g, GUIText.color.b, alpha);
            GUIText.DOColor(temp, speed);
        }
    }
    public void replaceTextSmoothly()
    {
        Debug.Log("um, call the programmer, i'm not implemented yet!!!");
    }
    public void setFontStyle(TextMeshProUGUI GUItext, FontStyles styles)
    {
        if (GUItext == null)
            Debug.LogError("Text gui component is null, fix this before anything");
        else
            GUItext.fontStyle = styles;
    }
    public void scaleFont(TextMeshProUGUI GUItext, float fontScale)
    {
        if (GUItext == null)
            Debug.LogError("Text gui component is null, fix this before anything");
        else
            GUItext.fontSize = fontScale;
    }
    public void changeAligment(TextMeshProUGUI GUItext, TextAlignmentOptions aligment)
    {
        GUItext.alignment = aligment;
    }
    public void move(Transform gameObjectTransform, Vector3 desiredPosition, float speed = 1)
    {
        if (gameObjectTransform == null || desiredPosition == null)
            Debug.LogError("One of the following : object's transfom component or desired position, or both of them are null, fix this before anything");
        else
        {
            gameObjectTransform.DOMove(desiredPosition, speed);
        }
    }
    public void scale(Transform objectTransform, float desiredScale = 1, float speed = 1)
    {
        if (objectTransform == null)
            Debug.LogError("object transform is null, fix this before anything");
        else
        {
            objectTransform.DOScale(desiredScale, speed);
        }
    }
    public void rotate(Transform objectTransform, Vector3 desiredRotation, float speed = 1, bool shake = false, float shakeforce = 0)
    {
        if (objectTransform == null || desiredRotation == null)
            Debug.LogError("One of the folowing : object transform or desired rotation, are null, fix this before anything");
        else
        {
            if (shake)
                objectTransform.DOShakeRotation(speed, shakeforce);
            else
            {
                objectTransform.DORotate(desiredRotation, speed);
            }
        }
    }
}
