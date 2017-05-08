using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour {

// bools for operating the windows
[SerializeField]
bool bcloseCredits = false;
[SerializeField]
bool bcloseSettings = false;
[SerializeField]
bool startVR = false;

//objects to manipulate
public GameObject Credits;
public GameObject Settings;

[SerializeField]
private GameObject[] gameObjectsOnMap;
 
void Awake ()
{
	//sets orientation of the screen on startup
	Screen.orientation = ScreenOrientation.Portrait;
	//finds and turns off necessary gameObjects
	Credits = GameObject.FindGameObjectWithTag("Credits");
	Credits.SetActive(false);
	Settings = GameObject.FindGameObjectWithTag("settings");
	Settings.SetActive(false);
	//set startVR to saved value
	startVR = CheckVR();
}
public void manageCreditsWindow() // here make this window openable 
	{
		if(bcloseCredits)
			Credits.SetActive(false);
		else
			Credits.SetActive(true);

		bcloseCredits = !bcloseCredits;
	}
public void manageSettingsWindow() // here make this window openable
	{
		if(bcloseSettings)
			Settings.SetActive(false);
		else
			Settings.SetActive(true);

		bcloseSettings = !bcloseSettings;
	}
public void setVRMode() 
	{
		if(startVR)
			PlayerPrefs.SetInt("VRmode",1);
		else
			PlayerPrefs.SetInt("VRmode",0);

		startVR = !startVR;
		setScreenOrientation(ScreenOrientation.AutoRotation);
	}
public void toMainMenu()
	{
		SceneManager.LoadScene(0);
	}
public void startGame()
	{
		
		if (startVR)
			PlayerPrefs.SetInt("Level", 2); // load Level number 2 which is vr Scene (it'll be number 3)
		else
			PlayerPrefs.SetInt("Level", 2); // load Level number 2 which is normal scene

		SceneManager.LoadScene(1);
	}
public void goToMainMenu()
	{
		PlayerPrefs.SetInt("Level", 0); // main menu scene
		SceneManager.LoadScene(1); //load loading screen
	}

public void resetMap()
{
	foreach (GameObject objectToReset in gameObjectsOnMap)
	{
		objectToReset.transform.localScale = new Vector3(1,1,1);
		objectToReset.transform.rotation = Quaternion.Euler(0,0,0); 
	}
}
public void saveObjectValues()
{
	for(int i = 0; i < gameObjectsOnMap.Length; i++)
	{ 
		string name = "GameObject" + i; // name for id
		//saving scale
		PlayerPrefs.SetFloat(name + "scaleX", gameObjectsOnMap[i].transform.localScale.x);
		PlayerPrefs.SetFloat(name + "scaleY", gameObjectsOnMap[i].transform.localScale.y);
		PlayerPrefs.SetFloat(name + "scaleZ", gameObjectsOnMap[i].transform.localScale.z);
		//saving rotation
		PlayerPrefs.SetFloat(name + "rotationX", gameObjectsOnMap[i].transform.localRotation.eulerAngles.x);
		PlayerPrefs.SetFloat(name + "rotationY", gameObjectsOnMap[i].transform.localRotation.eulerAngles.y);
		PlayerPrefs.SetFloat(name + "rotationZ", gameObjectsOnMap[i].transform.localRotation.eulerAngles.z);

		//value to check if saved
		PlayerPrefs.SetInt("saved",1);		
	}
}
public void loadSave()
{
	if(PlayerPrefs.GetInt("saved") == 1)
	{
		for(int i = 0; i < 6; i++)
		{ 
		string name = "GameObject" + i;
		//create vectors from saved values
			Vector3 scal = new Vector3(PlayerPrefs.GetFloat(name +"scaleX"),PlayerPrefs.GetFloat(name +"scaleY"),PlayerPrefs.GetFloat(name +"scaleZ"));
			Vector3 rot = new Vector3(PlayerPrefs.GetFloat(name +"rotationX"),PlayerPrefs.GetFloat(name +"rotationY"),PlayerPrefs.GetFloat(name +"rotationZ"));
		//apply them
		gameObjectsOnMap[i].transform.localScale = scal;
		gameObjectsOnMap[i].transform.rotation = Quaternion.Euler(rot);
		}
	}
}
public void saveAll()
{
	PlayerPrefs.Save();
}
//helping functions
void setScreenOrientation(ScreenOrientation orient)
{
	//just changes the orientation of the Screen
	Screen.orientation = orient;
}
bool CheckVR()
{
	if(PlayerPrefs.HasKey("VRmode"))
		if(PlayerPrefs.GetInt("VRmode") == 1)
			return true;
	else
		PlayerPrefs.SetInt("VRmode", 0);

	return false;
}

}
