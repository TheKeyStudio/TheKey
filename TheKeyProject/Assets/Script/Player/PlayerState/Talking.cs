using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Talking : PlayerState
{
    public Talking(PlayerController controller) : base(controller)
    {
    }

    public override void AutoMoveToX(float directionX, float deviation)
    {
        return;
    }

    public override void Interaction()
    {
        controller.PlayerState = new Normal(controller);
    }

    public override void Move()
    {
        return;
    }

    public override void ReadBook()
    {
        return;
    }
}
