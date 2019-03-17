using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyHealth : MonoBehaviour {

    public float initialHealth = 10.0f;
    public GameObject hitEffect;
    public GameObject deathEffect;
    public string loadLevelOnDeath = "";
    private float currentHealth;
    
    // Use this for initialization
	void Start () {
        currentHealth = initialHealth;
	}

    public void TakeDamage(float damageAmount, Vector3 damagePosition)
    {

        currentHealth -= damageAmount;
        Instantiate(hitEffect, damagePosition, Quaternion.identity);
        if (currentHealth <= 0)
        {
            if (transform.parent != null)
            {
                transform.parent.SendMessage("Dead", transform.position, SendMessageOptions.DontRequireReceiver);
            }
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);

            if (!string.IsNullOrEmpty(loadLevelOnDeath))
            {
                SceneManager.LoadScene(loadLevelOnDeath);
            }
        }
    }

    void OnTriggerEnter(Collider col)
    {
        TakeDamage(1.0f, col.transform.position);
    }
}
