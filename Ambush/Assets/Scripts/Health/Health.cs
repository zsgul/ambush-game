using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    public float currentHealth{get; private set;}

    private void Awake() 
    {
        currentHealth = startingHealth;
    }

    public void TakeDamage(float _damage) 
    {
        
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth); // make sure health won't drop below 0
        
        if(currentHealth > 0)
        {
            //hurt
        }
        else
        {
            //dead
        }
    }

    private void Update() 
    {
        
    }
}
