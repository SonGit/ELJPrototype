using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsMenu : BasicMenu
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnEnableSettingMenu()
    {
        OnSetActive(root,true);
    }

    public void OnDisableSettingMenu()
    {
        OnSetActive(root, false);
    }

    public void RestartBnt_Onclick()
    {
        if (CoffeShopMenu.instance != null)
        {
            CoffeShopMenu.instance.RestartAll();
        }
    }
}
