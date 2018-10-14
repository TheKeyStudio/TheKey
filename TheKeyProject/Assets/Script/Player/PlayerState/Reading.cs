using System;
using System.Collections;
using Fungus;
using UnityEngine;

public class Reading : PlayerState
{
    PlayerMotor motor;

    public Reading(PlayerController controller) : base(controller)
    {
        //slow down speed
        motor = controller.PlayerMotor;
        motor.runSpeed -= 20;
    }

    public override void AutoMoveToX(float directionX, float deviation)
    {
        return;
    }

    public override IEnumerator Interact(Flowchart flowChart)
    {
        yield return null;
        controller.PlayerState = new Talking(controller);
        controller.Interact(flowChart);
    }

    public override void Move()
    {
        motor = controller.PlayerMotor;
        float horizonatal = Input.GetAxis("Horizontal");
        motor.SetHorizontalDirection(horizonatal);
        if (Math.Abs(horizonatal) < 0.1)
        {
            controller.SetMoveAnimation(false);
        }
        else
        {
            controller.SetMoveAnimation(true);
        }
    }

    public override void ReadBook()
    {
        //ReadBook() had been called when the player is reading, means close the book
        motor.runSpeed += 20;
        controller.PlayerState = new Normal(controller);
    }
}
