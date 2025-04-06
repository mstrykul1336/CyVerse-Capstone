using UnityEngine;

public class ClickToHideChild : MonoBehaviour
{
    public GameObject exclamationMark; // Assign the child exclamation mark in the inspector

    void OnMouseDown()
    {
        if (exclamationMark != null)
        {
            exclamationMark.SetActive(false);
        }
    }
}
