using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class Interact : MonoBehaviour
{
    [SerializeField]
    private GameObject InteractButton;

    public GameObject Panel;
    public TextMeshProUGUI dialogueText;
    public bool Istrigger;
    //public UnityEvent Interaction;

    void Start()
    {
        InteractButton.gameObject.SetActive(false);
        Panel.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && Istrigger)
        {
            Panel.gameObject.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            InteractButton.gameObject.SetActive(true);
            Istrigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            InteractButton.gameObject.SetActive(false);
            Istrigger = false;
        }
    }
}
