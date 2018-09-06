using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Code Smell, please clean it.
 */

public interface Interactable {
    
    void Interact();

    void OnFocused(Transform playerTransform);

    void OnDefoucused();
    
}
