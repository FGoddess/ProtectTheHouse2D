using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State : MonoBehaviour
{
    [SerializeField] private List<Transition> _transitions;

    protected Player Target { get; set; }

    public void Enter(Player target)
    {
        if(!enabled)
        {
            Target = target;
            enabled = true;
            foreach(var tr in _transitions)
            {
                tr.enabled = true;
                tr.Init(Target);
            }
        }
    }

    public State GetNextState()
    {
        foreach (var transition in _transitions)
        {
            if(transition.NeedTransition)
            {
                return transition.TargetState;
            }
        }

        return null;
    }

    public void Exit()
    {
        if(enabled)
        {
            foreach(var transition in _transitions)
            {
                transition.enabled = false;
            }

            enabled = false;
        }
    }
}
