using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class TextLinkScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public RectTransform TextPopup_Prefab;
    public AnswerGroup answerGroup;

    private RectTransform m_TextPopup_RectTransform;
    private TextMeshProUGUI m_TextPopup_TMPComponent;
    private const string k_LinkText = "Click to solve this question";


    private TextMeshProUGUI m_TextMeshPro;
    private Canvas m_Canvas;
    private Camera m_Camera;

    // Flags
    private bool isHoveringObject;
    private int m_selectedLink = -1;
    private int m_lastIndex = -1;

    private Matrix4x4 m_matrix;

    private TMP_MeshInfo[] m_cachedMeshInfoVertexData;

    void Awake()
    {
        m_TextMeshPro = gameObject.GetComponent<TextMeshProUGUI>();


        m_Canvas = gameObject.GetComponentInParent<Canvas>();

        // Get a reference to the camera if Canvas Render Mode is not ScreenSpace Overlay.
        if (m_Canvas.renderMode == RenderMode.ScreenSpaceOverlay)
            m_Camera = null;
        else
            m_Camera = m_Canvas.worldCamera;

        // Create pop-up text object which is used to show the link information.
        m_TextPopup_RectTransform = Instantiate(TextPopup_Prefab) as RectTransform;
        m_TextPopup_RectTransform.SetParent(m_Canvas.transform, false);
        m_TextPopup_TMPComponent = m_TextPopup_RectTransform.GetComponentInChildren<TextMeshProUGUI>();
        m_TextPopup_RectTransform.gameObject.SetActive(false);
    }

    void LateUpdate()
    {
        if (isHoveringObject)
        {
            #region Example of Link Handling
            // Check if mouse intersects with any links.
            int linkIndex = TMP_TextUtilities.FindIntersectingLink(m_TextMeshPro, Input.mousePosition, m_Camera);

            // Clear previous link selection if one existed.
            if ((linkIndex == -1 && m_selectedLink != -1) || linkIndex != m_selectedLink)
            {
                m_TextPopup_RectTransform.gameObject.SetActive(false);
                m_selectedLink = -1;
            }

            // Handle new Link selection.
            if (linkIndex != -1 && linkIndex != m_selectedLink)
            {
                m_selectedLink = linkIndex;

                // Debug.Log("Link ID: \"" + linkInfo.GetLinkID() + "\"   Link Text: \"" + linkInfo.GetLinkText() + "\""); // Example of how to retrieve the Link ID and Link Text.

                Vector3 worldPointInRectangle = Vector3.zero;
                RectTransformUtility.ScreenPointToWorldPointInRectangle(m_TextMeshPro.rectTransform, Input.mousePosition, m_Camera, out worldPointInRectangle);

                m_TextPopup_RectTransform.position = worldPointInRectangle;
                m_TextPopup_RectTransform.gameObject.SetActive(true);
                m_TextPopup_TMPComponent.text = k_LinkText;
            }
            #endregion
        }
        else
        {
            // Restore any character that may have been modified
            if (m_lastIndex != -1)
            {
                RestoreCachedVertexAttributes(m_lastIndex);
                m_lastIndex = -1;
            }
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        //Debug.Log("OnPointerEnter()");
        isHoveringObject = true;
    }


    public void OnPointerExit(PointerEventData eventData)
    {
        //Debug.Log("OnPointerExit()");
        isHoveringObject = false;
    }


    public void OnPointerClick(PointerEventData eventData)
    {
        // Check if mouse intersects with any links.
        int linkIndex = TMP_TextUtilities.FindIntersectingLink(m_TextMeshPro, Input.mousePosition, m_Camera);

        if (linkIndex != -1 && linkIndex == m_selectedLink)
        {
            Debug.Log("Clicked link index: " + linkIndex);
            answerGroup.ChangeInputFieldByIndex(linkIndex);
        }
    }

    void RestoreCachedVertexAttributes(int index)
    {
        if (index == -1 || index > m_TextMeshPro.textInfo.characterCount - 1) return;

        // Get the index of the material / sub text object used by this character.
        int materialIndex = m_TextMeshPro.textInfo.characterInfo[index].materialReferenceIndex;

        // Get the index of the first vertex of the selected character.
        int vertexIndex = m_TextMeshPro.textInfo.characterInfo[index].vertexIndex;

        // Restore Vertices
        // Get a reference to the cached / original vertices.
        Vector3[] src_vertices = m_cachedMeshInfoVertexData[materialIndex].vertices;

        // Get a reference to the vertices that we need to replace.
        Vector3[] dst_vertices = m_TextMeshPro.textInfo.meshInfo[materialIndex].vertices;

        // Restore / Copy vertices from source to destination
        dst_vertices[vertexIndex + 0] = src_vertices[vertexIndex + 0];
        dst_vertices[vertexIndex + 1] = src_vertices[vertexIndex + 1];
        dst_vertices[vertexIndex + 2] = src_vertices[vertexIndex + 2];
        dst_vertices[vertexIndex + 3] = src_vertices[vertexIndex + 3];

        // Restore Vertex Colors
        // Get a reference to the vertex colors we need to replace.
        Color32[] dst_colors = m_TextMeshPro.textInfo.meshInfo[materialIndex].colors32;

        // Get a reference to the cached / original vertex colors.
        Color32[] src_colors = m_cachedMeshInfoVertexData[materialIndex].colors32;

        // Copy the vertex colors from source to destination.
        dst_colors[vertexIndex + 0] = src_colors[vertexIndex + 0];
        dst_colors[vertexIndex + 1] = src_colors[vertexIndex + 1];
        dst_colors[vertexIndex + 2] = src_colors[vertexIndex + 2];
        dst_colors[vertexIndex + 3] = src_colors[vertexIndex + 3];

        // Restore UV0S
        // UVS0
        Vector2[] src_uv0s = m_cachedMeshInfoVertexData[materialIndex].uvs0;
        Vector2[] dst_uv0s = m_TextMeshPro.textInfo.meshInfo[materialIndex].uvs0;
        dst_uv0s[vertexIndex + 0] = src_uv0s[vertexIndex + 0];
        dst_uv0s[vertexIndex + 1] = src_uv0s[vertexIndex + 1];
        dst_uv0s[vertexIndex + 2] = src_uv0s[vertexIndex + 2];
        dst_uv0s[vertexIndex + 3] = src_uv0s[vertexIndex + 3];

        // UVS2
        Vector2[] src_uv2s = m_cachedMeshInfoVertexData[materialIndex].uvs2;
        Vector2[] dst_uv2s = m_TextMeshPro.textInfo.meshInfo[materialIndex].uvs2;
        dst_uv2s[vertexIndex + 0] = src_uv2s[vertexIndex + 0];
        dst_uv2s[vertexIndex + 1] = src_uv2s[vertexIndex + 1];
        dst_uv2s[vertexIndex + 2] = src_uv2s[vertexIndex + 2];
        dst_uv2s[vertexIndex + 3] = src_uv2s[vertexIndex + 3];


        // Restore last vertex attribute as we swapped it as well
        int lastIndex = (src_vertices.Length / 4 - 1) * 4;

        // Vertices
        dst_vertices[lastIndex + 0] = src_vertices[lastIndex + 0];
        dst_vertices[lastIndex + 1] = src_vertices[lastIndex + 1];
        dst_vertices[lastIndex + 2] = src_vertices[lastIndex + 2];
        dst_vertices[lastIndex + 3] = src_vertices[lastIndex + 3];

        // Vertex Colors
        src_colors = m_cachedMeshInfoVertexData[materialIndex].colors32;
        dst_colors = m_TextMeshPro.textInfo.meshInfo[materialIndex].colors32;
        dst_colors[lastIndex + 0] = src_colors[lastIndex + 0];
        dst_colors[lastIndex + 1] = src_colors[lastIndex + 1];
        dst_colors[lastIndex + 2] = src_colors[lastIndex + 2];
        dst_colors[lastIndex + 3] = src_colors[lastIndex + 3];

        // UVS0
        src_uv0s = m_cachedMeshInfoVertexData[materialIndex].uvs0;
        dst_uv0s = m_TextMeshPro.textInfo.meshInfo[materialIndex].uvs0;
        dst_uv0s[lastIndex + 0] = src_uv0s[lastIndex + 0];
        dst_uv0s[lastIndex + 1] = src_uv0s[lastIndex + 1];
        dst_uv0s[lastIndex + 2] = src_uv0s[lastIndex + 2];
        dst_uv0s[lastIndex + 3] = src_uv0s[lastIndex + 3];

        // UVS2
        src_uv2s = m_cachedMeshInfoVertexData[materialIndex].uvs2;
        dst_uv2s = m_TextMeshPro.textInfo.meshInfo[materialIndex].uvs2;
        dst_uv2s[lastIndex + 0] = src_uv2s[lastIndex + 0];
        dst_uv2s[lastIndex + 1] = src_uv2s[lastIndex + 1];
        dst_uv2s[lastIndex + 2] = src_uv2s[lastIndex + 2];
        dst_uv2s[lastIndex + 3] = src_uv2s[lastIndex + 3];

        // Need to update the appropriate 
        m_TextMeshPro.UpdateVertexData(TMP_VertexDataUpdateFlags.All);
    }
}
