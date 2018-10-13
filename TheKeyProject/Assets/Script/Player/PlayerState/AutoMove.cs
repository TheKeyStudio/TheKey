using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMove : PlayerState {

    float directionX;
    float deviation;

    public AutoMove(float directionX, float deviation, PlayerController controller)
        :base(controller)
    {
        this.directionX = directionX;
        this.deviation = deviation;
    }

    public override void AutoMoveToX(float directionX, float deviation)
    {
        this.directionX = directionX;
        this.deviation = deviation;
    }

    public override void Interaction()
    {
        controller.PlayerState = new Talking(controller);
    }

    public override void Move()
    {
        Transform transform = controller.transform;
        PlayerMotor motor = controller.PlayerMotor;
        controller.SetMoveAnimation(true);
        if (transform.position.x > directionX + deviation)
        {
            motor.SetHorizontalDirection(-1);
        }
        else if (transform.position.x < directionX - deviation)
        {
            motor.SetHorizontalDirection(1);
        }
        else
        {
            Interaction();
            controller.SetMoveAnimation(false);
        }


        if (Math.Abs(Input.GetAxis("Horizontal")) > 0.1)
        {
            controller.PlayerState = new Normal(controller);
        }
    }

    public override void ReadBook()
    {
        controller.PlayerState = new Reading(controller);
    }
}
