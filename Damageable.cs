using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Damageable : MonoBehaviour
{
    public UnityEvent<int,Vector2> damageableHit;
    Animator animator;
    [SerializeField]
    private int _maxHealth = 100;
    public int MaxHealth{
        get
        {
            return _maxHealth;
        }private set
        {
            _maxHealth = value;
        }
    }
    [SerializeField]
    private int _health = 100;
    public int Health
    {
        get
        {
            return _health;
        }set
        {
            _health = value;
            if(_health <= 0)
            {
                IsAlive = false;
            }
        }
    }
    [SerializeField]
    private bool _isAlive = true;
    [SerializeField]
    private bool isInvincible = false;

    public bool IsHit { get
    {
        return animator.GetBool(AnimationStrings.isHit);
    } private set
    {
        animator.SetBool(AnimationStrings.isHit,value);
    } }

    private float invincibilityTime= 0;
    public float timeSinceHit = 0.25f;

    public bool IsAlive
    {
        get
        {
            return _isAlive;
        }set
        {
            _isAlive = value;
            animator.SetBool(AnimationStrings.isAlive,value);
            Debug.Log("IsAlive set " + value);
        }
    }
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        if (isInvincible)
        {
            if(timeSinceHit > invincibilityTime)
            {
                isInvincible = false;
                timeSinceHit = 0;
            }
            timeSinceHit += Time.deltaTime;
        }
    }
    public bool Hit(int damage,Vector2 knockback)
    {
        if(IsAlive && !isInvincible)
        {
            Health -=damage;
            isInvincible = true;
            IsHit = true;
            damageableHit?.Invoke(damage,knockback);
            CharacterEvents.characterDamaged.Invoke(gameObject,damage);
            return true;
        }
        return false;

    }
}
