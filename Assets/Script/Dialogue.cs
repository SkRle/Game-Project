using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textDialog;
    public string[] lines;
    public float TextSpeed;

    private int index;

    void Start()
    {
        textDialog.text = string.Empty;
        StartDialogue();
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0)) 
        {
            if (textDialog.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textDialog.text = lines[index];
            }
        }
    }

    void StartDialogue()
    {
        index = 0;
        StartCoroutine(Type_Line());
    }

    IEnumerator Type_Line()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textDialog.text += c;
            yield return new WaitForSeconds(TextSpeed);
        }
    }

    void NextLine()
    {
        if (index <= lines.Length - 1) 
        { 
            index++;
            textDialog.text = string.Empty;
            StartCoroutine(Type_Line());
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

}
