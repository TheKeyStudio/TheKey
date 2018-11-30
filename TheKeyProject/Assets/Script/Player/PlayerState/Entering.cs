using System.Collections;
using System.Collections.Generic;
using Fungus;
using UnityEngine;

public class Entering : PlayerState
{
    public Entering(PlayerController controller) : base(controller)
    {
    }

    public override void AutoMoveToX(float directionX, float deviation)
    {
        return;
    }

    public override void Enter()
    {
        controller.InteractTheFocusing();
    }

    public override IEnumerator Interact(Flowchart flowChart)
    {
        yield return null;
    }

    public override void Move()
    {
        controller.SetMoveAnimation(false);
    }

    public override bool ReadBook()
    {
        return false;
    }
    public override void Jump()
    {
        return;
    }
}
