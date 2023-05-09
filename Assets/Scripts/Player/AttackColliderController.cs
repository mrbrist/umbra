using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackColliderController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyController ec;
        if (collision.TryGetComponent(out ec))
        {
            ec.TakeDamage(5);
        }
    }
}
