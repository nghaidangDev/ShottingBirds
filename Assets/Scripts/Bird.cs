using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public float speedBird;
    public float maxY;
    public float minY;

    private Rigidbody2D rb;
    public GameObject deadVFX;

    private bool isLeftMoving;
    private bool isDead;

    private void Start()
    {
        BirdMovingDirection();
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rb.velocity = isLeftMoving ? new Vector2(-speedBird, Random.Range(minY, maxY)) 
            : new Vector2(speedBird, Random.Range(minY, maxY));
        Flip();
    }

    public void BirdMovingDirection()
    {
        isLeftMoving = transform.position.x > 0 ? true : false;
    }

    public void Flip()
    {
        if(isLeftMoving)
        {
            if (transform.localScale.x < 0) return;

            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        }
        else
        {
            if (transform.localScale.x > 0) return;

            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        }
    }

    public void Dead()
    {
        isDead = true;

        GameManager.Ins.BirdKilled++;

        Destroy(gameObject);

        if (deadVFX)
        {
            Instantiate(deadVFX, transform.position, Quaternion.identity);
        }
    }
}
