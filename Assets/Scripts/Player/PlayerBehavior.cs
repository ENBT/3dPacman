using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{

    public static int health = 100;
    public static int energy = 100;
    public static bool invincible = false;
    public static bool mega = false;

    private float timer1 = 0;
    private float timer2 = 0;
    private bool crouching = false;
    private float fallSpeed = 1;

	[SerializeField]
	Transform playerModel;

    CharacterController body;
    Vector3 inp = Vector3.zero;

    [SerializeField]
    float movespeed;

    [SerializeField]
    float jumpheight;

    [SerializeField]
    float gravity;

    // Use this for initialization
    void Start()
    {
        body = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        move();
        glide();
        crouch();
        invincibility();
        megaChomp();
        Debug.Log(energy);
        if (mega == true)
            megaTimer();
    }

    void move()
    {
        inp.x = Input.GetAxis("Vertical");
        inp.x *= movespeed;
        inp = transform.TransformDirection(inp.x, inp.y, 0);



        if (body.isGrounded)
        {
            inp.y = 0;
            if (Input.GetKey(KeyCode.Space))
            {
                jump();
            }
        }

        transform.Rotate(0, Input.GetAxis("Horizontal") * 1.5f, 0);

        if (!body.isGrounded)
            inp.y -= gravity * Time.deltaTime * fallSpeed;
        body.Move(inp * Time.deltaTime);
    }

    void jump()
    {
        inp.y += jumpheight;
    }

    void crouch()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            if (crouching == false)
            {
                movespeed *= 0.75f;
				playerModel.localScale = new Vector3(1, .5f, 1);
                SphereCollider sphere = transform.GetComponent<SphereCollider>();
                sphere.radius *= 0.3f;
                body.radius *= 0.3f;
            }
            crouching = true;
        }
        if(Input.GetKeyUp(KeyCode.LeftControl))
        {
            if (crouching == true)
            {
                movespeed /= 0.75f;
				playerModel.localScale = new Vector3(1, 1.0f, 1);
				SphereCollider sphere = transform.GetComponent<SphereCollider>();
                sphere.radius = 0.5f;
                body.radius = 0.5f;
            }
            crouching = false;
        }

    }

    void glide()
    {
        if (!body.isGrounded && Input.GetKey(KeyCode.Space) && inp.y < 0)
        {
            fallSpeed = 0.01f;
        }

        if (Input.GetKeyUp(KeyCode.Space) || body.isGrounded)
        {
            fallSpeed = 1.0f;
        }
    }

    void megaChomp()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && energy == 100)
        {
            mega = true;
            movespeed /= 2;
            energy = 0;
            timer2 = Time.time;
        }
    }

    void megaTimer()
    {
        if (Time.time - timer2 >= 5)
        {
            mega = false;
            movespeed *= 2;
            energy = 100;
        }
    }

    void invincibility()
    {
        if (invincible == true && Time.time - timer1 >= 5)
            invincible = false;
    }

    void OnCollisionEnter(Collision c)
    {
        if (c.gameObject.tag == "GoodPellet")
        {
            //gain points
            Destroy(c.gameObject);
        }
        if (c.gameObject.tag == "BadPellet")
        {
            damagePlayer(5);
            Destroy(c.gameObject);
        }
        if (c.gameObject.tag == "Fruit")
        {
            //heal player
            //gain points
            Destroy(c.gameObject);
        }
        if (c.gameObject.tag == "Super" && mega == true)
        {
            timer1 = Time.time;
            invincible = true;
            Destroy(c.gameObject);
        }
        if (c.gameObject.tag == "Enemy")
        {
            damagePlayer(25);
            Destroy(c.gameObject);                      // REPLACE WITH ENEMY INTERACTION
        }
    }

    //Test
    public static void damagePlayer(int dmg)
    {
        health -= dmg;
        if (health < 0)
            health = 0;
    }
}
