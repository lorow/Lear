using UnityEngine;

[RequireComponent(typeof(GPASBaseCore))]
[RequireComponent(typeof(GPASImageCore))]
[RequireComponent(typeof(GPASTextCore))]


public class GPASCoreManager : MonoBehaviour
{
    [SerializeField]
    private GPASBaseCore _baseCore;
    [SerializeField]
    private GPASImageCore _imageCore;
    [SerializeField]
    private GPASTextCore _textCore;

    public GPASBaseCore BaseCore { get { return _baseCore; } }
    public GPASImageCore ImageCore { get { return _imageCore; } }
    public GPASTextCore TextCore { get { return _textCore; } } 

    private void Awake()
    {
        getCores();
    }
    private void getCores()
    {
        _baseCore = gameObject.GetComponent<GPASBaseCore>();
        _imageCore = gameObject.GetComponent<GPASImageCore>();
        _textCore = gameObject.GetComponent<GPASTextCore>();
    }

}
