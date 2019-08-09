using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchZone : MonoBehaviour
{
    [SerializeField] private GameObject targetObj;

    private CanvasGroup _canvasGroup;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerEnter()
    {
        if (targetObj != null)
        {
            SetActiveTargetObj(true);
        }
    }

    public void OnPointerExit()
    {
        if (targetObj != null)
        {
            SetActiveTargetObj(false);
        }
    }

    public void SetActiveTargetObj(bool value)
    {
        if (targetObj != null)
        {
            targetObj.SetActive(value);
        }

        StopAllCoroutines();

        if (_canvasGroup == null)
        {
            _canvasGroup = targetObj.AddComponent<CanvasGroup>();
            _canvasGroup.alpha = 0.0f;
        }

        StartCoroutine(value
            ? Utils.FadeIn(_canvasGroup, 1.0f, 0.5f)
            : Utils.FadeOut(_canvasGroup, 0.0f, 0.5f));
    }
}
