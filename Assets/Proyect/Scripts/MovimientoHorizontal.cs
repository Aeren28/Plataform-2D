using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoHorizontal : MonoBehaviour
{
    public float velocidad_grounded = 10;
    public float velocidad_air;
    public enum Direccion { LEFT, RIGHT };
    public Direccion dir;
    Animator anim;
    GroundDetector ground;
    // Start is called before the first frame update
    void Start()
    {
        ground = GetComponent<GroundDetector>();
        anim = GetComponent<Animator>();
        dir = Direccion.RIGHT;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");

        anim.SetBool("grounded", ground.grounded);
        anim.SetBool("moving", horizontal != 0);

        if(ground.grounded == true)
        {
            horizontal = horizontal * velocidad_grounded;
        }
        else
        {
            horizontal = horizontal * velocidad_air;
        }
        if(horizontal > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
            dir = Direccion.RIGHT;
        }
        if(horizontal < 0)
        {
            dir = Direccion.LEFT;
            transform.localScale = new Vector3(-1, 1, 1);
        }
        transform.position = transform.position + new Vector3(horizontal * Time.deltaTime, 0, 0);
    }
}
