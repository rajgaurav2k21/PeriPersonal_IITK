using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    public List<GameObject> leftSideCoins; // Assign the 5 coins on the left side in the inspector
    public List<GameObject> rightSideCoins; // Assign the 5 coins on the right side in the inspector
    public float interval = 1.0f; // Time interval between each coin activation

    private List<GameObject> allCoins; // To store all the coins together
    private int currentIndex = 0; // To keep track of the current coin index

    void Start()
    {
        // Initialize the list of all coins
        allCoins = new List<GameObject>();
        allCoins.AddRange(leftSideCoins);
        allCoins.AddRange(rightSideCoins);

        // Deactivate all coins initially
        foreach (GameObject coin in allCoins)
        {
            coin.SetActive(false);
        }

        // Start the coroutine to show coins one by one
        StartCoroutine(ShowCoinsOneByOne());
    }

    IEnumerator ShowCoinsOneByOne()
    {
        while (currentIndex < allCoins.Count)
        {
            // Activate the current coin
            GameObject currentCoin = allCoins[currentIndex];
            currentCoin.SetActive(true);

            // Wait until the coin is deactivated
            while (currentCoin.activeSelf)
            {
                yield return null;
            }

            // Move to the next coin
            currentIndex++;
        }
    }

    // This method will be called when the index finger collider touches a coin
    void OnTriggerEnter(Collider other)
    {
        // Check if the colliding object is a coin
        if (other.gameObject.CompareTag("Coin"))
        {
            // Deactivate the coin
            other.gameObject.SetActive(false);
        }
    }
}
