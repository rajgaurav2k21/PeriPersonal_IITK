using UnityEngine;
using UnityEngine.UI;

public class AssignMessageText : MonoBehaviour
{
    public Text messageText; // Assign this in the Inspector with your Message Text UI

    void Start()
    {
        DotCollisionHandler[] dots = FindObjectsOfType<DotCollisionHandler>();
        foreach (DotCollisionHandler dot in dots)
        {
            dot.messageText = messageText;
        }
    }
}
