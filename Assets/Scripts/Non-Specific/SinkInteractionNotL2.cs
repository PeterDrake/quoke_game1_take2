using UnityEngine;

public class SinkInteractionNotL2 : MonoBehaviour
{
    private bool _firstInteraction = true;

    private InteractWithObject _interact;
    private void Start()
    {
        _interact = GetComponent<InteractWithObject>();
    }

    public void Interaction()
    {
        Systems.Status.AffectHydration(100);
        _firstInteraction = false;
        _interact.SetInteractText("Press 'E' to Drink from Sink");
        _interact.DeleteItems();
        // _interact = null;
    }
}