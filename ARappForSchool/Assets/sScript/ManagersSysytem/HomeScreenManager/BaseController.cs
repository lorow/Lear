using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseController : MonoBehaviour {

    //implement this to update any kind of content
    public abstract void updateContent(JSONParser parser);
}
