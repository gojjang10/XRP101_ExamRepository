using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    private float _moveSpeed;
    public float MoveSpeed
    {
        get => _moveSpeed;
        private set => _moveSpeed = value;
    }

    private void Start()
    {
        Init();
    }

    private void Init()
    {
        _moveSpeed = 5f;
    }
}
