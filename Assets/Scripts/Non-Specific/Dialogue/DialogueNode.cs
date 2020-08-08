using UnityEngine;

[CreateAssetMenu(fileName = "New DialogueNode", menuName = "Dialogue/Node")]
public class DialogueNode : ScriptableObject
{
    [TextArea]
    public string speech;
    
    [TextArea]
    [SerializeField] protected string optionOneText;
    [SerializeField] protected DialogueNode optionOne;
    [Space]
    
    [TextArea]
    [SerializeField] protected string optionTwoText;
    [SerializeField] protected DialogueNode optionTwo;
    [Space]

    //added1
    [TextArea]
    [SerializeField] protected string optionThreeText;
    [SerializeField] protected DialogueNode optionThree;
    [Space]

    //added2
    [TextArea]
    [SerializeField] protected string optionFourText;
    [SerializeField] protected DialogueNode optionFour;
    [Space]

    //added3
    [TextArea]
    [SerializeField] protected string optionFiveText;
    [SerializeField] protected DialogueNode optionFive;
    [Space]

    //added4
    [TextArea]
    [SerializeField] protected string optionSixText;
    [SerializeField] protected DialogueNode optionSix;
    [Space]

    [TextArea]
    [SerializeField] protected string optionSevenText;
    [SerializeField] protected DialogueNode optionSeven;
    [Space]

    [SerializeField] private DialogueRequirement[] Requirements;
    [SerializeField] private DialogueOutcome[] Outcomes;


    
    [Space][Space][Header("If set, will become the new head once traversed")] 
    [SerializeField] private DialogueNode NewHead;

    public virtual DialogueNode GetNodeOne() { return optionOne; }
    public virtual DialogueNode GetNodeTwo() { return optionTwo; }

    //added1
    public virtual DialogueNode GetNodeThree() { return optionThree; }
    //added2
    public virtual DialogueNode GetNodeFour() { return optionFour; }
    //added3
    public virtual DialogueNode GetNodeFive() { return optionFive; }
    //added4
    public virtual DialogueNode GetNodeSix() { return optionSix; }

    public virtual DialogueNode GetNodeSeven() { return optionSeven; }

    public virtual string GetTextOne() { return optionOneText; }
    public virtual string GetTextTwo() { return optionTwoText; }

    //added1
    public virtual string GetTextThree() { return optionThreeText; }
    //added2
    public virtual string GetTextFour() { return optionFourText; }
    //added3
    public virtual string GetTextFive() { return optionFiveText; }
    //added4
    public virtual string GetTextSix() { return optionSixText; }
    public virtual string GetTextSeven() { return optionSevenText; }

    public string CheckRequirements()
    {
        if (Requirements != null)
            return CheckRequirements(Requirements);
        
        return "";
    }

    protected string CheckRequirements(DialogueRequirement[] dr)
    {
        foreach (DialogueRequirement req in dr)
        {
            if (req == null) continue;
            if (!req.TestSatisfaction()) return req.GetFailureMessage();
        }

        return "";
    }


    public void DoOutcomes(ref NPC n)
    {
        foreach (DialogueOutcome oc in Outcomes)
        {
            oc.DoOutcome(ref n);
        }
    }
    public DialogueNode GetNewHead()
    {
        return NewHead;
    }
}
