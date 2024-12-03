using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public int attackDamage = 5;
    public Vector2 knockback = new Vector2(5, 2); // Example values; adjust as needed

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Damageable damageable = collision.GetComponent<Damageable>();
        if (damageable != null)
        {
            // Determine the direction of knockback
            float knockbackDirection = (collision.transform.position.x < transform.position.x) ? -1f : 1f;

            // Apply knockback in the correct horizontal direction
            Vector2 adjustedKnockback = new Vector2(knockback.x * knockbackDirection, knockback.y);

            // Apply damage with the adjusted knockback
            bool gotHit = damageable.Hit(attackDamage, adjustedKnockback);
            if (gotHit)
                Debug.Log(collision.name + " hit for " + attackDamage + " with knockback: " + adjustedKnockback);
        }
    }
}
