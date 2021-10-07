using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AttackState : State
{
    [SerializeField] private int _damage;
    [SerializeField] private float _attackDelay;

    private float _attackTime;
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (_attackTime <= 0)
        {
            Attack(Target);
            _attackTime = _attackDelay;
        }

        _attackTime -= Time.deltaTime;
    }

    private void Attack(Player target)
    {
        _animator.Play("Attack");
        target.TakeDamage(_damage);
    }
}
