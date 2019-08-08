using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject root;
    [SerializeField] private GameObject loading;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator LoadAsyncScene(string name)
    {
        if (root != null)
        {
            root.SetActive(false);
        }

        if (loading != null)
        {
            loading.SetActive(true);
        }

        yield return new WaitForSeconds(1f);

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(name);

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }

    public void LoadAsyncScenePanel_01() {
        StartCoroutine(LoadAsyncScene("Panel_01"));
    }
}
