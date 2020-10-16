using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    public float moveSpeed;
    private bool canMove = true;
    Rigidbody2D rigid;
    Animator anim;
    Animation animTime;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (canMove)
        {
            Vector2 position = rigid.position;
            position.x = position.x - moveSpeed * Time.deltaTime;
            rigid.MovePosition(position);
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            canMove = false;
            Destroy(other.gameObject);
            anim.SetTrigger("Death");
            Destroy(this.gameObject, 2.5f);
        }

        else if (other.CompareTag("Spikes"))
        {
            Destroy(gameObject);
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        Debug.Log("OnCollisionEnter");
       
    }

}
