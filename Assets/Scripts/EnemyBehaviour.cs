using UnityEngine;
using System.Collections;

abstract public class EnemyBehaviour : MonoBehaviour
{
    abstract public void UpdateValues();
    abstract public void AttackAction();
}
