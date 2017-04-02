using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// attach this component to the parent of content gameobject
/// </summary>

public class ScrollManager : MonoBehaviour {

    public RectTransform content; // stores the content object 

    public RectTransform topAnch; // stores the content object 
    public RectTransform bottomAnch; // stores the content object 

    public Vector2 T;

    private void Update()
    {
        
    }
}
