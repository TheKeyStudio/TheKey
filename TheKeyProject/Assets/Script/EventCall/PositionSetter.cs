using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionSetter : MonoBehaviour {
    public Transform player;
    public Transform defaultPoint;
    public Transform[] points;
    private Dictionary<string, Vector3> position = new Dictionary<string, Vector3>();
    private GameManager gameManager;
	// Use this for initialization
	void Start () {
        gameManager = GameManager.instance;

        foreach (Transform point in points)
        {
            position.Add(point.name, point.position);
        }
        SetPlayStartPosition(gameManager.CurrentSceneName);
        gameManager.RefreshSceneName();
    }
	
	public void SetPlayStartPosition(string name)
    {
        name = name[0].ToString();
        if (position.ContainsKey(name))
        {
            player.transform.position = position[name];
        }
        else
        {
            player.transform.position = defaultPoint.position;
        }
        
    }
}
