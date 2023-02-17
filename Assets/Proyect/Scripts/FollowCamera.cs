using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Camera cam;
    public Transform target;
    public GameObject player;
    public Vector3 offset;
    public float speed = 10;
    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (cam.transform.position.x >= -10.5 && cam.transform.position.x <= 6.5 && cam.transform.position.y <= 2.1 && cam.transform.position.y >= -3.25)
        {
            cam.transform.position = Vector3.Lerp(cam.transform.position, target.position + offset, Time.deltaTime * speed);
        }
        if (cam.transform.position.x < -10.5 && player.GetComponent<MovimientoHorizontal>().dir == MovimientoHorizontal.Direccion.RIGHT)
        {
            cam.transform.position += new Vector3(0.1f,0,0);
        }

        if (cam.transform.position.x > 6.5 && player.GetComponent<MovimientoHorizontal>().dir == MovimientoHorizontal.Direccion.LEFT)
        {
            cam.transform.position += new Vector3(-0.1f, 0, 0);
        }
        if (cam.transform.position.y > 2.1 && player.GetComponent<Jump>().fall == true)
        {
            cam.transform.position += new Vector3(0, -0.1f, 0);
        }
        if (cam.transform.position.y < -3.25 && player.GetComponent<Jump>().fall == true)
        {
            cam.transform.position += new Vector3(0, 0.1f, 0);
        }
    }
}
