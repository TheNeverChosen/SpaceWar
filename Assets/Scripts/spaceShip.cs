using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spaceShip : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator animator;
    public float speed;
    public GameObject explosion;
    public GameObject shot;
    public Transform cannon;
    public float health;
    bool invencible = true;
    bool shooting = false;
    SpriteRenderer renderer;

    void Start()
    {
        renderer = GetComponentInChildren<SpriteRenderer>();
        StartCoroutine(Invencibility());
    }

    IEnumerator Invencibility()
    {
        invencible = true;
        yield return new WaitForSeconds(3);
        invencible = false;
        renderer.color = Color.white;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Shoot();
        }
        if (invencible)
        {
            Color color = renderer.color;
            color.a = Mathf.Repeat(Time.time, .2f);
            renderer.color = color;
        }

        float h = Input.GetAxis("Horizontal"), v=Input.GetAxis("Vertical");

        Vector3 pos = transform.position;

        animator.SetFloat("horizontal", h);
        animator.SetFloat("vertical", v);

        pos.x += speed * h * Time.deltaTime;
        pos.y += speed * v * Time.deltaTime;

        transform.position = pos;
    }

    void Shoot()
    {
        if (shooting)
        {
            return;
        }
        shooting = true;
        Instantiate(shot, cannon.position, cannon.rotation);
        StartCoroutine(Cooldown());
    }

    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(shot.GetComponent<Shoot>().rate);
        shooting = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (invencible)
        {
            return;
        }

        Stone stone = collision.GetComponent<Stone>();
        if (stone)
        {
            StartCoroutine(Damage(stone.damage));
        }
    }

    IEnumerator Damage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Death();
        }
        for(int i = 0; i < 2; i++)
        {
            renderer.color = Color.red;
            yield return new WaitForSeconds(0.1f);
            renderer.color = Color.white;
            yield return new WaitForSeconds(0.1f);
        }
    }

    void Death()
    {
        GameObject exp = Instantiate(explosion, transform.position, transform.rotation);
        Destroy(exp, 1);
        Destroy(gameObject);
        FindObjectOfType<spawn>().SpawnShip();
    }
}
