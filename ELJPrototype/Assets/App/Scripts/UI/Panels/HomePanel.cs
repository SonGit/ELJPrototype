using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HomePanel : BasicPanelNavigation
{
    protected override void Start()
    {
        base.Start();
    }

    public void LoadSceneCoffeShop()
    {
        if (ScenesManager.Instance != null)
        {
            ScenesManager.Instance.LoadScene("CoffeShopMenu_2D");
        }
        else {
            Debug.Log("NULL...............");
        }
       
    }

    public void LoadSceneBank()
    {
        if (ScenesManager.Instance != null)
        {
            ScenesManager.Instance.LoadScene("BankMenu_2D");
        }
        else
        {
            Debug.Log("NULL...............");
        }

    }
}