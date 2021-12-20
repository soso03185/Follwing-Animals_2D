using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalInheritanceAnim : AnimalFreeAnim
{
    protected override void Awake()
    {
        base.Awake();
        State = AnimalActing.AnimalState.Walk;
    }

    private void OnEnable()
    {

    }



}
