using UnityEngine;
/// <summary>
/// just prototyping, don't worry, in finall version it will be changed
/// </summary>
public class BaseCore : MonoBehaviour {
    public string ID = "";
    public GPASCore core;
    public void init(GPASCore cr) { if (cr != null) { core = cr; } }
}
