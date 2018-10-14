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
        return;
    }

    public override void Move()
    {
        float horizonatal = Input.GetAxis("Horizontal");
        if (Math.Abs(horizonatal) > 0.1)
        {
            controller.PlayerState = new Normal(controller);
        }

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
            controller.SetMoveAnimation(false);
            controller.PlayerState = new Talking(controller);
            controller.Interact();
        }
        
    }

    public override void ReadBook()
    {
        controller.PlayerState = new Reading(controller);
    }
}
