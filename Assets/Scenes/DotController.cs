using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotController : MonoBehaviour
{
    public List<GameObject> leftSideDots; // Assign the 5 dots on the left side in the inspector
    public List<GameObject> rightSideDots; // Assign the 5 dots on the right side in the inspector
    public float interval = 1.0f; // Time interval between each dot activation

    private List<GameObject> allDots; // To store all the dots together
    private int currentIndex = 0; // To keep track of the current dot index

    void Start()
    {
        // Initialize the list of all dots
        allDots = new List<GameObject>();
        allDots.AddRange(leftSideDots);
        allDots.AddRange(rightSideDots);

        // Deactivate all dots initially
        foreach (GameObject dot in allDots)
        {
            dot.SetActive(false);
        }

        // Start the coroutine to show dots one by one
        StartCoroutine(ShowDotsOneByOne());
    }

    IEnumerator ShowDotsOneByOne()
    {
        while (currentIndex < allDots.Count)
        {
            // Activate the current dot
            GameObject currentDot = allDots[currentIndex];
            currentDot.SetActive(true);

            // Wait until the dot is deactivated or the interval elapses
            float elapsedTime = 0f;
            while (elapsedTime < interval && currentDot.activeSelf)
            {
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            // Move to the next dot if the current one is deactivated
            if (!currentDot.activeSelf)
            {
                currentIndex++;
            }
        }
    }
}
