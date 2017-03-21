using UnityEngine;
using System.Collections.Generic;
/// <summary>
/// This script is meant to replace UIAnimationSystem. 
/// The core of this system will only allow users to use components API.
/// </summary>
public class GPASCore : MonoBehaviour {

    //private reference
    private static GPASCore p_instance;
    //public static refence for others to acces
    public static GPASCore Instance
    {
        get
        {
            if (p_instance == null)
            {
                p_instance = GameObject.FindObjectOfType<GPASCore>();
                DontDestroyOnLoad(p_instance.gameObject);
            }
            return p_instance;
        }
    }

    public List<BaseCore> cores;

    private void Awake()
    {
        if (p_instance == null)
        {
            //make it current instance then
            p_instance = this;
            //make it persistent
            DontDestroyOnLoad(this);
        }
        else
        {
            if (this != p_instance)
                Destroy(this.gameObject);
        }
        //prepare already choosen cores by passing to them reference to this
    }

    void sortCores()
    {
        cores.Sort((x, y) => x.ID.CompareTo(y.ID));
    }
    public void AppendCore(BaseCore core )
    {
        if(core != null) //pass reference to this here
            cores.Add(core);
        sortCores();
    }
    public BaseCore getCore(string ID)
    {
        int L = cores.Count;
        for (int i = 0; i < L; i++)
            if (cores[i].ID == ID)
                return cores[i];
        return null;
    }
}
