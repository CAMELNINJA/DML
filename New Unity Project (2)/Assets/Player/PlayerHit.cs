using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : MonoBehaviour
{
    [SerializeField] 
    private KeyCode keyAttack; 
    [SerializeField] 
    private float speedRotate;

    private Quaternion target;

    private void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(keyAttack))
        {
            
            Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit, 1000f);
            if (hit.collider.name=="Enemy"  && Vector3.Distance(hit.point,transform.position)<=10)
            {
                hit.collider.GetComponent<EnemyHelf>().Damage();
            }
            Vector3 vec = hit.point - transform.position;
            Debug.DrawLine(transform.position,hit.point,Color.red,10f);
            target = Quaternion.LookRotation(new Vector3(vec.x, transform.rotation.y, vec.z), Vector3.up);
            
        }
        if (transform.rotation != target)
            transform.rotation = Quaternion.Lerp(transform.rotation, target, Time.deltaTime * speedRotate);
    }
}
