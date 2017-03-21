using System.Collections.Generic;
using UnityEngine;

public class AnchorSystemStructMgr : MonoBehaviour {

    [System.Serializable]
    public class anchors
    {
      public string id;
      public GameObject objc;
    }
    public List<anchors> anchs;

    //retuns reference to object of given id in a list
    public GameObject getGameobject(string id)
    {
        int cacheSize = anchs.Count;
        foreach (anchors anch in anchs)
        {
            if (anch.id == id)
                return anch.objc;
        }
        return null;
    }
}
