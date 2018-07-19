using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalDoor : Door {
    
    private void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            if (active)
            {
                toNextScene();
            }
        }
    }
}
