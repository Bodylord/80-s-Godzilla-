using System;
using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public interface IDamagable : IGameObject
{
    void DoDamage(int damage);
    event EventHandler BeforeDying;
}
