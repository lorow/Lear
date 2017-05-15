using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HomeScreenManager : MonoBehaviour
{
    [SerializeField]
    RecentCoursesManager courseManager;
    [SerializeField]
    NewsManager newsManager;

    [SerializeField]
    GameObject updateButton;

    [SerializeField]
    JSONParser parser;
    [SerializeField]
    NetworkManager networkManager;

    public string addres;

    private void Awake()
    {
        updateButton.GetComponent<Button>().onClick.AddListener(()=>UpdateContent());
    }
    void UpdateContent()
    {
        courseManager.updateContent(parser);
        newsManager.updateContent(parser);
    }
}
