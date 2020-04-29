using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundDetecter : MonoBehaviour
{
    public GameObject player1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionStay2D(Collision2D coll)//站在地上
    {
        if (coll.gameObject.tag == "Ground")
        {
            player1.GetComponent<playerController>().OnGround = true;
        }
        else
        {
            player1.GetComponent<playerController>().OnGround = false;
        }

    }
    void OnCollisionExit2D(Collision2D coll)//離開地面
    {
        if (coll.gameObject.tag == "Ground")
        {
            player1.GetComponent<playerController>().OnGround = false;
        }
    }
}
