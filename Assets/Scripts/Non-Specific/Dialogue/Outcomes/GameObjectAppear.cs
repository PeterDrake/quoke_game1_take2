using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New GameObject Addition", menuName = "Dialogue/Outcomes/GameObjectAppear")]
public class GameObjectAppear : DialogueOutcome
{
    public string WhatNeedsToAppear;
    public int x;
    public int y;
    public int z;


    public override void DoOutcome(ref NPC n)
    {
        GameObject.Find(WhatNeedsToAppear).transform.position = new Vector3(x, y, z);
    }
}