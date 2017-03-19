using UnityEngine;

public class HamburgerMenuInvoker : MonoBehaviour
{
    public GameObject hamburgerMenu;
    public bool isActive = false;
    
    public void handleMenu()
    {
        isActive = !isActive;
    }
    private void Update()
    {
        hamburgerMenu.SetActive(isActive);
    }
}
