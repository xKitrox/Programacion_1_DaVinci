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
    public AudioSource audioSource;
    public AudioClip fireSound, repairSound, damageSound, dieSound;
    private int idMoving = Animator.StringToHash("isMoving");
    public sceneLoader loader;


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
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        axisH = Input.GetAxisRaw("Horizontal");
        axisV = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown(KeyCode.F))
        {
            audioSource.PlayOneShot(fireSound);
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
        //play damage sound
        audioSource.PlayOneShot(damageSound);
        //reducir vida
        health -= amount;

        if (health <= 0)
        {
            //print("Me mori");
            Die();
            
        }
        else
        {
            //print("Me lastimaron, vida actual: " + health);
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
        //play audio repair
        audioSource.PlayOneShot(repairSound);

        //Debug.Log("Me sanaron " + health);
        return true;
    }

    //Die para destruir objeto
    public void Die()
    {
        audioSource.PlayOneShot(dieSound);
        Destroy(gameObject);
        loader.LoadScene("Lose");
    }
}
