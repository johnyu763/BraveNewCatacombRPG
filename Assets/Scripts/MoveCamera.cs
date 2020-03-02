using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public Moving Player;
    public Vector3 offset;
    private Animator anim;

    void Start()
    {
        offset = transform.position - Player.transform.position;
        anim = GetComponent<Animator>();
    }

    void LateUpdate()
    {
        var rot = Input.GetAxisRaw("Horizontal") * Time.deltaTime * 180;
        this.transform.RotateAround(Player.transform.position, Vector3.up,rot);
        offset = Quaternion.AngleAxis(rot, Vector3.up) * offset;
        transform.Translate(0f, 0f, 3 * Input.GetAxis("Vertical") * Time.deltaTime);
        transform.position = Player.transform.position + offset;
    }


}
