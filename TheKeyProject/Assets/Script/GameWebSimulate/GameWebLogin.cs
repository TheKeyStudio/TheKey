using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameWebLogin : MonoBehaviour {

    public TMP_InputField acc_inputField;
    public TMP_InputField pwd_inputField;
    public TMP_Text errorText;

    private GameWebController controller;

    private void Start()
    {
        controller = transform.parent.GetComponent<GameWebController>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Submit"))
        {
            Login();
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (acc_inputField.isFocused)
            {
                pwd_inputField.ActivateInputField();
            }
            else
            {
                acc_inputField.ActivateInputField();
            }
        }
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
            errorText.text = "Account or Password Incorrect";
            Debug.Log("Fail to login");
        }
    }

    public void Clear()
    {
        acc_inputField.text = "";
        pwd_inputField.text = "";
        errorText.text = "";
    }
}
