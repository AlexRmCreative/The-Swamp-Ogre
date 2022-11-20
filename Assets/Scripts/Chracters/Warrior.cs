using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior : Chracter
{
    [SerializeField] Warrior warrior;

    private void Start()
    {
        warrior = this;
    }
    private void Update()
    {

    }
}
