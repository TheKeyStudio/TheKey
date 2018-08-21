using UnityEngine;
using EaseTools;
using System.Collections;

public class UIManager : MonoBehaviour
{
	public EaseUI easeUIComponent;
	
	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Q))
			easeUIComponent.MoveIn();
		else if (Input.GetKeyDown(KeyCode.W))
			easeUIComponent.MoveOut();

		if (Input.GetKeyDown(KeyCode.A))
			easeUIComponent.RotateIn();
		else if (Input.GetKeyDown(KeyCode.S))
			easeUIComponent.RotateOut();

		if (Input.GetKeyDown(KeyCode.Z))
			easeUIComponent.ScaleIn();
		else if (Input.GetKeyDown(KeyCode.X))
			easeUIComponent.ScaleOut();
	}
}
