using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

// This script is based on the tutorial from Sunny Valley Studio
// at https://www.youtube.com/watch?v=RXhTD8YZnY4&list=PLcRSafycjWFcwCxOHnc83yA0p4Gzx0PTM&index=7
public class Health : MonoBehaviour
{
    [SerializeField] 
    private int currentHealth, maxHealth;
    [SerializeField] 
    private bool isPlayer;
    public AudioSource audioSourceLabareda;

    public GameObject thisGameObject;

    public UnityEvent<GameObject> OnHitWithReference;

    public HealthBar healthBar;

    void Start()
    {
        if (isPlayer)
        {
            healthBar.SetMaxHealth(maxHealth);
        }
        
    }
    

    public void OnHit(int damage, GameObject sender, GameObject objeto)
    {
        Animator ani;
        currentHealth -= damage;
        audioSourceLabareda.Play();

        if (isPlayer)
        {
            healthBar.SetHealthBar(currentHealth);
        }

        if (currentHealth > 0)
        {
            OnHitWithReference?.Invoke(sender);
        }
        else if (isPlayer)
        {
            ani = objeto.GetComponent<Animator>();
            ani.SetBool("PlayerIsDead",true);
            //SceneManager.LoadScene("Scenes/MenuInicial");
        }
        else
        {
            ani = objeto.GetComponent<Animator>();
            ani.SetBool("IsDead",true);
            //Destroy(thisGameObject);
        }
    } 
}
