using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealthManager : MonoBehaviour {

    public int bossHealth;

    public int cloneBossHealth;

    public GameObject deathEffect;

    public int pointsOnDeath;

    public GameObject bossPrefab;

    public float minSize;
    // Update is called once per frame
    void Update()
    {
        if (bossHealth <= 0)
        {
            Instantiate(deathEffect, transform.position, transform.rotation);
            ScoreManager.AddPionts(pointsOnDeath);

            if(transform.localScale.y > minSize)
            {
                GameObject clone1 = Instantiate(bossPrefab, new Vector3(transform.position.x + 0.5f, transform.position.y, transform.position.z), transform.rotation) as GameObject;
                GameObject clone2 = Instantiate(bossPrefab, new Vector3(transform.position.x - 0.5f, transform.position.y, transform.position.z), transform.rotation) as GameObject;

                clone1.transform.localScale = new Vector3(transform.localScale.y * 0.5f, transform.localScale.y * 0.5f, transform.localScale.z);
                clone1.GetComponent<BossHealthManager>().bossHealth = cloneBossHealth;
                clone2.transform.localScale = new Vector3(transform.localScale.y * 0.5f, transform.localScale.y * 0.5f, transform.localScale.z);
                clone2.GetComponent<BossHealthManager>().bossHealth = cloneBossHealth;

            }

            Destroy(gameObject);

        }


    }

    public void giveDamage(int damageToGive)
    {
        bossHealth -= damageToGive;
        GetComponent<AudioSource>().Play();
    }
}
