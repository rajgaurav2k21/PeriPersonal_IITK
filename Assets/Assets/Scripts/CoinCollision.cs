using UnityEngine;

public class CoinCollision : MonoBehaviour
{
    public GameController gameController; // Ensure semicolon here

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("HandCollider"))
        {
            Debug.Log("Hand collided with coin: " + gameObject.name);
            gameController.ShowNextCoins();
            gameObject.SetActive(false);
        }
    }
}
