using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SocialMediaUserProfile : MonoBehaviour {
    public Image profilePicture;
    public TMP_Text nameText;
    public TMP_Text emailText;
    public TMP_Text icNumberText;
    public TMP_Text jobText;
    public TMP_Text addressText;
    public TMP_Text familyText;
    public TMP_Text birthdayText;
    public TMP_Text phoneText;
    public TMP_Text descriptionText;

    private SocialMediaController controller;

    public void SetUser(SocialMediaUser user, SocialMediaController controller)
    {
        this.controller = controller;
        profilePicture.sprite = user.profilePic;
        nameText.text = user.userName;
        emailText.text = user.email;
        icNumberText.text = user.icNumber;
        jobText.text = user.job;
        addressText.text = user.address;
        familyText.text = user.familyDescription;
        birthdayText.text = user.birthday;
        phoneText.text = user.phoneNumber;
        descriptionText.text = user.description;
    }

    public void BackToSearch()
    {
        controller.PageToSearch();
    }
	
}
