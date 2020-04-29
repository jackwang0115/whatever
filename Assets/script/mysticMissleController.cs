using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mysticMissleController : MonoBehaviour
{
    public Rigidbody2D _rigidbody2D;

    public float speed = 20.0f;
    public bool Move;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        Move = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Move)
        {
            if (Mathf.Abs(transform.position.x) < 50)   
            {
                _rigidbody2D.velocity = new Vector2(speed*((transform.eulerAngles.y - 90) / -90), _rigidbody2D.velocity.y);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
    void MoveStart()
    {
        Move = true;
    }
    void OnCollisionEnter2D(Collision2D collision)//撞到東西
    {
        if(collision.gameObject.tag != "player1" && collision.gameObject.tag != "projectile")
        {
            Destroy(gameObject);
        }
    }
}
