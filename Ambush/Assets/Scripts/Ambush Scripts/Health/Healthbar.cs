using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    [SerializeField]public Health playerHealth;
    [SerializeField]private Image totalHealthbar;
    [SerializeField]private Image currentHealthbar;

    private void Start()
    {
        totalHealthbar.fillAmount = Health.currentHealth / 10;
        //totalHealthbar.fillAmount = playerHealth.currentHealth / 10;
    }

    private void Update()
    {
        currentHealthbar.fillAmount = Health.currentHealth / 10;
        //currentHealthbar.fillAmount = playerHealth.currentHealth / 10;

    }
}
