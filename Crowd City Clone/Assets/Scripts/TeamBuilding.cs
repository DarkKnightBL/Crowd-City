using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamBuilding : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyPatrol>().patrol = false;
            collision.gameObject.GetComponent<EnemyPatrol>().captured = true;
            collision.gameObject.GetComponent<EnemyPatrol>().player = this.gameObject.transform;
            collision.gameObject.transform.GetChild(1).GetComponent<SkinnedMeshRenderer>().material = transform.GetChild(1).GetComponent<SkinnedMeshRenderer>().material;

        }
    }
}
