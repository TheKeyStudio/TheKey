using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameUserInformation : MonoBehaviour
{
    public TMP_Text fullNameText;
    public TMP_Text emailText;

    private GameWebController controller;

    public void SetUser(GameUser user, GameWebController controller)
    {
        this.controller = controller;
        fullNameText.text += user.fullName;
        emailText.text += user.email;
    }


    public void BackToLogin()
    {
        controller.PageToLogin();
    }
}
