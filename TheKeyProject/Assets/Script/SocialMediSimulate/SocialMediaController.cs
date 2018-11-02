using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SocialMediaController : MonoBehaviour {
    public SocialMediaUser[] users;
    
    public SocialMediaUser GetUserByEmail(string email)
    {
        SocialMediaUser foundUser = null;
        foreach(SocialMediaUser user in users)
        {
            if (user.email.Equals(email))
            {
                foundUser = user;
            }
        }
        return foundUser;
    }
}
