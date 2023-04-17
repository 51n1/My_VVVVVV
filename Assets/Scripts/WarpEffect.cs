using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class WarpEffect : MonoBehaviour
{
    [SerializeField] Material material;
    [SerializeField] AnimationCurve animCurve;

    public float animationTime = 4.0f;
    bool isPlaying = false;
    float process = 0;

    void Start()
    {
        Initialize();

        isPlaying = true;
        StartCoroutine(PlayAnimation());
    }

    void Initialize()
    {
        isPlaying = false;
        process = 0;

        material.SetFloat("_Fader", 0);
        material.SetFloat("_Effect", 1);
    }

    IEnumerator PlayAnimation()
    {
        while (isPlaying && process < 1)
        {
            process += Time.deltaTime / animationTime;
            SetProcess();
            yield return null;
        }

        //Initialize();
        isPlaying = false;
        
    }

    private void SetProcess()
    {
        float p = process * animationTime;
        //float value = 0;

        if (p < animationTime / 2)
        {
            material.SetFloat("_Fader", animCurve.Evaluate(process * 2));
        }
        else
        {
            material.SetFloat("_Fader", 1f);
            material.SetFloat("_Effect", animCurve.Evaluate(1-process));
        }

        



        /*if (p < animationTime / 4)
        {
            value = p * 4 / animationTime;
            material.SetFloat("_Effect", value);
        }
        else if (p < animationTime / 4 * 2)
        {
            value = (p - animationTime / 4) * 4 / animationTime;
            material.SetFloat("_Fade", animCurve.Evaluate(1 - value));
        }
        else if (p < animationTime / 4 * 3)
        {
            value = (p - animationTime / 4 * 2) * 4 / animationTime;
            material.SetFloat("_Fade", animCurve.Evaluate(value));
        }
        else
        {
            value = (p - animationTime / 4 * 3) * 4 / animationTime;
            material.SetFloat("_Effect", 1 - value);
        }*/

    }
}
