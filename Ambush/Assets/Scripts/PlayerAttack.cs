using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] fireballs;
    private Animator anim;
    private PlayerMovement playerMovement;
    private float cooldownTimer = Mathf.Infinity; //bc cooldown timer is tharting with 0 in the attack method

    private void Awake()
    {
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if(Input.GetMouseButton(0) && cooldownTimer > attackCooldown && playerMovement.canAttack()) // check if enough time passes to shoot the next shot
            Attack();

        cooldownTimer += Time.deltaTime;
    }

    private void Attack()
    {
        anim.SetTrigger("attack");
        cooldownTimer = 0;

        //object pool fireballs
        fireballs[0].transform.position = firePoint.position;
        fireballs[0].GetComponent<Projectile>().SetDirection(Mathf.Sign(transform.localScale.x));
    }
    
}
