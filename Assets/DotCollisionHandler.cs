using UnityEngine;
using UnityEngine.UI;

public class DotCollisionHandler : MonoBehaviour
{
    public Text messageText; // Reference to the UI Text to display messages

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("IndexFinger"))
        {
            if (collision.gameObject.name == "IndexTip") // Assuming the child GameObject is named "IndexTip"
            {
                messageText.text = "You have hit the target!";
            }
            else
            {
                messageText.text = "You are close to the target!";
            }

            // Deactivate the dot
            gameObject.SetActive(false);
        }
    }
}
