using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public List<Transform> playerPositions = new List<Transform>();
    Animator anim;
    public GameObject bulletPrefab;
    public Transform shootPoint;
    public float shootInterval;
    private float shootTimer;

    void Start()
    {
        transform.position = playerPositions[1].position;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();
    }
    void FixedUpdate()
    {
        Movement();
    }

    void Movement()
    {
        if (Input.GetMouseButtonDown(0))
        {
            /* Player Movement Using Raycast */

            Vector3 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);


            RaycastHit2D rayOut = Physics2D.Raycast(worldPoint, Vector2.zero);

            if (rayOut.collider != null)
            {
                /* Lane Detection */
                if (rayOut.collider.name == "Lane1")
                {
                    transform.position = playerPositions[0].position;
                }
                else if (rayOut.collider.name == "Lane2")
                {
                    transform.position = playerPositions[1].position;
                }
                else if (rayOut.collider.name == "Lane3")
                {
                    transform.position = playerPositions[2].position;
                }
            }
        }
    }

    void Shoot()
    {
        shootTimer -= Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space) && shootTimer <= 0)
        {
            anim.SetTrigger("Fire");
            GameObject bulletObject = Instantiate(bulletPrefab, shootPoint.position, Quaternion.identity);
            Bullet bullet = bulletObject.GetComponent<Bullet>();
            bullet.launch(transform.right, 300);
            shootTimer = shootInterval;

        }

    }
}
