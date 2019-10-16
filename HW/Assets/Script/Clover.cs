using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clover : MonoBehaviour
{
    private Rigidbody2D Clover_RigidBody;
    private Collider2D Clover_Collider;
    // Start is called before the first frame update

    void Start()
    {
        Set_Position();
        Clover_RigidBody = GetComponent<Rigidbody2D>();
        Clover_Collider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        OnTriggerEnter2D(Clover_Collider);
        this.transform.Translate(new Vector2(0.0f, Time.deltaTime * -5.0f));
        if (this.transform.position.y < -7)
            Set_Position();
    }

    private void Set_Position()
    {
        float[] rnd = new float[2];
        rnd[0] = Random.Range(-18.0f, 18.0f);
        rnd[1] = Random.Range(0.0f, 10.0f);
        this.transform.position = new Vector2(rnd[0], rnd[1]);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Player")
        {
            Set_Position();
        }
    }
}
