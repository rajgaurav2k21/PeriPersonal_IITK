using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
    public GameObject[] leftCoins; // Coins on the left side
    public GameObject[] rightCoins; // Coins on the right side

    private int currentLeftCoinIndex = -1;
    private int currentRightCoinIndex = -1;
    private bool trigger = false;

    private void Start()
    {
        // Deactivate all coins initially
        foreach (GameObject coin in leftCoins)
        {
            coin.SetActive(false);
        }
        foreach (GameObject coin in rightCoins)
        {
            coin.SetActive(false);
        }

        // Activate initial coins
        ActivateInitialCoins();

        StartCoroutine(ActivateNextCoinsCoroutine());
    }

    private void ActivateInitialCoins()
    {
        // Randomly activate one coin from each group
        int initialLeftCoin = Random.Range(0, leftCoins.Length);
        int initialRightCoin = Random.Range(0, rightCoins.Length);

        Debug.Log($"Activating initial coins: Left {initialLeftCoin}, Right {initialRightCoin}");

        leftCoins[initialLeftCoin].SetActive(true);
        rightCoins[initialRightCoin].SetActive(true);

        currentLeftCoinIndex = initialLeftCoin;
        currentRightCoinIndex = initialRightCoin;
    }

    private IEnumerator ActivateNextCoinsCoroutine()
    {
        while (true)
        {
            // Wait until triggered
            yield return new WaitUntil(() => trigger);
            trigger = false;

            // Show next set of coins
            ShowNextCoins();
        }
    }

    public void ShowNextCoins()
    {
        // Deactivate current coins
        if (currentLeftCoinIndex >= 0)
        {
            leftCoins[currentLeftCoinIndex].SetActive(false);
        }
        if (currentRightCoinIndex >= 0)
        {
            rightCoins[currentRightCoinIndex].SetActive(false);
        }

        // Activate a new random coin on the left
        int nextLeftCoinIndex = Random.Range(0, leftCoins.Length);
        leftCoins[nextLeftCoinIndex].SetActive(true);
        currentLeftCoinIndex = nextLeftCoinIndex;

        // Activate a new random coin on the right
        int nextRightCoinIndex = Random.Range(0, rightCoins.Length);
        rightCoins[nextRightCoinIndex].SetActive(true);
        currentRightCoinIndex = nextRightCoinIndex;

        Debug.Log($"New coins activated: Left {nextLeftCoinIndex}, Right {nextRightCoinIndex}");
    }

    public void SetTrigger(bool value)
    {
        Debug.Log("SetTrigger called with value: " + value);
        trigger = value;
    }
}
