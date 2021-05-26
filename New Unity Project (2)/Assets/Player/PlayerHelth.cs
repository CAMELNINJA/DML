using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHelth : MonoBehaviour
{
    [SerializeField] 
    private int _helth;

    [SerializeField]
    private int _damage;

    private float time=3;

    private float could=3;
    // Start is called before the first frame update
    

    private void OnTriggerStay(Collider other)
    {
        if (other.name == "Enemy")
        {
            if (Timer())
            {
                Damage();
                Debug.Log("Hit");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
      
    }

    private IEnumerator Coroutine(Collider other)
    { if (other.name == "Enemy")
        {
            while (true)
            {
                yield return new WaitForSeconds(10f);
                Damage(); 
                Debug.Log("Hit"); 
                
            }
           
        }
        else
        {
            yield return null;

        }
        
    }

    private void Damage()
    {
        _helth -= _damage;
        time = could;
        if (_helth <= 0)
        {
            Destroy(gameObject);
        }
    }

    private bool Timer()
    {
        if (time >= 0)
        {
            time -= Time.deltaTime;
            return false;
        }
        else
        {
            return true;
        } 
    }

    
}
