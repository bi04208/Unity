using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private static Player instance;

    public static Player Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<Player>();
            }
            return instance;
        }
    }

    public static int life;
    private Rigidbody2D m_RigidBody;
    private Animator m_Animator;
    private bool facing_Right;
    private Collider2D player_Collider;

    [SerializeField]
    private Transform[] groundPoints;
    [SerializeField]
    private float groundRadius;
    [SerializeField]
    private LayerMask whatIsGrounded;

    [SerializeField]
    private float JumpForce;

    private static bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        m_RigidBody = GetComponent<Rigidbody2D>();
        m_Animator = GetComponent<Animator>();
        player_Collider = GetComponent<Collider2D>();
        facing_Right = true;
        life = 3;
        Debug.Log("START");
    }

    // Update is called once per frame
    void Update()
    {
        while (life > 0)
        {
            float horizontal = Input.GetAxis("Horizontal");

            OnTriggerEnter2D(player_Collider);
            isGrounded = IsGrounded();
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                this.transform.Translate(new Vector2(-2.0f * Time.deltaTime, 0.0f));
                Flip_Player(horizontal);
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                this.transform.Translate(new Vector2(2.0f * Time.deltaTime, 0.0f));
                Flip_Player(horizontal);
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (isGrounded)
                {
                    isGrounded = false;
                    m_RigidBody.AddForce(new Vector2(0, JumpForce));
                    m_Animator.SetTrigger("Jump");
                }
            }
        }
    }

    private void Flip_Player(float horizontal)
    {
        if (((horizontal > 0) && !facing_Right) || (horizontal < 0 && facing_Right))
        {
            facing_Right = !facing_Right;
            Vector2 Scale = transform.localScale;
            Scale.x *= -1;
            transform.localScale = Scale;
        }
    }

    private bool IsGrounded()
    {
        if (m_RigidBody.velocity.y <= 0)
        {
            foreach (Transform point in groundPoints)
            {
                Collider2D[] colliders = Physics2D.OverlapCircleAll(point.position, groundRadius, whatIsGrounded);

                for (int i = 0; i < colliders.Length; i++)
                {
                    if (colliders[i].gameObject != gameObject)
                        return true;
                }
            }
        }
        return false;
    }

    private void HandleLayers()
    {
        if (!isGrounded)
        {
            m_Animator.SetLayerWeight(1, 1);
        }
        else
        {
            m_Animator.SetLayerWeight(1, 0);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bomb")
        {
            if (life > 0)
                life -= 1;
            Debug.Log(life);
        }
        if(collision.gameObject.tag=="Clover")
        {
            if (life < 5)
                life += 1;
            Debug.Log(life);
        }
    }

}
