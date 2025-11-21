using UnityEngine;
using UnityEngine.Rendering;
using Yarn.Unity;
using DG.Tweening;
using System;

public class FrameManager : MonoBehaviour
{
    [SerializeField] private GameObject FrameGameObject;
    [SerializeField] private Material maskMaterial;

    [YarnCommand("ShrinkFrame")]
    public void FrameScaletoSmall(float x, float y, float z, float duration)
    {
        
        Vector3 targetScale = new Vector3(x, y, z);
        FrameGameObject.transform.DOScale(targetScale, duration).SetEase(Ease.OutQuad);

    }

    [YarnCommand("FadeFrame")]
    public void FrameFading(float boxvalue, float alphavalue, float duration)
    {   
        String boxName;

        Debug.Log("Fading Box " + boxvalue + " to alpha " + alphavalue + " over " + duration + " seconds.");

        if (boxvalue == 1)
        {
            
            boxName = "_Box1Alpha";
        }
        else if (boxvalue == 2)
        {
            boxName = "_Box2Alpha";
        }
        else if (boxvalue == 3)
        {
            boxName = "_Box3Alpha";
        }
        else if (boxvalue == 4)
        {
            boxName = "_Box4Alpha";
        }
        else
        {
            Debug.LogError("Invalid box value: " + boxvalue);
            return;
        }
        
        DOTween.To(
            () => maskMaterial.GetFloat(boxName),
            a => maskMaterial.SetFloat(boxName, a),
            alphavalue, // target alpha (transparent)
            duration  // duration
        ).SetEase(Ease.InOutSine);

    }
    
    [YarnCommand("FadeWholeFrame")]
    public void FrameHide(float alphavalue, float duration)
    {
        if (maskMaterial == null)
        {
            Debug.LogWarning("FrameHide: maskMaterial not assigned.");
            return;
        }

        alphavalue = Mathf.Clamp01(alphavalue);

        DOTween.To(
            () => maskMaterial.color.a,
            a =>
            {
                Color c = maskMaterial.color;
                c.a = a;
                maskMaterial.color = c;
            },
            alphavalue,
            duration
        ).SetEase(Ease.InOutSine);
    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (maskMaterial != null)
        {
            Color c = maskMaterial.color;
            c.a = 1f;
            maskMaterial.color = c;
        }

        // Fade in Box 1 (make it transparent hole appear)
        DOTween.To(
            () => maskMaterial.GetFloat("_Box1Alpha"),
            a => maskMaterial.SetFloat("_Box1Alpha", a),
            1f, // target alpha (transparent)
            0.01f  // duration
        ).SetEase(Ease.InOutSine);

        DOTween.To(
            () => maskMaterial.GetFloat("_Box2Alpha"),
            a => maskMaterial.SetFloat("_Box2Alpha", a),
            1f, // target alpha (transparent)
            0.01f  // duration
        ).SetEase(Ease.InOutSine);

        DOTween.To(
            () => maskMaterial.GetFloat("_Box3Alpha"),
            a => maskMaterial.SetFloat("_Box3Alpha", a),
            1f, // target alpha (transparent)
            0.01f  // duration
        ).SetEase(Ease.InOutSine);

        DOTween.To(
            () => maskMaterial.GetFloat("_Box4Alpha"),
            a => maskMaterial.SetFloat("_Box4Alpha", a),
            1f, // target alpha (transparent)
            0.01f  // duration
        ).SetEase(Ease.InOutSine);

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
