/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Objective Outcome", menuName = "Dialogue/Outcomes/IsObjectiveSatisfied")]
public class IsObjectiveSatisfied : DialogueOutcome
{
    public GameObject WhatNeedsToAppear;
    public SatisfyObjective WhatNeedsToBeSatisfied;

    public override void DoOutcome(ref NPC n)
    {
        if (WhatNeedsToBeSatisfied)
        {
            WhatNeedsToAppear.SetActive(true);
        }
        else
        {
            WhatNeedsToAppear.SetActive(false);
        }
    }
}*/

/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Objective Outcome", menuName = "Dialogue/Outcomes/IsObjectiveSatisfied")]
public class IsObjectiveSatisfied : DialogueOutcome
{
    private GameObject WhatNeedsToAppear;
    public SatisfyObjective WhatNeedsToBeSatisfied;

    public override void DoOutcome(ref NPC n)
    {
        //WhatNeedsToAppear = GameObject.Find(targetGameObject);

        if (WhatNeedsToBeSatisfied)
        {
            WhatNeedsToAppear.Find(targetGameObject).GetComponent<InteractWithMaria>().AhmadAppear();
        }
        else
        {
            WhatNeedsToAppear.Find(targetGameObject).GetComponent<InteractWithMaria>().AhmadDisappear();
        }
    }
}*/

/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Objective Outcome", menuName = "Dialogue/Outcomes/IsObjectiveSatisfied")]
public class IsObjectiveSatisfied : DialogueOutcome
{
    public GameObject WhatNeedsToAppear;
    

    public override void DoOutcome(ref NPC n)
    {
        WhatNeedsToAppear.SetActive(true);  
    }
}*/

/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Objective Outcome", menuName = "Dialogue/Outcomes/IsObjectiveSatisfied")]
public class IsObjectiveSatisfied : DialogueOutcome
{
    public string WhatNeedsToAppear;
    public SatisfyObjective WhatsSatisfied;


    public override void DoOutcome(ref NPC n)
    {
        if (WhatsSatisfied)
        {
            GameObject.Find(WhatNeedsToAppear).SetActive(true);
        }

        else
        {
            GameObject.Find(WhatNeedsToAppear).SetActive(false);
        }
        
    }
}*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New GameObject Addition", menuName = "Dialogue/Outcomes/IsObjectiveSatisfied")]
public class IsObjectiveSatisfied : DialogueOutcome
{
    public string WhatNeedsToAppear;


    public override void DoOutcome(ref NPC n)
    {
        GameObject.Find(WhatNeedsToAppear).SetActive(true);
    }
}