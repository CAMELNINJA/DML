using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHelf : MonoBehaviour
{
    [SerializeField]
    private int _Helf;
    [SerializeField]
    private int _damage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   public void Damage()
    {
        _Helf -= _damage;
        if (_Helf<=0) 
        {
            Destroy(gameObject);
        }
    }

    
}
