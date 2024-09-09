using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerControl : Mover
{

    void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        GroundCheck();

        ApplyGravity();

        GetMoveInput();
        MoveObj(moveDirection);

        //Debug.DrawRay(transform.position, Vector3.down * (controller.height * 0.5f + 0.005f), Color.red);
        Jump();
    }
}
