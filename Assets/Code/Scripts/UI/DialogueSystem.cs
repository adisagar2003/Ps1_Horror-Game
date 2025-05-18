using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// Handles the display of in-game dialogue messages triggered by interactable objects.
/// </summary>
public class DialogueSystem : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI messageUI;
    [SerializeField] private string message;
    public delegate void SendMessage(string message);
    public static event SendMessage OnSendMessage;

    private bool isShowingDialogue = false;

    private void OnEnable()
    {
        OnSendMessage += HandleMessage;
    }

    private void OnDisable()
    {
        OnSendMessage -= HandleMessage;
    }

    private void HandleMessage(string message)
    {
        if (isShowingDialogue) return; 
        StartCoroutine(ShowDialogue(message));
    }

    private IEnumerator ShowDialogue(string message)
    {
        isShowingDialogue = true;
        Debug.Log("Message");
        messageUI.text = message;
        yield return new WaitForSeconds(3.0f);
        messageUI.text = "";
        isShowingDialogue = false;
    } 

    public static void Trigger(string message)
    {
        OnSendMessage?.Invoke(message);
    }
}
