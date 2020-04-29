using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    //組件
    public Rigidbody2D _rigidbody2D;
    public SpriteRenderer _spriteRenderer;
    public Animator _animator;
    public GameObject mystic_missle;
    //屬性
    public float Speed = 8.0f;
    public float JumpForce = 20.0f; 
    public bool OnGround;
    //技能
    public int SkillZCD = 0, SkillXCD = 0, SkillCCD = 0, SkillVCD = 0;
    Random Random = new Random();
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        jump();
        walk();
        skillZ();
        skillC();
    }
    void walk()//走路
    {
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
        {
            if (Input.GetKey(KeyCode.D))
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                _rigidbody2D.velocity = new Vector2(Speed, _rigidbody2D.velocity.y);
            }
            if (Input.GetKey(KeyCode.A))
            {
                 transform.eulerAngles = new Vector3(0, 180, 0);
                 _rigidbody2D.velocity = new Vector2(-Speed, _rigidbody2D.velocity.y);
            }
            _animator.SetBool("H1_IsWalking", true);
        }
        else if(!Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
        {
            _animator.SetBool("H1_IsWalking", false);
        }
    }
    void jump()//跳
    {
        if (Input.GetKey(KeyCode.W) && OnGround)
        {
            _rigidbody2D.velocity = new Vector2(0, JumpForce);
            _animator.SetBool("H1_IsJumping", true);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)//落地
    {
        if (collision.gameObject.tag == "Ground")
        {
            _animator.SetBool("H1_IsJumping", false);
        }
    }
    void skillZ()//Z技能
    {
        if (Input.GetKey(KeyCode.Z) && SkillZCD <= 0)
        {
            _animator.SetTrigger("H1_SkillZ");
            for (int i = 0; i < 3; i++)
            {
                GameObject gameObject = Instantiate(mystic_missle, new Vector2(transform.position.x + 1.2f * (transform.eulerAngles.y - 90) / -90 + Random.Range(-0.1f, 0.4f), transform.position.y + Random.Range(0, 0.6f)), new Quaternion(0, 0, 0, 0));
                gameObject.transform.eulerAngles = transform.eulerAngles;
            }
            SkillZCD = 2;
            StartCoroutine(CDtimer());
        }
    }
    void skillC()//C技能
    {
        if (Input.GetKey(KeyCode.C) && SkillCCD <=0)
        {
            _rigidbody2D.constraints = RigidbodyConstraints2D.FreezeAll;
            _animator.SetTrigger("H1_SkillC");
            StartCoroutine(Wizard_SkillC());
            SkillCCD = 5;
            StartCoroutine(CDtimer());
        }
        
    }
    IEnumerator Wizard_SkillC()
    {
        yield return new WaitForSeconds(0.5f);
        if(_animator.GetBool("H1_IsWalking") == true)
        {
            transform.Translate(new Vector2(10, 0));
        }
        /*else if ()
        {
            transform.Translate(new Vector2(0, 8));
        }*/
        else
        {
            transform.Translate(new Vector2(0, 8));
        }
        yield return new WaitForSeconds(0.3f);
        _rigidbody2D.constraints = RigidbodyConstraints2D.None | RigidbodyConstraints2D.FreezeRotation;
    }
    IEnumerator CDtimer()
    {
        while (SkillZCD > 0)
        {
            yield return new WaitForSeconds(1);
            SkillZCD -= 1;
            //Debug.Log("Z = " + SkillZCD);
        }
        while (SkillXCD > 0)
        {
            SkillXCD -= 1;
            yield return new WaitForSeconds(1);
        }
        while (SkillCCD > 0)
        {
            SkillCCD -= 1;
            yield return new WaitForSeconds(1);
            //Debug.Log("C = " + SkillCCD);
        }
        while (SkillVCD > 0)
        {
            SkillVCD -= 1;
            yield return new WaitForSeconds(1);
        }
    }
}
