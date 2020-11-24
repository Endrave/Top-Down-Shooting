using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
	public Transform firePoint;
	public Transform firePointRight;
	public Transform firePointDown;
	public Transform firePointLeft;
	public Transform firePoint45;
	public Transform firePoint135;
	public Transform firePoint225;
	public Transform firePoint315;
	public GameObject bulletPrefab;
	public Rigidbody2D playerrb;

	public Collider2D arrow;
    public Collider2D player;

    public Camera cam;
    Vector2 mousePos;

    public float bulletForce = 1f;

    void Start()
    {
        gameObject.layer = 8;
    }


    // Update is called once per frame
    void Update()
    {
        //if (Input.GetButtonDown("Fire1"))
        //{
        //          shoot();
        ////}
        //      else


        if ((Input.GetButtonDown("Fire2")))
        {
			//shoot11115();
			//shootspiral();

			Invoke("shoot45d", 0);
			Invoke("shoot90d", 1 / 5f);
			Invoke("shoot45d", 2 / 5f);
			Invoke("shoot90d", 3 / 5f);
			Invoke("shoot45d", 4 / 5f);

			//InvokeRepeating("shootradial", 0f, 0.3f);

		}

		//fixing firepoint on player
		firePoint.position = playerrb.position;

}


    //   void shoot()
    //{
    //       GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    //       Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
    //       rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    //}

    void shoot11115()
	{
		for (int i = 0; i < 5; i++)
		{
            if(i == 4) {
                Invoke("shootradial", i + 0);
			    Debug.Log("First bullet");
			    Invoke("shootradial", i + 0.2f);
			    Debug.Log("Second bullet");
			    Invoke("shootradial", i + 0.4f);
			    Debug.Log("Third bullet");
			    Invoke("shootradial", i + 0.6f);
			    Debug.Log("First bullet");
				Invoke("shootradial", i + 0.8f);
			}
			else
			{
				Invoke("shootradial", i + 0);
			}
	
		}
	}

    void shoot25d290d()
	{
		for (int i = 0; i < 5; i++)
		{
			if (i % 2 == 1)
			{
				Invoke("shoot45d", i/5);
			}
			else
			{
				Invoke("shoot90d", i/5);
			}

		}
	}


	void shoot45d()
	{
		GameObject bullet05 = Instantiate(bulletPrefab, firePoint45.position, firePoint45.rotation);
		Rigidbody2D rb05 = bullet05.GetComponent<Rigidbody2D>();
		rb05.AddForce(firePoint45.up * bulletForce, ForceMode2D.Impulse);

		GameObject bullet06 = Instantiate(bulletPrefab, firePoint135.position, firePoint135.rotation);
		Rigidbody2D rb06 = bullet06.GetComponent<Rigidbody2D>();
		rb06.AddForce(firePoint135.up * bulletForce, ForceMode2D.Impulse);

		GameObject bullet07 = Instantiate(bulletPrefab, firePoint225.position, firePoint225.rotation);
		Rigidbody2D rb07 = bullet07.GetComponent<Rigidbody2D>();
		rb07.AddForce(firePoint225.up * bulletForce, ForceMode2D.Impulse);

		GameObject bullet08 = Instantiate(bulletPrefab, firePoint315.position, firePoint315.rotation);
		Rigidbody2D rb08 = bullet08.GetComponent<Rigidbody2D>();
		rb08.AddForce(firePoint315.up * bulletForce, ForceMode2D.Impulse);
	}


	void shoot90d()
	{
		GameObject bullet01 = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
		Rigidbody2D rb01 = bullet01.GetComponent<Rigidbody2D>();
		rb01.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);

		GameObject bullet02 = Instantiate(bulletPrefab, firePointRight.position, firePointRight.rotation);
		Rigidbody2D rb02 = bullet02.GetComponent<Rigidbody2D>();
		rb02.AddForce(firePointRight.up * bulletForce, ForceMode2D.Impulse);

		GameObject bullet03 = Instantiate(bulletPrefab, firePointDown.position, firePointDown.rotation);
		Rigidbody2D rb03 = bullet03.GetComponent<Rigidbody2D>();
		rb03.AddForce(firePointDown.up * bulletForce, ForceMode2D.Impulse);

		GameObject bullet04 = Instantiate(bulletPrefab, firePointLeft.position, firePointLeft.rotation);
		Rigidbody2D rb04 = bullet04.GetComponent<Rigidbody2D>();
		rb04.AddForce(firePointLeft.up * bulletForce, ForceMode2D.Impulse);
	}

    void shootspiral()
    {
	    for (int i = 0; i < 5; i++)
	    {
		Invoke("shootb1", i + 0);
		Debug.Log("First bullet");
		Invoke("shootb8", i + 1/8f);
		Debug.Log("Second bullet");
		Invoke("shootb2", i + 2/8f);
		Debug.Log("Third bullet");
		Invoke("shootb7", i + 3/8f);
		Debug.Log("First bullet");
		Invoke("shootb3", i + 4/8f);
		Invoke("shootb6", i + 5/8f);
		Invoke("shootb4", i + 6/8f);
		Invoke("shootb5", i + 7/8f);
	    }

		//for (int i = 0; i < 5; i++)
		//{
		//	Invoke("shootb1", i + 4 / 8f);
		//	Debug.Log("First bullet");
		//	Invoke("shootb8", i + 5 / 8f);
		//	Debug.Log("Second bullet");
		//	Invoke("shootb2", i + 6 / 8f);
		//	Debug.Log("Third bullet");
		//	Invoke("shootb7", i + 7 / 8f);
		//	Debug.Log("First bullet");
		//	Invoke("shootb3", i);
		//	Invoke("shootb6", i + 1 / 8f);
		//	Invoke("shootb4", i + 2 / 8f);
		//	Invoke("shootb5", i + 3 / 8f);
		//}

	}

	void shootradial()
    {
		GameObject bullet01 = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
		Rigidbody2D rb01 = bullet01.GetComponent<Rigidbody2D>();
		rb01.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);

		GameObject bullet02 = Instantiate(bulletPrefab, firePointRight.position, firePointRight.rotation);
		Rigidbody2D rb02 = bullet02.GetComponent<Rigidbody2D>();
		rb02.AddForce(firePointRight.up * bulletForce, ForceMode2D.Impulse);

		GameObject bullet03 = Instantiate(bulletPrefab, firePointDown.position, firePointDown.rotation);
		Rigidbody2D rb03 = bullet03.GetComponent<Rigidbody2D>();
		rb03.AddForce(firePointDown.up * bulletForce, ForceMode2D.Impulse);

		GameObject bullet04 = Instantiate(bulletPrefab, firePointLeft.position, firePointLeft.rotation);
		Rigidbody2D rb04 = bullet04.GetComponent<Rigidbody2D>();
		rb04.AddForce(firePointLeft.up * bulletForce, ForceMode2D.Impulse);

		GameObject bullet05 = Instantiate(bulletPrefab, firePoint45.position, firePoint45.rotation);
		Rigidbody2D rb05 = bullet05.GetComponent<Rigidbody2D>();
		rb05.AddForce(firePoint45.up * bulletForce, ForceMode2D.Impulse);

		GameObject bullet06 = Instantiate(bulletPrefab, firePoint135.position, firePoint135.rotation);
		Rigidbody2D rb06 = bullet06.GetComponent<Rigidbody2D>();
		rb06.AddForce(firePoint135.up * bulletForce, ForceMode2D.Impulse);

		GameObject bullet07 = Instantiate(bulletPrefab, firePoint225.position, firePoint225.rotation);
		Rigidbody2D rb07 = bullet07.GetComponent<Rigidbody2D>();
		rb07.AddForce(firePoint225.up * bulletForce, ForceMode2D.Impulse);

		GameObject bullet08 = Instantiate(bulletPrefab, firePoint315.position, firePoint315.rotation);
		Rigidbody2D rb08 = bullet08.GetComponent<Rigidbody2D>();
		rb08.AddForce(firePoint315.up * bulletForce, ForceMode2D.Impulse);

		//yield return new WaitForSeconds(5);
		ExampleCoroutine();

    }


