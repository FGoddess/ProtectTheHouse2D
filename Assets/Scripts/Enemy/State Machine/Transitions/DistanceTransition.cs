using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceTransition : Transition
{
    [SerializeField] private float _transitionRange;
    [SerializeField] private float _spreadRange;

    private void Start()
    {
        _transitionRange += Random.Range(-_spreadRange, _spreadRange);
    }

    private void Update()
    {
        if (Vector2.Distance(transform.position, Target.transform.position) < _transitionRange)
        {
            NeedTransition = true;
        }
    }
}
