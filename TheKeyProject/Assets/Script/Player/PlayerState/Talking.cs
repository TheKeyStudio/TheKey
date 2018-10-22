using Fungus;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Talking : PlayerState
{
    public bool talking = false;

    public Talking(PlayerController controller) : base(controller)
    {
    }

    public override void AutoMoveToX(float directionX, float deviation)
    {
        return;
    }

    public override void Move()
    {
        controller.SetMoveAnimation(false);
    }

    public override void ReadBook()
    {
        return;
    }

    public override IEnumerator Interact(Flowchart flowChart)
    {
        controller.InteractTheFocusing();
        bool flowChartTalking = flowChart.GetBooleanVariable("Talking");
        talking = true;
        while (talking || flowChartTalking)
        {
            flowChartTalking = flowChart.GetBooleanVariable("Talking");

            if (flowChartTalking && talking)
                talking = false;

            if (flowChart == null)
            {
                controller.PlayerState = new Normal(controller);
                break;
            }
            yield return null;
        }
        Debug.Log("Done talk");
        controller.RemoveFocus();
        controller.PlayerState = new Normal(controller);
    }

    public override void Enter()
    {
        return;
    }
}
