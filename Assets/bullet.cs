using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public LayerMask enemyLayer;
    public LayerMask wallLayer;

    enum bulletState
    {

        ACTIVE,
        INACTIVE
    }

    public GameObject alpaca;

    bulletState state = bulletState.INACTIVE;

    public float bulletSpeed = 5.0f;
    public Vector3 dirPos;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
        switch (state)
        {
            case bulletState.ACTIVE:
                transform.position += dirPos * bulletSpeed * Time.deltaTime;
                if (Camera.main.WorldToViewportPoint(transform.position).x < 0 || Camera.main.WorldToViewportPoint(transform.position).x > 1 || Camera.main.WorldToViewportPoint(transform.position).y < 0 || Camera.main.WorldToViewportPoint(transform.position).y > 1)
                {
                    bulletManager.singleton.resetBullet(transform.gameObject);
                }
                
                break;
        }
        
    }

    public void changeActive(Vector3 initPos)
    {
        switch (state)
        {
            case bulletState.ACTIVE:
                gameObject.transform.position = initPos;
                state = bulletState.INACTIVE;
                break;
            case bulletState.INACTIVE:
                soundManager.soundsSingleton.playSoundEffect(Random.Range(4, 7));

                state = bulletState.ACTIVE;

                gameObject.transform.position = initPos;

                dirPos = alpaca.transform.position;

                dirPos = new Vector3(transform.position.x - dirPos.x, transform.position.y - dirPos.y, 0);

                dirPos = Vector3.Normalize(dirPos);
                
                transform.LookAt(transform.position + dirPos);

                break;
        }
    }

    public bool isActive()
    {
        switch (state)
        {
            case bulletState.ACTIVE:
                return true;
                break;
            case bulletState.INACTIVE:
                return false;
                break;
        }
        return true;
    }
    public void increaseSpeed(float amount)
    {
        bulletSpeed *= amount;
    }
}
