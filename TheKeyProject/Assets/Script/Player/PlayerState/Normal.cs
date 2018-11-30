using System;
using System.Collections;
using Fungus;
using UnityEngine;

public class Normal : PlayerState
{
    public Normal(PlayerController controller) : base(controller)
    {
    }

    public override void AutoMoveToX(float directionX, float deviation)
    {
        controller.PlayerState = new AutoMove(directionX, deviation, controller);
    }

    public override void Enter()
    {
        controller.PlayerState = new Entering(controller);
        controller.Enter();
    }

    public override IEnumerator Interact(Flowchart flowChart)
    {
        yield return null;
        controller.PlayerState = new Talking(controller);
        controller.Interact(flowChart);
    }
    

    public override void Move()
    {
        PlayerMotor motor = controller.PlayerMotor;
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

    public override bool ReadBook()
    {
        controller.PlayerState = new Reading(controller);
        return true;
    }
    public override void Jump()
    {
        PlayerMotor motor = controller.PlayerMotor;
        motor.Jump();
    }
}
