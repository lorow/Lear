using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(NetworkManager))]

public class NewsManager : BaseController {

    NetworkManager networkManager;

    private void Awake()
    {
        networkManager = gameObject.GetComponent<NetworkManager>();
    }


    public void HandleNews()
    {

    }
    void SwapPositions()
    {

    }
    public override void updateContent(JSONParser parser)
    {
      Debug.Log("updating News");
    }

}
