/*using UnityEngine;

[CreateAssetMenu(fileName = "Check Required Object", menuName = "Dialogue/Requirements/GameObjectCheck")]
public class GameObjectCheck : DialogueRequirement
{
    public string RequiredObject;

    [Header("Shouldnt be empty")]
    [SerializeField] private string failureMessage;

    public override bool TestSatisfaction()
    {
        return GameObject.Find(RequiredObject).activeSelf;
    }

    public override string GetFailureMessage()
    {
        if (failureMessage == "")
            return base.GetFailureMessage();

        return failureMessage;
    }
}
*/