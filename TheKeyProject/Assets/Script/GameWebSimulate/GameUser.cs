using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game/GameUser")]
public class GameUser : ScriptableObject
{
    public string account;
    public string password;
    public string fullName;
    public string email;
    public string birthday;
    public string icNumber;
    public string country;
    public string point;
}
