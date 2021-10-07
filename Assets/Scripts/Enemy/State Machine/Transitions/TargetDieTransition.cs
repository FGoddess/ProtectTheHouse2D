using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetDieTransition : Transition
{
    private void Update()
    {
        if(Target is null)
        {
            NeedTransition = true;
        }
    }
}
