using UnityEngine;
public class Player : MonoBehaviour
{
    [Header("Player Settings")]
    public float linealForce; //mover en linea recta
    public float angularForce; //Rotar
    public float maxiumhealth = 15f;
    public float health = 15f;
    private Rigidbody2D rb;
    private Animator animator;
    private Cannon[] cannons;
    private int idMoving = Animator.StringToHash("isMoving");

    [Header("Menu Settings")]
    public Canvas menu;

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
        animator = GetComponent<Animator>();
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


    private void LateUpdate()
    {
        animator.SetBool(idMoving, axisH != 0 || axisV != 0);
    }

    public void TakeDamage(int amount)
    {
        health -= amount;

        if (health <= 0)
        {
            print("Me mori");
            Destroy(gameObject);
        }
        else
        {
            print("Me lastimaron, vida actual: " + health);
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
