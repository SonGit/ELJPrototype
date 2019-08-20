using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public GameObject root;
    [SerializeField] private Text headerText;
    [SerializeField] private BasicMenu basicMenu;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (basicMenu == null)
        {
            if (CoffeShopMenu.Instance != null)
            {
                basicMenu = CoffeShopMenu.Instance;
            }

            if (BankMenu.Instance != null)
            {
                basicMenu = BankMenu.Instance;
            }

        }
    }

    private void OnSetActive(GameObject obj, bool value)
    {
        if (obj != null)
        {
            obj.SetActive(value);
        }
    }

    public void OnEnableSettingMenu()
    {
        OnSetActive(root, true);

        SetSettingHeader("Setting");
    }

    public void OnDisableSettingMenu()
    {
        OnSetActive(root, false);
    }

    public void RestartBnt_Onclick()
    {
        if (basicMenu != null)
        {
            basicMenu.RestartAll();
        }
    }

    public void HomeBnt_Onclick()
    {
        if (ScenesManager.Instance != null)
        {
            ScenesManager.Instance.LoadScene("Main");
        }
    }

    public void SetSettingHeader(string info)
    {
        if (headerText != null)
        {
            headerText.text = info;
        }
    }
}
