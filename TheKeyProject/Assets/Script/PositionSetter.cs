using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionSetter : MonoBehaviour {
    public Transform player;
    public Transform[] points;
    private Dictionary<string, Vector3> position = new Dictionary<string, Vector3>();
	// Use this for initialization
	void Awake () {
		foreach(Transform point in points)
        {
            position.Add(point.name, point.position);
        }
        SetPlayStartPosition(GameManager.instance.main1PositionPointName);
	}
	
	public void SetPlayStartPosition(string name)
    {
        player.transform.position = position[name];
    }
}
