using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NpcControl : MonoBehaviour
{
    public string name, Dialog, interactText;
    private bool isPlayerInRange = false, isPressed = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isPlayerInRange && !(DIalogControl.InDialog || StartGame.InGame) && !isPressed)
            {
                Dialogues Npc = GetComponent<Dialogues>();
                Npc.SetTree(Dialog);
                DIalogControl.StartDialog(name, Npc, true);
                isPressed = true;
            }
            isPressed = DIalogControl.InDialog;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Player")
        {
            isPlayerInRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            isPlayerInRange = false;
        }
    }
}
