using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New DialogueNode", menuName = "Dialogue/SpecialNode")]
public class SpecialNode : DialogueNode
{
    [Header("If the related requirements are not satisfied, the alt will be used")]
    [Space]
    public DialogueRequirement[] IfRequirementsOne;
    [TextArea]
    [SerializeField] private string optionOneTextAlt;
    [SerializeField] private DialogueNode optionOneAlt;
    [Space]

    public DialogueRequirement[] IfRequirementsTwo;
    [TextArea]
    [SerializeField] private string optionTwoTextAlt;
    [SerializeField] private DialogueNode optionTwoAlt;
    [Space]

    [Header("If the related requirements are not satisfied, the alt will be used")]
    [Space]
    public DialogueRequirement[] IfRequirementsThree;
    [TextArea]
    [SerializeField] private string optionThreeTextAlt;
    [SerializeField] private DialogueNode optionThreeAlt;
    [Space]

    [Header("If the related requirements are not satisfied, the alt will be used")]
    [Space]
    public DialogueRequirement[] IfRequirementsFour;
    [TextArea]
    [SerializeField] private string optionFourTextAlt;
    [SerializeField] private DialogueNode optionFourAlt;
    [Space]

    [Header("If the related requirements are not satisfied, the alt will be used")]
    [Space]
    public DialogueRequirement[] IfRequirementsFive;
    [TextArea]
    [SerializeField] private string optionFiveTextAlt;
    [SerializeField] private DialogueNode optionFiveAlt;
    [Space]

    [Header("If the related requirements are not satisfied, the alt will be used")]
    [Space]
    public DialogueRequirement[] IfRequirementsSix;
    [TextArea]
    [SerializeField] private string optionSixTextAlt;
    [SerializeField] private DialogueNode optionSixAlt;
    [Space]

    [Header("If the related requirements are not satisfied, the alt will be used")]
    [Space]
    public DialogueRequirement[] IfRequirementsSeven;
    [TextArea]
    [SerializeField] private string optionSevenTextAlt;
    [SerializeField] private DialogueNode optionSevenAlt;


    public override DialogueNode GetNodeOne()
    {
        return (CheckRequirements(IfRequirementsOne) == "") ? optionOne : optionOneAlt;
    }
    public override DialogueNode GetNodeTwo()
    {
        return (CheckRequirements(IfRequirementsTwo) == "") ? optionTwo : optionTwoAlt;
    }
    public override DialogueNode GetNodeThree()
    {
        return (CheckRequirements(IfRequirementsThree) == "") ? optionThree : optionThreeAlt;
    }

    public override DialogueNode GetNodeFour()
    {
        return (CheckRequirements(IfRequirementsFour) == "") ? optionFour : optionFourAlt;
    }

    public override DialogueNode GetNodeFive()
    {
        return (CheckRequirements(IfRequirementsFive) == "") ? optionFive : optionFiveAlt;
    }

    public override DialogueNode GetNodeSix()
    {
        return (CheckRequirements(IfRequirementsSix) == "") ? optionSix : optionSixAlt;
    }
    public override DialogueNode GetNodeSeven()
    {
        return (CheckRequirements(IfRequirementsSeven) == "") ? optionSeven : optionSevenAlt;
    }

    public override string GetTextOne()
    {
        return (CheckRequirements(IfRequirementsOne) == "") ? optionOneText : optionOneTextAlt;
    }
    public override string GetTextTwo()
    {
        return (CheckRequirements(IfRequirementsTwo) == "") ? optionTwoText : optionTwoTextAlt;
    }
    public override string GetTextThree()
    {
        return (CheckRequirements(IfRequirementsThree) == "") ? optionThreeText : optionThreeTextAlt;
    }
    public override string GetTextFour()
    {
        return (CheckRequirements(IfRequirementsFour) == "") ? optionFourText : optionFourTextAlt;
    }
    public override string GetTextFive()
    {
        return (CheckRequirements(IfRequirementsFive) == "") ? optionFiveText : optionFiveTextAlt;
    }
    public override string GetTextSix()
    {
        return (CheckRequirements(IfRequirementsSix) == "") ? optionSixText : optionSixTextAlt;
    }
    public override string GetTextSeven()
    {
        return (CheckRequirements(IfRequirementsSeven) == "") ? optionSevenText : optionSevenTextAlt;
    }

}
