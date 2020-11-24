using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D rb;
    public Rigidbody2D rbspray1;
    public Rigidbody2D rbspray2;
    public Rigidbody2D rbspray3;
    public Rigidbody2D rbspray4;
    public Rigidbody2D playerrb;
    public Transform firePoint;
    public Transform firePoint1;
    public Transform firePoint2;
    public Transform firePoint3;
    public Transform firePoint4;
    public Camera cam;
    public GameObject bulletPrefab;
    public GameObject bulletPrefab1;
    public GameObject bulletPrefab2;
    public GameObject bulletPrefab3;
    public GameObject bulletPrefab4;

    Vector2 movement;
    Vector2 mousePos;

    public float bulletForce = 0f;
    public float moveSpeed = 1f;

    private float nextActionTime = 0.0f;
    public float period = 0.1f;

    public float angle = 0;
    public float angle1 = 0;
    public float Degree = 0;

    public float moveForce = 1f;
    public float maxSpeed = 2f;
    public float Speed = 0f;
    public float Acceleration = 0.5f;
    public float Deceleration = 0.5f;
    private float timeAcceleration = 0;
    private float timeAccelerationSpray = 0;

    public int NumShooting = 0;
    public int NumShootingSpray = 0;
    public int MaxRoundShooting = 4;
    public int MaxRoundShootingSpray = 1;
    public float secondsToRest = 1;
    public float secondsToRestSpray = 5;
    public bool finWaiting = true;
    public bool finWaitingSpray = true;
    public float waitNextShootTime = 0;
    public float waitNextShootPeriod = 1;



    void Update()
    {
        gameObject.tag = "arrow";

        if (Input.GetButtonDown("Fire1"))
        {
            shoot(0);
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            frontSprayShoot();
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            frontSprayShootX3();

        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            shoot(0);
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            shoot(-30f);
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            shoot(-60f);
        }

        // shooting three bullets at a time 
        if (Input.GetKeyDown("space"))
		{
            Invoke("shoot", 1);
            Debug.Log("First bullet");
            Invoke("shoot", 1.5f);
            Debug.Log("Second bullet");
			Invoke("shoot", 2);
            Debug.Log("Third bullet");
        }

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);


        //if ((Input.GetKey("left")) && (Speed < maxSpeed))
        //    Speed = Speed - Acceleration * Time.deltaTime;
        //else if ((Input.GetKey("right")) && (Speed > -maxSpeed)) {
        //    Speed = Speed + Acceleration * Time.deltaTime;
        //}
        //else
        //{
        //    if (Speed > Deceleration * Time.deltaTime){
        //        Speed = Speed - Deceleration * Time.deltaTime;
        //    }
        //    else if (Speed < -Deceleration * Time.deltaTime){
        //        Speed = Speed + Deceleration * Time.deltaTime;
        //    }
        //    else {
        //        Speed = 0;
        //    }
        //}

        //rb.AddForce(firePoint.up * Speed, ForceMode2D.Impulse);

        //refreshshoot
        waitNextShootTime += Time.deltaTime;
        if (waitNextShootTime >= waitNextShootPeriod && !(Input.GetButtonDown("Fire1")))
        {
            NumShooting = 0;                                    // resetting after secondToRest
            NumShootingSpray = 0;
            waitNextShootTime = 0;

        }

        //fixing firepoint on player
        rb.position = playerrb.position;
        rbspray1.position = playerrb.position;
        rbspray2.position = playerrb.position;
        rbspray3.position = playerrb.position;
        rbspray4.position = playerrb.position;

        //firePoint.position = playerrb.position;
        //firePoint1.position = playerrb.position;
        //firePoint2.position = playerrb.position;
        //firePoint3.position = playerrb.position;
        //firePoint4.position = playerrb.position;


        Debug.Log("Time.time" + Time.time);
        Debug.Log("nextActionTime" + nextActionTime);
        Debug.Log("Time.delta" + Time.deltaTime);

    }

    void FixedUpdate()
    {

        Vector2 lookDir = mousePos - rb.position;
        angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f; //offseting
        rb.rotation = angle + Random.Range(-2f, 2f) + Degree;

        //rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);

    }

    void shoot(float degree)
    {
        Degree = degree;

        if (NumShooting <= MaxRoundShooting && finWaiting)
        {
            GameObject bullet = Instantiate(bulletPrefab, playerrb.position, firePoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

            Debug.Log("degree twisted: " + firePoint.rotation.z);

            if (Time.time > nextActionTime)
            {
                nextActionTime += period;
                // execute block of code here
                rb.AddForce(firePoint.up * (bulletForce), ForceMode2D.Impulse);
            }
            startWaitNextShootTimer();
            NumShooting++;
        }
        else if(NumShooting > MaxRoundShooting && finWaiting)
        {
            finWaiting = false;
            Debug.Log("NumShooting :" + NumShooting);
            StartCoroutine( waitSeconds(secondsToRest) );
        }

    }

    void frontSprayShoot()
    {

        bulletForce = 5;

        //timeAccelerationSpray = 0;

        firePoint1.rotation = Quaternion.Euler(firePoint1.rotation.x, firePoint1.rotation.y, firePoint1.rotation.z + angle + 15f);
        Debug.Log("x" + firePoint1.rotation.x + "y" + firePoint1.rotation.y + "z" + firePoint1.rotation.z);
        GameObject bulletspray1 = Instantiate(bulletPrefab1, playerrb.position, firePoint1.rotation);
        Rigidbody2D rbspray1 = bulletspray1.GetComponent<Rigidbody2D>();
        rbspray1.rotation = angle + 15f + Random.Range(-2f, 2f);
        Debug.Log("rbspray1.velocity in Spray" + rbspray1.velocity);

        //firePoint1.rotation = Quaternion.Euler(firePoint1.rotation.x, firePoint1.rotation.y, firePoint1.rotation.z + 30f);

        firePoint2.rotation = Quaternion.Euler(firePoint2.rotation.x, firePoint2.rotation.y, firePoint2.rotation.z + angle + 45f);
        GameObject bulletspray2 = Instantiate(bulletPrefab2, playerrb.position, firePoint2.rotation);
        Rigidbody2D rbspray2 = bulletspray2.GetComponent<Rigidbody2D>();
        rbspray2.rotation = angle + 45f + Random.Range(-2f, 2f);

        //firePoint2.rotation = Quaternion.Euler(firePoint2.rotation.x, firePoint2.rotation.y, firePoint2.rotation.z + 60f);

        firePoint3.rotation = Quaternion.Euler(firePoint3.rotation.x, firePoint3.rotation.y, firePoint3.rotation.z + angle - 15f);
        GameObject bulletspray3 = Instantiate(bulletPrefab3, playerrb.position, firePoint3.rotation);
        Rigidbody2D rbspray3 = bulletspray3.GetComponent<Rigidbody2D>();
        rbspray3.rotation = angle - 15f + Random.Range(-2f, 2f);
        //firePoint3.rotation = Quaternion.Euler(firePoint3.rotation.x, firePoint3.rotation.y, firePoint3.rotation.z - 30f);

        firePoint4.rotation = Quaternion.Euler(firePoint4.rotation.x, firePoint4.rotation.y, firePoint4.rotation.z + angle - 45f);
        GameObject bulletspray4 = Instantiate(bulletPrefab4, playerrb.position, firePoint4.rotation);
        Rigidbody2D rbspray4 = bulletspray4.GetComponent<Rigidbody2D>();
        rbspray4.rotation = angle - 45f + Random.Range(-2f, 2f);
        //firePoint4.rotation = Quaternion.Euler(firePoint4.rotation.x, firePoint4.rotation.y, firePoint4.rotation.z - 60f);


        if (Time.time > nextActionTime)
        {
            nextActionTime += period;
            timeAccelerationSpray += period;
            // execute block of code here
            Debug.Log("timeAccelerationSpray" + timeAccelerationSpray);

            rbspray1.AddForce(firePoint1.up * bulletForce, ForceMode2D.Impulse);
            rbspray2.AddForce(firePoint2.up * bulletForce, ForceMode2D.Impulse);
            rbspray3.AddForce(firePoint3.up * bulletForce, ForceMode2D.Impulse);
            rbspray4.AddForce(firePoint4.up * bulletForce, ForceMode2D.Impulse);

            Invoke("IncreaseBulletForce", 0.05f);
            Invoke("AddForce", 0.1f);
            Invoke("IncreaseBulletForce", 0.15f);
            Invoke("AddForce", 0.2f);
            Invoke("IncreaseBulletForce", 0.25f);
            Invoke("AddForce", 0.3f);
            Invoke("IncreaseBulletForce", 0.35f);
            Invoke("AddForce", 0.4f);
            Invoke("IncreaseBulletForce", 0.45f);
            Invoke("AddForce", 0.5f);
            //Invoke("IncreaseBulletForce", 0.7f);
            //Invoke("AddForce", 0.7f);
            //bulletForce += 10;
            //Invoke("AddForce", 0.4f);
            //bulletForce += 10;
            //Invoke("AddForce", 0.5f);
            //bulletForce += 10;
            //Invoke("AddForce", 0.6f);
            //bulletForce += 10;
            //Invoke("AddForce", 0.7f);
            //bulletForce += 10;
            //Invoke("AddForce", 0.8f);
            //Invoke("AddForce", 2);
            //bulletForce += 10;
            //Invoke("AddForce", 3);
            //bulletForce += 10;
            //Invoke("AddForce", 4);
            //bulletForce += 5;
            //Invoke("AddForce", 5);
            bulletForce = 5;

        }




        Destroy(bulletspray1,5);
                    Destroy(bulletspray2,5);
                    Destroy(bulletspray3,5);
                    Destroy(bulletspray4,5);



    }

    void AddForce() {
        Debug.Log("bulletForce" + bulletForce);
        rbspray1.AddForce(firePoint1.up * bulletForce, ForceMode2D.Force);
        rbspray2.AddForce(firePoint2.up * bulletForce, ForceMode2D.Force);
        rbspray3.AddForce(firePoint3.up * bulletForce, ForceMode2D.Force);
        rbspray4.AddForce(firePoint4.up * bulletForce, ForceMode2D.Force);
        rbspray1.velocity = firePoint1.up * bulletForce;
        rbspray2.velocity = firePoint2.up * bulletForce;
        rbspray3.velocity = firePoint3.up * bulletForce;
        rbspray4.velocity = firePoint4.up * bulletForce;


    }


    void IncreaseBulletForce()
    {
        bulletForce += 10;
    }


    void frontSprayShootX3()
    {

        if (NumShootingSpray < MaxRoundShootingSpray && finWaitingSpray)
        {
            NumShootingSpray++;
            Invoke("frontSprayShoot", 0);
            Invoke("frontSprayShoot", 0.25f);
            Invoke("frontSprayShoot", 0.5f);

            startWaitNextShootTimer();
            //NumShootingSpray++;
        }
        else if (NumShootingSpray >= MaxRoundShootingSpray && finWaitingSpray)
        {
            finWaitingSpray = false;
            Debug.Log("NumShootingSrapy :" + NumShootingSpray);
            StartCoroutine(waitSecondsSpray(secondsToRestSpray));
        }

    }

    void startWaitNextShootTimer()
    {
        waitNextShootTime = 0;
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Hit object: (from Movement)" + collision.gameObject.name);
        Physics2D.IgnoreLayerCollision(9, 11);
        Physics2D.IgnoreLayerCollision(8, 8);

    }


    IEnumerator waitSeconds(float seconds)
    {
        Debug.Log(" Wait start. ");
        yield return new WaitForSeconds(seconds);
        Debug.Log(" Wait is over.");
        NumShooting = 0;                                    // resetting after secondToRest
        finWaiting = true;
    }

    IEnumerator waitSecondsSpray(float seconds)
    {
        Debug.Log(" Wait start. ");
        yield return new WaitForSeconds(seconds);
        Debug.Log(" Wait is over.");
        NumShootingSpray = 0;                               // resetting after secondToRest
        finWaitingSpray = true;
    }

}
