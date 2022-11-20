using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamagable
{
    public int Vida { get; set; }
    public void GetSomeDmg(int dmg);
}
