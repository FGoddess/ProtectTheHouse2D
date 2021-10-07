using UnityEngine;

public abstract class Transition : MonoBehaviour
{
    [SerializeField] private State _targetState;

    public State TargetState => _targetState;
    protected Player Target { get; private set; }
    public bool NeedTransition { get; protected set; }

    public void Init(Player target)
    {
        Target = target;
    }

    private void OnEnable()
    {
        NeedTransition = false;
    }

}
