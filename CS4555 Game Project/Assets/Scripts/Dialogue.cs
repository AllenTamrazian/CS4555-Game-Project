using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI : MonoBehaviour
{
    public TMP_Text dialogue;
    public Button dismissButton;
    public float characterInterval;

    private int currentChar = 0;
    private int queueNumber = 0;
    private string currentText = "";
    private string[] queuedText;

    private float timer = 0.0f;
    private bool inDialogue = false;

    void Start()
    {
        dialogue.gameObject.SetActive(false);
        dismissButton.gameObject.SetActive(false);
        dismissButton.onClick.AddListener(OnDismiss);
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (dialogue.text != currentText && timer > characterInterval)
        {
            dialogue.text = currentText.Substring(0, currentChar);
            currentChar++;
            timer = 0.0f;
        }
        else if (inDialogue && dismissButton.gameObject.activeSelf == false && dialogue.text == currentText)
        {
            currentChar = 0;
            dismissButton.gameObject.SetActive(true);
        }
    }


    public void NewDialogue(string[] text)
    {
        if (inDialogue)
        {
            Debug.Log("Attempted to start a new dialogue while one's currently running!");
            return;
        }

        queuedText = text;
        SetTextHelper();
    }

    void SetTextHelper()
    {
        inDialogue = true;
        dialogue.text = "";
        dialogue.gameObject.SetActive(true);
        currentText = queuedText[queueNumber];
        queueNumber++;
    }

    void OnDismiss()
    {
        if (queuedText.Length > 1 && queuedText.Length > queueNumber)
        {
            Debug.Log("Continuing dialogue");
            dismissButton.gameObject.SetActive(false);
            SetTextHelper();
            return;
        }
        queueNumber = 0;
        inDialogue = false;
        dialogue.gameObject.SetActive(false);
        dismissButton.gameObject.SetActive(false);
        Debug.Log("Finished dialogue");
    }

    public bool InDialogue()
    {
        return inDialogue;
    }
}
