using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    private Rigidbody2D bomb_RigidBody;

    [SerializeField]
    private Transform[] TouchPoints;
    [SerializeField]
    private float TouchRadius;
    [SerializeField]
    private LayerMask whatIsTouched;

    private bool isTouched;
    // Start is called before the first frame update
    void Start()
    {
        Set_Position();
        bomb_RigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        isTouched = IsTouched();
        if (isTouched)
        {
            Set_Position();
        }
        else
        {
            this.transform.Translate(new Vector2(0.0f,Time.deltaTime * -5.0f));
        }
    }

    private bool IsTouched()
    {
        if(bomb_RigidBody.velocity.y<=0)
        {
            foreach(Transform point in TouchPoints)
            {
                Collider2D[] colliders = Physics2D.OverlapCircleAll(point.position, TouchRadius, whatIsTouched);

                for(int i=0;i<colliders.Length;i++)
                {
                    if (colliders[i].gameObject != gameObject)
                        return true;
                }
            }
        }
        return false;
    }

    private void Set_Position()
    {
        float[] rnd = new float[2];
        rnd[0] = Random.Range(-18.0f, 18.0f);
        rnd[1] = Random.Range(0.0f, 10.0f);
        this.transform.position = new Vector2(rnd[0], rnd[1]);
    }
}
