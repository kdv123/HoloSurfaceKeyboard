using UnityEngine;

/**
 * Author : Joshua Reynolds
 * Description : Calls general buttons on button menu
 */
public class buttonCalls : MonoBehaviour
{

    public GameObject menu;
    public GameObject mainButtons;
    public GameObject experimentButtons;

    public void hideMenu()
    {

        if (menu.activeSelf == true)
        {
            menu.SetActive(false);
        }
        else if (menu.activeSelf == false)
        {
            menu.SetActive(true);
        }

    }

    public void goBack()
    {
        mainButtons.SetActive(true);
        experimentButtons.SetActive(false);
    }

    public void experimentButton()
    {
        mainButtons.SetActive(false);
        experimentButtons.SetActive(true);
    }

}
