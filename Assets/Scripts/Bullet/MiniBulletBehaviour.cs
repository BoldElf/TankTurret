using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Zenject.Asteroids;

public class MiniBulletBehaviour : Bullet
{
    private bool findGround = false;
    private float timer;
    private float timerToFly;

    private void Update()
    {
        if(findGround == true)
        {
            timer += Time.deltaTime;
        }
        
        Move();

        timerToFly += Time.deltaTime;
    }

    protected override void Move()
    {
        transform.position += transform.TransformDirection(Vector2.right) * Time.deltaTime * moveSpeed;

        if (findGround == false)
        {
            transform.eulerAngles += new Vector3(0, 0, -50 * Time.deltaTime);
        }
        
        if(timer < 0.3f && findGround == true)
        {
            transform.eulerAngles += new Vector3(0, 0, -50 * Time.deltaTime);
        }

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
