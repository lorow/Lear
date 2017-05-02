using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GPASImageCore : MonoBehaviour {

    public void lerpColor(Image desiredImage, Color to, float duration = 1)
    {
        if (desiredImage == null || to == null)
            Debug.LogError("One of the following : desired image or end color, or both of them are null, fix this before anything");
        else
        {
            desiredImage.DOColor(to, duration);
        }

    }
    public void colorFade(Image desiredImage,int alpha, float duration = 1)
    {
        if (desiredImage == null)
            Debug.LogError("desired image is null, please fix this");
        else
            desiredImage.DOFade(alpha, duration);
    }
    public void MaterialColorLerp(Image desiredImage, Material to, float duration = 1)
    {
        if (desiredImage == null || to == null)
            Debug.LogError("One of the following : desired imageor end material, or both of them are null, fix this before anything");
        else
        {
            desiredImage.material.DOColor(to.color, duration);
        }

    }
    public void move(Transform objectTransform ,Vector3 destination, float speed = 1, bool snapping = false)
    {
        if (objectTransform == null || destination == null)
            Debug.LogError("One of the following : object transform or destination vector, or both of them are null, fix this before anything");
        else
        {
            objectTransform.DOMove(destination, speed, snapping);
        }

    }
    public void scale(Transform objectTransform, Vector3 desiredScale, float speed = 1, bool shake = false, float shakeforce = 0)
    {
        if (objectTransform == null || desiredScale == null)
            Debug.LogError("One of the following : object transform or destination vector, or both of them are null, fix this before anything");
        else
        {
            if (shake)
                objectTransform.DOShakeScale(speed, shakeforce);
            else
            {
                objectTransform.DOScaleX(desiredScale.x, speed);
                objectTransform.DOScaleY(desiredScale.y, speed);
                objectTransform.DOScaleZ(desiredScale.z, speed);
            }
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
    public void swapImage(Image imageObject, Sprite desiredImage)
    {
        if (imageObject == null || desiredImage == null)
            Debug.LogError("One of the following : object with image component or desired image, or both of them are null, fix this before anything");
        else
        {
            imageObject.sprite = desiredImage;
        }
    }
    public void swapImage(RawImage imageObject, Texture desiredImage)
    {
        if (imageObject == null || desiredImage == null)
            Debug.LogError("One of the following : object with image component or desired image, or both of them are null, fix this before anything");
        else
        {
            imageObject.texture = desiredImage;
        }
    }
}
