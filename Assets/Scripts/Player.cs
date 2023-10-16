using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float linealForce; //mover en linea recta
    public float angularForce; //Rotar
    public float jumpForce;
    public float maxiumhealth;
    public float health;
    private Rigidbody2D rb;

    private Cannon[] cannons;


    float axisH;
    float axisV;
    
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.LogError($"No se  encontro el componente {nameof(rb)}");
        }

        cannons = GetComponentsInChildren<Cannon>();


    }

    
    void Update()
    {
        axisH = Input.GetAxisRaw("Horizontal");
        axisV = Input.GetAxisRaw("Vertical");

        

        if (Input.GetKeyDown(KeyCode.F))
        {
            for (int i = 0; i < cannons.Length; i++)
            {

                cannons[i].Shoot();

            }

        }



    }



    private void FixedUpdate()
    {
        

        

        rb.AddRelativeForce(linealForce * axisV * Vector2.up);

       
        rb.AddTorque(-angularForce * axisH);

    }

    private GameObject collideWith;


    private void OnCollisionEnter2D(Collision2D collision)
    {

        Debug.Log("Entre en " + collision.gameObject);





    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log("Estoy en " + collision.gameObject);
    }


    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("Sali de " + collision.gameObject);
        if (collideWith == collideWith.gameObject)
        {

            collision = null;

        }
    }


    public void TakeDamage(int damage)
    {

        health -= damage;

        if (health <= 0)
        {
            print("Me mori");
        }
        else
        {
            print("Me lastimaron " + health);
        }
    }


    public bool TakeHealing(int healing)
    {

        if (health == maxiumhealth)
        {
            return false;
        }

        //health = Mathf.Min(health + healing, maxiumhealth);
        health += healing;
        if (health > maxiumhealth)
        {
            health = maxiumhealth;
        }
        Debug.Log("Me sanaron " + health);
        return true;

    }
}
