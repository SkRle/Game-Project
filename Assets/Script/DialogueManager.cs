using Ink.Parsed;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Ink.Runtime;

public class DialogueManager : MonoBehaviour
{

    [Header("Dialogue UI")]
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TextMeshProUGUI dialogueText;

    private Ink.Runtime.Story currenStory;

    private bool dialogueIsPlaying;

    private static DialogueManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            Debug.LogWarning("Found more than one");

        }
        instance = this;
    }

    public static DialogueManager GetInstance()
    {
        return instance;
    }

    private void Start()
    {
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
    }

    private void Update()
    {
        if (dialogueIsPlaying)
        {
            return;
        }

    }

    public void EnterDialogueMode(TextAsset inkJSON)
    {
        currenStory = new Ink.Runtime.Story(inkJSON.text);
        dialogueIsPlaying = true;
        dialoguePanel.SetActive(true);

        ContinueStory();

    }
    private void ExitDiaLougeMode()
    {
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        dialogueText.text = "";
    }

    private void ContinueStory()
    {
        if (currenStory.canContinue)
        {
            dialogueText.text = currenStory.Continue();
        }
        else
        {
            ExitDiaLougeMode();
        }
    }
}
