using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrimaryInput : ICommand
{
    GameObject player;

    public PrimaryInput(GameObject p)
    {
        player = p;
    }


    public override void Execute()
    {
        player.GetComponent<PlayerMovement>().movement = Input.GetAxisRaw("Horizontal");
    }
}
