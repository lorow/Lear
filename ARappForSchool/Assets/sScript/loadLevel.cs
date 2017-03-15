using UnityEngine;
using UnityEngine.SceneManagement;

public class loadLevel : MonoBehaviour {
	void Start()
	{
		SceneManager.LoadScene(PlayerPrefs.GetInt("Level"));
	}
}
