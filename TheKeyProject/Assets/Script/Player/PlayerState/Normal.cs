using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Normal : PlayerState
{
    public Normal(PlayerController controller) : base(controller)
    {
    }

    public override void AutoMoveToX(float directionX, float deviation)
    {
        throw new System.NotImplementedException();
    }

    public override void Interaction()
    {
        throw new System.NotImplementedException();
    }

    public override void Move()
    {
        PlayerMotor motor = controller.PlayerMotor;
        motor.SetHorizontalDirection(Input.GetAxis("Horizontal"));
        controller.SetMoveAnimation(true);
    }

    public override void ReadBook()
    {
        throw new System.NotImplementedException();
    }
}
