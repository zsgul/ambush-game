using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    public float currentHealth{get; private set;}
    private Animator anim;
    private bool dead;

    private void Awake() 
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
    }

    public void TakeDamage(float _damage) 
    {
        
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth); // make sure health won't drop below 0
        
        if(currentHealth > 0)
        {
            //hurt
            anim.SetTrigger("hurt");
        }
        else
        {
            //dead
            if(!dead)
            {
                anim.SetTrigger("die");
                GetComponent<PlayerMovement>().enabled = false;
                dead = true;
            }
            
        }
    }

    private void Update() 
    {
        
    }

    public void AddHealth(float _value)
    {
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth);
    }
}
