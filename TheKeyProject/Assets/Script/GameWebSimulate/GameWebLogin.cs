using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameWebLogin : MonoBehaviour {

    public TMP_InputField acc_inputField;
    public TMP_InputField pwd_inputField;

    private GameWebController controller;

    private void Start()
    {
        controller = transform.parent.GetComponent<GameWebController>();
    }

    public void Login()
    {
        GameUser user = controller.GetUserByAccAndPwd(acc_inputField.text, pwd_inputField.text);
        if (user != null)
        {
            controller.CreateUserInformation(user);
        }
        else
        {
            Debug.Log("Fail to login");
        }
    }

    public void Clear()
    {
        acc_inputField.text = "";
        pwd_inputField.text = "";
    }
}
