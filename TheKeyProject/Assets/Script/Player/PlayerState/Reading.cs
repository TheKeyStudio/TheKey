using System;
using System.Collections;
using Fungus;
using UnityEngine;

public class Reading : PlayerState
{
    PlayerMotor motor;

    public Reading(PlayerController controller) : base(controller)
    {
        return;
    }

    public override void AutoMoveToX(float directionX, float deviation)
    {
        return;
    }

    public override void Enter()
    {
        return;
    }

    public override IEnumerator Interact(Flowchart flowChart)
    {
        yield return null;
    }

    public override void Jump()
    {
        return;
    }

    public override void Move()
    {
        controller.SetMoveAnimation(false);
    }

    public override void ReadBook()
    {
        //ReadBook() had been called when the player is reading, means close the book
        controller.PlayerState = new Normal(controller);
    }
}
