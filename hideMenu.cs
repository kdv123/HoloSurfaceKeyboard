using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hideMenu : MonoBehaviour
{

    public GameObject menu;

    public void onClick()
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

}
