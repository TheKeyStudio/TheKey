using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameUserInformation : MonoBehaviour
{
    public TMP_Text accountText;
    public TMP_Text fullNameText;
    public TMP_Text emailText;
    public TMP_Text birthdayText;
    public TMP_Text idNumberText;
    public TMP_Text countryText;
    public TMP_Text pointText;

    private GameWebController controller;

    public void SetUser(GameUser user, GameWebController controller)
    {
        this.controller = controller;
        accountText.text = user.account;
        fullNameText.text = user.fullName;
        emailText.text = user.email;
        birthdayText.text = user.birthday;
        idNumberText.text = user.icNumber;
        countryText.text = user.country;
        pointText.text = user.point;
    }
    
    public void BackToLogin()
    {
        controller.PageToLogin();
    }
}
