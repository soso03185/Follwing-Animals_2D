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
        Flip();


     //       this.transform.localScale = new Vector2(0.5f, 0.5f);
    }
    void Flip()
    {
        Vector2 _thisScaleVec = transform.localScale;

        _thisScaleVec.x *= -1;

        transform.localScale = _thisScaleVec;
    }
    void UpdateController()
    {
        switch (State)
        {
            case AnimalState.Idle:
                _anim.Play("idle");
                break;
            case AnimalState.Walk:
                _anim.Play("walk");
                break;
            case AnimalState.Jump:
                _anim.Play("jump");
                break;
            case AnimalState.Sleep:
                _anim.Play("sleep");
                break;
            case AnimalState.Eat:
                _anim.Play("eat");
                break;
        }
    }
}
