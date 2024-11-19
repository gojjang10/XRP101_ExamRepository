using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StateAttack : PlayerState
{
    private float _delay = 2;
    private WaitForSeconds _wait;
    Coroutine _coroutine;
    
    public StateAttack(PlayerController controller) : base(controller)
    {
        
    }

    public override void Init()
    {
        _wait = new WaitForSeconds(_delay);
        ThisType = StateType.Attack;
    }

    public override void Enter()
    {
        if(_coroutine == null)
        {
            _coroutine = Controller.StartCoroutine(DelayRoutine());
        }
    }

    public override void OnUpdate()
    {
        Debug.Log("Attack On Update");
    }

    public override void Exit()
    {
        if (_coroutine != null)
        {
            Controller.StopCoroutine(_coroutine);
            _coroutine = null;
        }

        if (Machine.CurrentType != StateType.Idle)
        {
            Machine.ChangeState(StateType.Idle);
        }
    }
    

    private void Attack()
    {
        Collider[] cols = Physics.OverlapSphere(
            Controller.transform.position,
            Controller.AttackRadius
            );

        IDamagable damagable;
        foreach (Collider col in cols)
        {
            damagable = col.GetComponent<IDamagable>();
            if (damagable != null)
            {
                damagable.TakeHit(Controller.AttackValue);
            }
        }
    }

    public IEnumerator DelayRoutine()
    {
        yield return _wait;

        Attack();
        Exit();
    }

}
