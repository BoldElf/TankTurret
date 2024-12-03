using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Zenject.Asteroids;

public class MiniBulletBehaviour : Bullet
{

    private void Update()
    {
        if(findGround == true)
        {
            timer += Time.deltaTime;
        }
        
        Move();
        Debug.Log(timer);

        timerToFly += Time.deltaTime;
    }

    private bool findGround = false;
    private float timer;
    private float timerToFly;

    private Rigidbody2D rb;
    protected override void Move()
    {
        //transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        //rb.AddForce(Vector3.right * moveSpeed * Time.deltaTime);

        //transform.Translate(0, -moveSpeed * Time.deltaTime, 0);

        //transform.eulerAngles += new Vector3(0, 0, -100 * Time.deltaTime);

        transform.position += transform.TransformDirection(Vector2.right) * Time.deltaTime * moveSpeed;
        /*
        gameObject.TryGetComponent<Rigidbody2D>(out rb);
        rb.AddForce(Vector2.right * Time.deltaTime * moveSpeed);
        */

        //transform.eulerAngles += new Vector3(0, 0, -100 * Time.deltaTime);

        
        if (findGround == false)
        {
            transform.eulerAngles += new Vector3(0, 0, -50 * Time.deltaTime);
        }
        
        if(timer < 0.3f && findGround == true)
        {
            transform.eulerAngles += new Vector3(0, 0, -50 * Time.deltaTime);
        }
        

        /*
        else
        {
            transform.eulerAngles += new Vector3(0, 0, -50 * Time.deltaTime);
        }
        */

        if (timerToFly >= 0.3f)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.right), Mathf.Infinity);

            if(hit.collider != null)
            {
                if (hit.collider.gameObject.tag == "Ground")
                {
                    Debug.Log(hit.collider);
                    findGround = true;
                }
        
            }
        }
        
       

    }

    protected override void Detonation()
    {
        bulletLifeSystem.RemoveProjectile(gameObject,0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Destroy");
        if (collision.gameObject.tag == "Ground")
        {
            Detonation();
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Destroy");
        if (collision.gameObject.tag == "Ground")
        {
            Detonation();
        }
    }
    
}
