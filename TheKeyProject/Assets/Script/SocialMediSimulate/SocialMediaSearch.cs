using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SocialMediaSearch : MonoBehaviour {
    public TMP_InputField searchInputField;
    public SocialMediaController controller;

	public void SearchUser()
    {
        string email = searchInputField.text.Trim();
        SocialMediaUser user = controller.GetUserByEmail(email);
        if(user != null)
        {
            controller.CreateUserProfile(user);
        }
        else
        {
            Debug.Log("email not found");
        }
    }
}
