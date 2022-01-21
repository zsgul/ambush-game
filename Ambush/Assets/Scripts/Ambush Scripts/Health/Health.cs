using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    
    [SerializeField] private float startingHealth;
    public static float currentHealth; 
    private Animator anim;
    private bool dead;

    
    [SerializeField] private float iFramesDuration;
    [SerializeField] private float numberOfFlashes;
    private SpriteRenderer spriteRend;

    public AudioSource sesKontrol;
    public AudioClip olum;


    void Start()
    {
        sesKontrol = GetComponent<AudioSource>();
    }

    private void Awake() 
    {
        if (currentHealth > 0)
        {
            startingHealth = currentHealth;
        }
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
    }

    public void TakeDamage(float _damage) 
    {
        
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth); // make sure health won't drop below 0
        
        if(currentHealth > 0)
        {
            //hurt
            anim.SetTrigger("hurt");
            StartCoroutine(Invulnerability());
        }
        else
        {
            //dead
            if(!dead)
            {
                anim.SetTrigger("die");
                GetComponent<PlayerMovement>().enabled = false;
                dead = true;
                sesKontrol.PlayOneShot(olum);
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

    private IEnumerator Invulnerability()
    {
        Physics2D.IgnoreLayerCollision(10, 11, true);
        for (int i = 0; i < numberOfFlashes; i++)
        {
            spriteRend.color = new Color(1,0,0, 0.5f);
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
            spriteRend.color = Color.white;
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
        }
        Physics2D.IgnoreLayerCollision(10, 11, false);
    }
}
 