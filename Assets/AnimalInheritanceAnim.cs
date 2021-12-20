using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static AnimalActing;

public class AnimalInheritanceAnim : MonoBehaviour
{
    Animator _anim;
    AnimalState _state = AnimalState.Walk;
    private AnimalState State
    {
        get { return _state; }
        set
        {
            if (_state == value)
                return;

            _state = value;
        }
    }
  
    void Awake()
    {
        _anim = GetComponent<Animator>();
    }

    void Update()
    {     
        UpdateController();
    }

    void UpdateController()
    {
        switch (State)
        {
            case AnimalState.Walk:
                _anim.Play("walk");
                break;
            case AnimalState.WalkRight:
                _anim.Play("walk_right");
                break;
            case AnimalState.Jump:
                _anim.Play("jump");
                break;
        }
    }
}
