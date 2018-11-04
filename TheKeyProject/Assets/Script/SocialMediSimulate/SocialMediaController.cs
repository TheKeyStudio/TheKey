using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SocialMediaController : MonoBehaviour {
    [SerializeField]private SocialMediaUser[] users;

    public GameObject userProfilePrefab;
    private GameObject currentUserProfile;

    public SocialMediaSearch socialSearch;
    
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

    public void CreateUserProfile(SocialMediaUser user)
    {
        PageToProfile();

        SocialMediaUserProfile userInformation;
        currentUserProfile = Instantiate(userProfilePrefab, transform);
        userInformation = currentUserProfile.GetComponent<SocialMediaUserProfile>();

        userInformation.SetUser(user, this);
    }

    public void PageToProfile()
    {
        socialSearch.Clear();
        socialSearch.gameObject.SetActive(false);
    }

    public void PageToSearch()
    {
        Destroy(currentUserProfile);
        socialSearch.gameObject.SetActive(true);
    }
}
