using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Health_Script : MonoBehaviour
{
    public float currentHealth;
    public float maxHealth;

    public int reward;

    public Image healthImage;

    // Start is called before the first frame update
    public virtual void Start()
    {
        //Set current health to max health
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    public virtual void Update()
    {
        
    }

    public void takeDamage(float amount, Pawn_Script source)
    {
        //currenthealth is set to currenthealth - amount
        currentHealth -= amount;
        Debug.Log(source.name + " did " + amount + " damage to " + gameObject.name);

        //Ensure currentheath does not exceed max health or  be lower than 0
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        //Check if health is equal to or less than 0
        if (currentHealth <= 0)
        {
            Die(source);
        }

        updateHealth();
    }

    public void heal(float amount, Pawn_Script source)
    {
        //Currenthealth is added to amount and that is new value
        currentHealth += amount;
        //Check who healed who
        Debug.Log(source.name + " did " + amount + " healing to " + gameObject.name);

        //Ensure currentheath does not exceed max health or be lower than 0
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        updateHealth();
    }

    //Call this function when death
    public virtual void Die(Pawn_Script source)
    {
        if(reward != 0)
        {
            source.controller.addToScore(reward);
        }
    }

    public void updateHealth()
    {
        if (healthImage != null)
        {
            healthImage.fillAmount = currentHealth / maxHealth;
        }
    }
}
