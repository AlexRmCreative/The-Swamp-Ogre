using Newtonsoft.Json.Serialization;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class Chracter : MonoBehaviour, IDamagable, IUpgradeable, ICurable
{
    [SerializeField] protected int _vida;
    [SerializeField] protected int _maxVida;
    [SerializeField] protected int _dmg;
    [SerializeField] protected float _atkSpeed;
    [SerializeField] protected float _speed;
    [SerializeField] protected float _percepcionRadio;
    [SerializeField] protected float _sigilo;

    public float Sigilo { get => _sigilo; set => _sigilo = value; }
    public float PercepcionRadio { get => _percepcionRadio; set => _percepcionRadio = value; }
    public bool IsAtking { get; set; }
    public int Vida { get => _vida; set => _vida = value; }
    public float Speed { get => _speed; set => _speed = value; }
    public int Dmg { get => _dmg; set => _dmg = value; }


    //Este metodo se utilizara para arreglar las incoherencias en cada metodo añadido
    void FixStats()
    {
        if(_vida > _maxVida)
        {
            _vida = _maxVida;
        }
    }

    //Se utiliza para poder recibir daño
    public void GetSomeDmg(int dmg)
    {
        _vida -= dmg;
        if (_vida <= 0) Muerte();
        Debug.Log(_vida + " He recibido daño y mi vida a disminuido en: " + dmg);
    }

    //Se utiliza para poder obetener vida (vida/Health Points)
    public void GetSomeHP(int vida)
    {
        _vida += vida;
        FixStats();
        Debug.Log(_vida + " Mi vida ha sido curada en: " + vida);
    }

    //Se utiliza para poder aumentar la vida maxima (maxVida)
    public void UpgradeMaxHP(int maxVida)
    {
        _maxVida += maxVida;
        Debug.Log(_maxVida + " Mi vida maxima ha sido mejorada en: " + maxVida);
    }

    //Se utiliza para dañar a un objetivo
    public void MakeDmg(IDamagable damagable)
    {
        damagable.GetSomeDmg(_dmg);
    }

    public virtual void Muerte()
    {
        Debug.Log("Mi vida bajo a 0...he muerto");
    }
}
