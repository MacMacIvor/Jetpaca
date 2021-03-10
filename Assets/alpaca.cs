using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class alpaca : MonoBehaviour
{
    float speed = 10;
    
    public GameObject Alpaca;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            Alpaca.transform.position += Vector3.up  * speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            Alpaca.transform.position += Vector3.down * speed * Time.deltaTime;
        }

        //Don't let the alpaca go off the screen
        Vector3 pos = Camera.main.WorldToViewportPoint(Alpaca.gameObject.transform.position);
        pos.y = Mathf.Clamp(pos.y, 0.05f, 0.95f);
        Alpaca.gameObject.transform.position = Camera.main.ViewportToWorldPoint(pos);

        

    }
}
