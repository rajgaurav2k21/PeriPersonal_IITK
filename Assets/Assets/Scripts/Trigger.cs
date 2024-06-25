using UnityEngine;

public class Trigger : MonoBehaviour
{
    public GameController gameController;
    private void OnTriggerExit(Collider other)
    {
        gameController.SetTrigger(true);
    }
}