void shootb1()
{
	GameObject bullet01 = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
	Rigidbody2D rb01 = bullet01.GetComponent<Rigidbody2D>();
	rb01.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
}


void shootb2()
{
	GameObject bullet02 = Instantiate(bulletPrefab, firePointRight.position, firePointRight.rotation);
	Rigidbody2D rb02 = bullet02.GetComponent<Rigidbody2D>();
	rb02.AddForce(firePointRight.up * bulletForce, ForceMode2D.Impulse);
}



void shootb3()
{
	GameObject bullet03 = Instantiate(bulletPrefab, firePointDown.position, firePointDown.rotation);
	Rigidbody2D rb03 = bullet03.GetComponent<Rigidbody2D>();
	rb03.AddForce(firePointDown.up * bulletForce, ForceMode2D.Impulse);
}



void shootb4()
{
	GameObject bullet04 = Instantiate(bulletPrefab, firePointLeft.position, firePointLeft.rotation);
	Rigidbody2D rb04 = bullet04.GetComponent<Rigidbody2D>();
	rb04.AddForce(firePointLeft.up * bulletForce, ForceMode2D.Impulse);

}


void shootb5()
{
	GameObject bullet05 = Instantiate(bulletPrefab, firePoint45.position, firePoint45.rotation);
	Rigidbody2D rb05 = bullet05.GetComponent<Rigidbody2D>();
	rb05.AddForce(firePoint45.up * bulletForce, ForceMode2D.Impulse);

}



void shootb6()
{
	GameObject bullet06 = Instantiate(bulletPrefab, firePoint135.position, firePoint135.rotation);
	Rigidbody2D rb06 = bullet06.GetComponent<Rigidbody2D>();
	rb06.AddForce(firePoint135.up * bulletForce, ForceMode2D.Impulse);
}



void shootb7()
{
	GameObject bullet07 = Instantiate(bulletPrefab, firePoint225.position, firePoint225.rotation);
	Rigidbody2D rb07 = bullet07.GetComponent<Rigidbody2D>();
	rb07.AddForce(firePoint225.up * bulletForce, ForceMode2D.Impulse);

}


void shootb8()
{
	GameObject bullet08 = Instantiate(bulletPrefab, firePoint315.position, firePoint315.rotation);
	Rigidbody2D rb08 = bullet08.GetComponent<Rigidbody2D>();
	rb08.AddForce(firePoint315.up * bulletForce, ForceMode2D.Impulse);

}


IEnumerator ExampleCoroutine()
{

    //yield on a new YieldInstruction that waits for 5 seconds.
    yield return new WaitForSeconds(5);

}

void OnCollisionEnter2D(Collision2D collision)
{
    Debug.Log("Hit object: (from Shooting)" + collision.gameObject.name);

    Physics2D.IgnoreLayerCollision(8, 8);
	Physics2D.IgnoreLayerCollision(9, 11);

	}

}
