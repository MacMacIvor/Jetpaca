using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallBehavior : MonoBehaviour
{
    enum wallState
    {
        ACTIVE,
        INACTIVE
    }
    wallState state = wallState.INACTIVE;
    float speed = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case wallState.ACTIVE:
                transform.position += Vector3.left * speed * Time.deltaTime;
                if (Camera.main.WorldToViewportPoint(transform.position).x < 0)
                {
                    wallManager.singleton.ResetWall(transform.gameObject);
                }
                break;
        }
    }

    public void changeActive()
    {
        switch (state)
        {
            case wallState.ACTIVE:
                state = wallState.INACTIVE;
                break;
            case wallState.INACTIVE:
                state = wallState.ACTIVE;
                break;
        }
    }
    public bool isActive()
    {
        switch (state)
        {
            case wallState.ACTIVE:
                return true;
                break;
            case wallState.INACTIVE:
                return false;
                break;
        }
        return true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log(collision.gameObject.name);
        if (collision.gameObject.name == "Bullet(Clone)")
        {
            bulletManager.singleton.resetBullet(collision.gameObject.gameObject);
        }
        else if (collision.gameObject.name == "Alpaca")
        {
            collision.gameObject.GetComponent<alpaca>().playerDies();
        }
    }
    public void increaseSpeed(float amount)
    {
        speed *= amount;
    }
}
