
using System;
using UnityEngine;

public class FlagScript : MonoBehaviour
{

    [SerializeField] private Collider2D coll;
    [SerializeField] private Animator anim;
    private static readonly int IsTouched = Animator.StringToHash("IsTouched");


    // Start is called before the first frame update
    void Start()
    {
           
        
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (playerScript.points == 12)
            {
                anim.SetBool(IsTouched, true);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
