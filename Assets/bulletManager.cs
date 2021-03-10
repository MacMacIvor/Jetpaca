using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletManager : MonoBehaviour
{
    public GameObject bullet;
    static List<GameObject> Bullets;

    public static bulletManager singleton = null;
    Vector3 hide = new Vector3(200, 100, 0);
    private void Awake()
    {
        if (singleton == null)
        {
            singleton = this;
            return;
        }
        Destroy(this);
    }

    public int maxBullets = 3;
    static int index = 0;

    // Start is called before the first frame update
    void Start()
    {
        _BuildBulletPool();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void _BuildBulletPool()
    {

        Bullets = new List<GameObject>();
        for (int i = 0; i < maxBullets; i++)
        {
            GameObject newBullet = Instantiate(bullet, this.transform);
            newBullet.transform.position = hide;
            Bullets.Add(newBullet);
        }

    }

    public GameObject getBullet(Vector3 pos)
    {
        bool spawned = false;
        int indexStartedAt = index;
        do
        {

            switch (Bullets[index].GetComponent<bullet>().isActive())
            {
                case true:
                    index++;
                    break;
                case false:
                    Bullets[index].GetComponent<bullet>().changeActive(pos);
                    spawned = true;
                    break;
            }

            if (index >= Bullets.Count)
                index = 0;
            if (index == indexStartedAt)
            {
                //Resources used up so we will just not spawn anything
                spawned = true;
            }
        } while (spawned == false);
        return Bullets[index];
    }


    public void resetBullet(GameObject bullet)
    {
        for (int i = 0; i < Bullets.Count; i++)
        {
            if (bullet == Bullets[i])
            {
                Bullets[i].GetComponent<bullet>().changeActive(hide);
            }
        }

    }
    public void increaseSpeed(float amount)
    {
        for (int i = 0; i < Bullets.Count; i++)
        {
            Bullets[i].GetComponent<bullet>().increaseSpeed(amount);
        }
    }
}
