using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

	public int maxHealth = 100;
	public int currentHealth;

	public HealthBar healthBar;
    public Rigidbody2D goo;

    public bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
		currentHealth = maxHealth;
		healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
		if (Input.GetKeyDown(KeyCode.Space))
		{
			TakeDamage(20);
		}
    }

	void TakeDamage(int damage)
	{
		currentHealth -= damage;

		healthBar.SetHealth(currentHealth);
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        Physics2D.IgnoreLayerCollision(8, 8);
        Physics2D.IgnoreLayerCollision(9, 11);

        if (collision.gameObject.layer == 11) //check the int value in layer manager(User Defined starts at 8) 
        {
            Debug.Log("Hit object gooo: (from Player)" + collision.gameObject.name);
            goo.isKinematic = true;
            goo.velocity = new Vector2(0.0f, 0.0f);

            TakeDamage(20);
        }
    }


    void OnCollisionExit2D(Collision2D collision)
        {
        goo.isKinematic = false;
    }

}