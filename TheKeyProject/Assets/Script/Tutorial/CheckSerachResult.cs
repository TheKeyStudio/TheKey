using UnityEngine;

public class CheckSerachResult : MonoBehaviour {
    public bool done = false;

    // Update is called once per frame
    void Update()
    {
        if (transform.Find("UserProfile(Clone)") != null && !done)
        {
            SocialMediaUserProfile userProfile = transform.Find("UserProfile(Clone)").GetComponent<SocialMediaUserProfile>();
            if (userProfile.emailText.text.Equals("ben19790421@gmail.com"))
            {
                EventDataSetter setter = GetComponent<EventDataSetter>();
                setter.SetData();
                done = true;
            }
        }
    }
}
