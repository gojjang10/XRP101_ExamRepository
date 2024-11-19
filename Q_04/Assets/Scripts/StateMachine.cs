using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StateType
{
    Idle, Attack
}

public class StateMachine
{
    private Dictionary<StateType, PlayerState> _stateContainer;

    private StateType _currentType;
    public StateType CurrentType { get { return _currentType; } set { _currentType = value; } }
    public PlayerState CurrentState => _stateContainer[_currentType];

    public StateMachine(params PlayerState[] states)
    {
        _stateContainer = new Dictionary<StateType, PlayerState>();

        foreach (var s in states)
        {
            if (!_stateContainer.ContainsKey(s.ThisType))
            {
                _stateContainer.Add(s.ThisType, s);    
            }
            s.Machine = this;
        }

        CurrentType = states[0].ThisType;
        CurrentState.Enter();
    }

    public void OnUpdate()
    {
        CurrentState.OnUpdate();
    }

    public void ChangeState(StateType state)
    {
        if(CurrentType == state) return;

        CurrentState.Exit();
        CurrentType = state;
        CurrentState.Enter();
    }
}
