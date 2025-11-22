using System;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using Yarn.Unity;
using EasyTransition;

public class LibraryScript : MonoBehaviour
{

    [SerializeField] private CameraControl _cameraControl;
    [SerializeField] private GameObject ImageLeft, ImageRight;
    [SerializeField] private GameObject DialogueText;

    [SerializeField] private DialogueRunner dialogueRunner;
    [SerializeField] private AudioSource audioSource; // assign AudioSource in inspector
    [SerializeField] private AudioClip johanClickSound; // assign sound effect clip in inspector

    [SerializeField] private GameObject exclamationIcon; // assign the exclamation mark icon here



    bool isLookingLeft = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _cameraControl = new CameraControl();

         // ensure icon starts invisible
        if (exclamationIcon != null)
        {
            var img = exclamationIcon.GetComponent<Image>();
            if (img != null)
            {
                Color c = img.color;
                c.a = 0f;
                img.color = c;
            }
        }
    }

    public void OnLookLeft()
    {
        
        if (!isLookingLeft)
        {
            ImageLeft.GetComponent<RectTransform>().DOAnchorPosX(0, 1f, true);
            ImageRight.GetComponent<RectTransform>().DOAnchorPosX(1920f, 1f, true);
            isLookingLeft = true;
        }

    }
    public void OnLookRight()
    {
        if (isLookingLeft)
        {
            ImageLeft.GetComponent<RectTransform>().DOAnchorPosX(-1920f, 1f, true);
            ImageRight.GetComponent<RectTransform>().DOAnchorPosX(0, 1f, true);
            isLookingLeft = false;
        }
    }

    public void ActivateNode(string nodeName)
    {

        var img = exclamationIcon.GetComponent<Image>();


        if (dialogueRunner == null)
        {

            Debug.LogError("DialogueRunner not assigned!");
        }
        else if (nodeName == "JohanClicked")
        {

            img.DOFade(1f, 0.2f)
            .OnComplete(() =>
            {
                img.DOFade(0f, 0.2f).SetDelay(0.6f);
            });

            // play sound effect
            if (audioSource != null && johanClickSound != null)
            {
                audioSource.PlayOneShot(johanClickSound);
            }
            else
            {
                Debug.LogWarning("AudioSource or johanClickSound not assigned!");
            }

            dialogueRunner.StartDialogue("JohanClicked");
            //        TransitionManager.Instance().Transition(_sceneName, transition, startDelay);
        }

        else
        {
            dialogueRunner.StartDialogue(nodeName);
        }
    }
    

    
    void Update()
    {
        
    }
}
