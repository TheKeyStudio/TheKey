using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameWebController : MonoBehaviour
{
    [SerializeField] private GameUser[] users;

    public GameObject gameUserInformationPrefab;
    private GameObject currentUserInformation;

    public GameWebLogin gameWebLogin;
        
	
	public GameUser GetUserByAccAndPwd(string account, string password)
    {
        GameUser found = null;
        foreach(GameUser user in users)
        {
            if(user.account.Equals(account) && user.password.Equals(password))
            {
                found = user;
            }
        }
        return found;
    }

    public void CreateUserInformation(GameUser user)
    {
        PageToUserInformation();

        GameUserInformation userInformation;
        currentUserInformation = Instantiate(gameUserInformationPrefab, transform);
        userInformation = currentUserInformation.GetComponent<GameUserInformation>();

        userInformation.SetUser(user, this);
    }

    public void PageToUserInformation()
    {
        gameWebLogin.gameObject.SetActive(false);
    }

    public void PageToLogin()
    {
        Destroy(currentUserInformation);
        gameWebLogin.gameObject.SetActive(true);
    }
}
