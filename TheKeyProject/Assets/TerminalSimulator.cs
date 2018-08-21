using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TerminalSimulator : MonoBehaviour {

    private TMP_Text m_TextComponent;
    private TextLinkScript m_TextLinkScript;
    private bool hasTextChanged;

    [Range(0.01f, 2f)]
    public float perCharacterSec = 0.025f;

    void Awake()
    {
        m_TextComponent = gameObject.GetComponent<TMP_Text>();
        m_TextLinkScript = gameObject.GetComponent<TextLinkScript>();
        m_TextLinkScript.enabled = false;
    }


    void Start()
    {
        StartCoroutine(RevealCharacters(m_TextComponent));
    }


    void OnEnable()
    {
        // Subscribe to event fired when text object has been regenerated.
        TMPro_EventManager.TEXT_CHANGED_EVENT.Add(ON_TEXT_CHANGED);
    }

    void OnDisable()
    {
        TMPro_EventManager.TEXT_CHANGED_EVENT.Remove(ON_TEXT_CHANGED);
    }


    // Event received when the text object has changed.
    void ON_TEXT_CHANGED(Object obj)
    {
        hasTextChanged = true;
    }


    /// <summary>
    /// Method revealing the text one character at a time.
    /// </summary>
    /// <returns></returns>
    IEnumerator RevealCharacters(TMP_Text textComponent)
    {
        textComponent.ForceMeshUpdate();

        TMP_TextInfo textInfo = textComponent.textInfo;

        int totalVisibleCharacters = textInfo.characterCount; // Get # of Visible Character in text object
        int visibleCount = 0;

        while (true)
        {
            if (hasTextChanged)
            {
                totalVisibleCharacters = textInfo.characterCount; // Update visible character count.
                hasTextChanged = false;
            }

            if (visibleCount > totalVisibleCharacters)
            {
                yield return new WaitForSeconds(1.0f);
                m_TextLinkScript.enabled = true;
            }

            textComponent.maxVisibleCharacters = visibleCount; // How many characters should TextMeshPro display?

            visibleCount += 1;

            yield return new WaitForSeconds(perCharacterSec);
        }
    }
}
