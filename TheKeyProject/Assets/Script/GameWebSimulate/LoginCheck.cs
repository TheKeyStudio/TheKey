using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoginCheck : MonoBehaviour {
    [SerializeField] private string account;
    [SerializeField] private string password;
    public TMP_InputField acc_inputField;
    public TMP_InputField pwd_inputField;
    public GameObject BenGameInformation;
	
    public void Login()
    {
        if (account.Equals(acc_inputField.text) && password.Equals(pwd_inputField.text))
        {
            BenGameInformation.SetActive(true);
            GameManager.instance.benGameLoggedIn = true;
            Destroy(gameObject);
        }
    }
}
