using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerState {
    protected PlayerController controller;

    protected PlayerState(PlayerController controller)
    {
        this.controller = controller;
    }

    public abstract void AutoMoveToX(float directionX, float deviation);
    public abstract void Move();
    public abstract void ReadBook();
    public abstract void Interaction();
    
}
