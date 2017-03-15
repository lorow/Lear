using UnityEngine.UI;
using UnityEngine;
using DG.Tweening;
public class FadeManager : MonoBehaviour
{
    //fades the material color of text, not the color itself
    public void FadeMat(int value /*between 1 and 0*/, float duration, Material mat)
    {
        DOTween.ToAlpha(() => mat.color,
                          x => mat.color = x,
                          value,
                          duration);
        
    }
    public void init(Text element)
    {
        Color col = new Color(255, 255, 255, 0);
       element.material.color = col;
    }
}