using NUnit.Framework;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;


public class NPCDialogue : MonoBehaviour
{
    public GameObject TestDialogueDisplay;
    private string TestDialogue = "Owie you stepped on my toes!";
    public List<string> DialogueList = new List<string>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        TestDialogueDisplay.SetActive(false);
       // DialogueList.Add("Owie you stepped on my head");
       // DialogueList.Add("Owie you stepped on my hand");
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Hit" + other.name);
        if (other.tag == "Player")
        {
            int score = GameManager.Instance.GetScore();

            TestDialogueDisplay.SetActive(true);
        }
        // TestDialogueDisplay.text = TestDialogue;


    }

    private void OnTriggerExit2D(Collider2D other)  
    {
        if (other.tag == "Player")
        {
            TestDialogueDisplay.SetActive(false);
        }
    }

}
