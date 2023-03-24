using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.Rendering.DebugUI;

public class NpcTrigger : MonoBehaviour
{

    [Header("Ink JSON")]
    [SerializeReference] private TextAsset inkJSON;


    public GameObject  InteractBotton;
    private bool playerTrigger;
    public GameObject Panel;
    private bool bottonClick;

    private int clickCount;


    private void Awake()
    {
        clickCount = 1;
        bottonClick = false;
        playerTrigger = false;
        InteractBotton.SetActive(false);
        Panel.SetActive(false);
    }

    void Update()
    {
        if (playerTrigger && bottonClick)
        {
            Panel.SetActive(true);
        }
        else
        {
            Panel.SetActive(false);
        }
    }

    public void ButonPress()
    {
        if (!bottonClick)
        {
            bottonClick = true;

        }
    }



    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            playerTrigger = true;
            InteractBotton.SetActive(true);
            Debug.Log("Trigger");
        }
        else
        {
            Debug.Log("Dont Know");
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            playerTrigger = false;
            InteractBotton.SetActive(false);
            Debug.Log("non-Trigger");
        }
        else
        {
            Debug.Log("Dont Know");
        }
    }
}
