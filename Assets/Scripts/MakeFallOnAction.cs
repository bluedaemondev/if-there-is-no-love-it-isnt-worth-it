using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeFallOnAction : MonoBehaviour
{
    public List<FallingObject> toActivateRB;

    public void TriggerFall()
    {
        print("fall triggered");
        foreach (var item in toActivateRB)
        {
            item.MakeFall();
        }
    }
    
}
