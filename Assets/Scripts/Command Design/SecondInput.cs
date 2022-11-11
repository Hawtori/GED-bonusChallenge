using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondInput : ICommand
{
    GameObject player;
    
    public SecondInput(GameObject p)
    {
        player = p;
    }

    public override void Execute()
    {
        player.GetComponent<PlayerMovement>().movement = Input.GetAxisRaw("Horizontal") * -1;
    }
}
