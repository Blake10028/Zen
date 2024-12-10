using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkInteract : Interactable
{
    public override void Interact(Character character)
    {
        Debug.Log("Am I talking to a loser?");
    }
}
