using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FemaleController : Singleton<FemaleController>
{
    [SerializeField] private SkinnedMeshRenderer blendShapes;

    [SerializeField] private float eye_TimeCheck = 2f;
    [SerializeField] private float eye_currentTime;

    [SerializeField] private float mouth_TimeCheck = 0.5f;
    [SerializeField] private float mouth_currentTime;
    [SerializeField] private int mouthAnimationCount;

    [SerializeField] private bool isPlayMouthAnimation;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        eye_currentTime += Time.deltaTime;
        mouth_currentTime += Time.deltaTime;

        if (gameObject.GetComponentInParent<FemaleController>().name == "Female_coffe_motion" && eye_currentTime > eye_TimeCheck)
        {
            eye_TimeCheck = Random.Range(4f, 6f);
            eye_currentTime = 0;
            PlayFemaleCoffe_EyesAnimation();
            
        }

        if (gameObject.GetComponentInParent<FemaleController>().name == "Female_bank_motion" && eye_currentTime > eye_TimeCheck)
        {
            eye_TimeCheck = Random.Range(4f, 6f);
            eye_currentTime = 0;
            PlayFemaleBank_EyesAnimation();
        }


        if (gameObject.GetComponentInParent<FemaleController>().name == "Female_coffe_motion" && isPlayMouthAnimation && mouth_currentTime > mouth_TimeCheck)
        {
            mouth_currentTime = 0;
            StartCoroutine(FemaleCoffe_MouthAnimation());

        }

        if (gameObject.GetComponentInParent<FemaleController>().name == "Female_bank_motion" && isPlayMouthAnimation && mouth_currentTime > mouth_TimeCheck)
        {
            mouth_currentTime = 0;
            StartCoroutine(FemaleBank_MouthAnimation());
        }
    }

    //public void Smile() {

    //    int value = Random.Range(0,2);

    //    if (blendShapes != null) {
    //        blendShapes.SetBlendShapeWeight(0, value * 100);
    //    }
    //}


    #region FemaleCoffe

    IEnumerator FemaleCoffe_EyesAnimation()
    {
        if (blendShapes != null)
        {
            blendShapes.SetBlendShapeWeight(1, 0);

            yield return new WaitForSeconds(0.2f);

            blendShapes.SetBlendShapeWeight(1, 100);

            yield return new WaitForSeconds(0.2f);

            blendShapes.SetBlendShapeWeight(1, 0);
        }
    }

    public void PlayFemaleCoffe_EyesAnimation()
    {
        StartCoroutine(FemaleCoffe_EyesAnimation());
    }

    IEnumerator FemaleCoffe_MouthAnimation()
    {
        if (blendShapes != null)
        {
            mouthAnimationCount++;

            blendShapes.SetBlendShapeWeight(2, 0);

            yield return new WaitForSeconds(0.2f);

            blendShapes.SetBlendShapeWeight(2, 40);

            yield return new WaitForSeconds(0.2f);

            blendShapes.SetBlendShapeWeight(2, 0);

            if (mouthAnimationCount >= 3)
            {
                isPlayMouthAnimation = false;
                mouthAnimationCount = 0;
            }

        }
    }


    #endregion

    public void PlayFemale_MouthAnimation()
    {
        isPlayMouthAnimation = true;
    }


    #region FemaleBank

    IEnumerator FemaleBank_EyesAnimation()
    {
        if (blendShapes != null)
        {
            blendShapes.SetBlendShapeWeight(0, 0);

            yield return new WaitForSeconds(0.2f);

            blendShapes.SetBlendShapeWeight(0, 100);

            yield return new WaitForSeconds(0.2f);

            blendShapes.SetBlendShapeWeight(0, 0);
        }
    }

    public void PlayFemaleBank_EyesAnimation()
    {
        StartCoroutine(FemaleBank_EyesAnimation());
    }

    IEnumerator FemaleBank_MouthAnimation()
    {
        if (blendShapes != null)
        {
            mouthAnimationCount++;

            blendShapes.SetBlendShapeWeight(1, 0);

            yield return new WaitForSeconds(0.2f);

            blendShapes.SetBlendShapeWeight(1, 40);

            yield return new WaitForSeconds(0.2f);

            blendShapes.SetBlendShapeWeight(1, 0);

            if (mouthAnimationCount >= 3)
            {
                isPlayMouthAnimation = false;
                mouthAnimationCount = 0;
            }
        }
    }

    

    #endregion
}
