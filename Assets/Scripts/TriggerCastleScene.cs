using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCastleScene : MonoBehaviour
{
    public GameObject Unity;
    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Testing castle door collider");
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(Unity.transform.position, this.transform.position) < 50f)
        {
            Debug.Log("Collision!");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        
    }
}
