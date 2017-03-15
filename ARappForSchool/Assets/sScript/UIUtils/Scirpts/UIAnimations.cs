using UnityEngine;
using System.Collections.Generic;
using DG.Tweening;

public class UIAnimations : MonoBehaviour
{
    [SerializeField]
    #region animationMethods
    public void move(Transform objectToMove,Transform location, float duration = 2.0f)
    {
        objectToMove.DOMove(location.position, duration);
    }
    public void scale(Transform scalar,float desiredScale,float duration = 5.0f)
    {
        scalar.DOScale(desiredScale, duration);
    }
    #endregion
}
