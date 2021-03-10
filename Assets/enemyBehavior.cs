using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBehavior : MonoBehaviour
{

    enum enemyState
    {
        ACTIVE,
        INACTIVE
    }


    enum enemyType
    {
        BEAR,
        COYOTE
    }

    enemyState state = enemyState.ACTIVE;
    enemyType type = enemyType.BEAR;
    private int health = 0;
    private float speed = 3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case enemyState.ACTIVE:
                switch (type)
                {
                    case enemyType.BEAR:
                        break;
                    case enemyType.COYOTE:
                        transform.position = new Vector3(transform.position.x, transform.position.y + speed * Time.deltaTime, transform.position.z);
                        Vector3 pos = Camera.main.WorldToViewportPoint(gameObject.transform.position);
                        pos.y = Mathf.Clamp(pos.y, 0.05f, 0.95f);
                        if (pos.y == 0.05f && speed < 0 || pos.y == 0.95f && speed > 0)
                        {
                            speed *= -1;
                        }
                        transform.position = Camera.main.ViewportToWorldPoint(pos);
                        break;
                }
                
                break;
                
        }
        
    }

    public bool isActive()
    {
        switch (state)
        {
            case enemyState.ACTIVE:
                return true;
                break;
            case enemyState.INACTIVE:
                return false;
                break;
        }
        return true;
    }

    public void changeActive(bool trueFalse)
    {
        switch (trueFalse)
        {
            case false:
                state = enemyState.INACTIVE;
                break;
            case true:
                state = enemyState.ACTIVE;
                break;
        }
    }
    public void changeType(int newType)
    {
        switch (newType)
        {
            case 0:
                type = enemyType.BEAR;
                transform.position = new Vector3(transform.position.x, Random.Range(-4.5f, 4.5f), transform.position.z);
                health = 2;
                break;
            case 1:
                type = enemyType.COYOTE;
                transform.position = new Vector3(transform.position.x, Random.Range(-4.5f, 4.5f), transform.position.z);
                health = 1;
                break;
        }
    }

    public void takeDMG()
    {
        health--;
        if (health <= 0)
        {
            gameObject.transform.parent.GetComponent<monsterWall>().killWall();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.name == "Bullet(Clone)")
        {
            bulletManager.singleton.resetBullet(collision.gameObject.gameObject);
            takeDMG();
        }

    }
}
