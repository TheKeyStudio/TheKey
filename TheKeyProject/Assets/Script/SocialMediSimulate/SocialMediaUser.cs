﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SocialMedia/SocialMediaUser")]
public class SocialMediaUser : ScriptableObject
{
    public Sprite profilePic;
    public string userName;
    public string email;
    public string birthday;
    public string icNumber;
    public string job;
    public string phoneNumber;

    [TextArea(3, 10)]
    public string address;

    [TextArea(10, 1000)]
    public string familyDescription;

    [TextArea(10, 1000)]
    public string description;
    
}
