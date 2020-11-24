using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrow : MonoBehaviour
{

    public GameObject hitEffect;

    void OnCollisionEnter2D(Collision2D collision)
	{
        
            Debug.Log("Hit object: (from arrow)" + collision.gameObject.name);

            Physics2D.IgnoreLayerCollision(8, 8);

       

        if (collision.gameObject.tag != "arrow")
        {
            GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(effect, 1f);
            Destroy(gameObject);
        }


		//else
		//{
  //          Physics2D.IgnoreCollision(arrow1, player, true); // DID NOT WORK 		
  //      }


    }
}
