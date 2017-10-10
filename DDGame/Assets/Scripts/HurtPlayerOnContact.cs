using UnityEngine;
using System.Collections;

public class HurtPlayerOnContact : MonoBehaviour {

    public int damageToGive;

    void OnTriggerEnter2D( Collider2D other )
    {
        if ( other.name == "Player" )
        {
            HealthManager.HurtPlayer(damageToGive);
            other.GetComponent<AudioSource>().Play();

            //var弱化类型的定义，可代替任何类型
            var playerKnockEnemy = other.GetComponent<PlayerKnockEnemy>();

			playerKnockEnemy.knockBackCounter = playerKnockEnemy.knockBackLength;

            if ( other.transform.position.x < transform.position.x )
            {
				
				playerKnockEnemy.knockFromRight = true;

            } else {
				
				playerKnockEnemy.knockFromRight = false;

            }
            
        }
    }
}
