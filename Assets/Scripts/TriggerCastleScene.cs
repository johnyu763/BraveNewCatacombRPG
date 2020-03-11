using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCastleScene : MonoBehaviour
{
    public GameObject Unity;
    private Animator anim;
    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        Debug.Log("Testing castle door collider");
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(Unity.transform.position, this.transform.position) < 65f)
        {
            Debug.Log("Collision!");
            anim.SetTrigger("OpenDoor");

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        
    }
}
