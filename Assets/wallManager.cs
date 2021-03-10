using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallManager : MonoBehaviour
{
    public static wallManager singleton;
    float initSpawnTimer = 2;
    float spawnTimer = 3;
    public void Awake()
    {
        if (singleton == null)
        {
            singleton = this;
            return;
        }
        Destroy(this);
    }

    public GameObject wallsa;
    public GameObject wallsb;
    public GameObject wallsc;
    public GameObject wallsd;
    public GameObject wallse;
    public GameObject wallsMonster;

    private Vector3 initWallSpawna;
    private Vector3 initWallSpawnb;
    private Vector3 initWallSpawnc;
    private Vector3 initWallSpawnd;
    private Vector3 initWallSpawne;
    private Vector3 initWallSpawnMonster;


    static List<GameObject> wallsHoldera;
    static List<GameObject> wallsHolderb;
    static List<GameObject> wallsHolderc;
    static List<GameObject> wallsHolderd;
    static List<GameObject> wallsHoldere;
    static List<GameObject> wallsHolderMonster;

    float maxWalls = 6;
    static int indexWallsa = 0;
    static int indexWallsb = 0;
    static int indexWallsc = 0;
    static int indexWallsd = 0;
    static int indexWallse = 0;
    static int indexWallsMonster = 0;

    // Start is called before the first frame update
    void Start()
    {
        initWallSpawna = wallsa.gameObject.transform.position;
        initWallSpawnb = wallsb.gameObject.transform.position;
        initWallSpawnc = wallsc.gameObject.transform.position;
        initWallSpawnd = wallsd.gameObject.transform.position;
        initWallSpawne = wallse.gameObject.transform.position;
        initWallSpawnMonster = wallsMonster.gameObject.transform.position;
        _BuildWallPool();
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer -= Time.deltaTime;
        if (spawnTimer <= 0)
        {
            int random = Random.Range(1, 15);
            switch (random)
            {
                case 1:
                    GetWalla();
                    break;
                case 2:
                    GetWallb();
                    break;
                case 3:
                    GetWallc();
                    break;
                case 4:
                    GetWalld();
                    break;
                case 5:
                    GetWalle();
                    break;
                case 6:
                case 7:
                case 8:
                case 9:
                case 10:
                case 12:
                case 13:
                case 14:
                case 15:
                case 16:
                case 17:
                case 18:
                case 19:
                case 20:
                case 21:
                case 22:
                case 23:
                case 24:
                case 25:
                case 26:
                case 27:
                case 28:
                case 29:
                case 30:
                    GetWallMonster();
                    break;
            }
            spawnTimer = initSpawnTimer;
        }
    }
    private void _BuildWallPool()
    {
        wallsHoldera = new List<GameObject>();
        for (int i = 0; i < maxWalls; i++)
        {
            GameObject newWalla = Instantiate(wallsa, this.transform);
            newWalla.transform.position = initWallSpawna;
            wallsHoldera.Add(newWalla);
        }
        wallsHolderb = new List<GameObject>();
        for (int i = 0; i < maxWalls; i++)
        {
            GameObject newWallb = Instantiate(wallsb, this.transform);
            newWallb.transform.position = initWallSpawnb;
            wallsHolderb.Add(newWallb);
        }
        wallsHolderc = new List<GameObject>();
        for (int i = 0; i < maxWalls; i++)
        {
            GameObject newWallc = Instantiate(wallsc, this.transform);
            newWallc.transform.position = initWallSpawnc;
            wallsHolderc.Add(newWallc);
        }
        wallsHolderd = new List<GameObject>();
        for (int i = 0; i < maxWalls; i++)
        {
            GameObject newWalld = Instantiate(wallsd, this.transform);
            newWalld.transform.position = initWallSpawnd;
            wallsHolderd.Add(newWalld);
        }
        wallsHoldere = new List<GameObject>();
        for (int i = 0; i < maxWalls; i++)
        {
            GameObject newWalle = Instantiate(wallse, this.transform);
            newWalle.transform.position = initWallSpawne;
            wallsHoldere.Add(newWalle);
        }
        wallsHolderMonster = new List<GameObject>();
        for (int i = 0; i < maxWalls; i++)
        {
            GameObject newWallMonster = Instantiate(wallsMonster, this.transform);
            newWallMonster.transform.position = initWallSpawnMonster;
            wallsHolderMonster.Add(newWallMonster);
        }
    }
    public GameObject GetWalla()
    {
        bool spawned = false;
        int indexStartedAt = indexWallsa;
        do
        {

            switch (wallsHoldera[indexWallsa].GetComponent<wallBehavior>().isActive())
            {
                case true:
                    indexWallsa++;
                    break;
                case false:
                    wallsHoldera[indexWallsa].gameObject.transform.position = initWallSpawna;
                    wallsHoldera[indexWallsa].gameObject.GetComponent<wallBehavior>().changeActive();
                    spawned = true;
                    break;
            }

            if (indexWallsa >= wallsHoldera.Count)
                indexWallsa = 0;
            if (indexWallsa == indexStartedAt)
            {
                //Resources used up so we will just not spawn anything
                spawned = true;
            }
        } while (spawned == false);
        return wallsHoldera[indexWallsa];
    }
    public GameObject GetWallb()
    {
        bool spawned = false;
        int indexStartedAt = indexWallsb;
        do
        {

            switch (wallsHolderb[indexWallsb].gameObject.GetComponent<wallBehavior>().isActive())
            {
                case true:
                    indexWallsb++;
                    break;
                case false:
                    wallsHolderb[indexWallsb].gameObject.transform.position = initWallSpawnb;
                    wallsHolderb[indexWallsb].gameObject.GetComponent<wallBehavior>().changeActive();
                    spawned = true;
                    break;
            }

            if (indexWallsb >= wallsHolderb.Count)
                indexWallsb = 0;
            if (indexWallsb == indexStartedAt)
            {
                //Resources used up so we will just not spawn anything
                spawned = true;
            }
        } while (spawned == false);
        return wallsHolderb[indexWallsb];
    }
    public GameObject GetWallc()
    {
        bool spawned = false;
        int indexStartedAt = indexWallsc;
        do
        {

            switch (wallsHolderc[indexWallsc].gameObject.GetComponent<wallBehavior>().isActive())
            {
                case true:
                    indexWallsc++;
                    break;
                case false:
                    wallsHolderc[indexWallsc].gameObject.transform.position = initWallSpawnc;
                    wallsHolderc[indexWallsc].gameObject.GetComponent<wallBehavior>().changeActive();
                    spawned = true;
                    break;
            }

            if (indexWallsc >= wallsHolderc.Count)
                indexWallsc = 0;
            if (indexWallsc == indexStartedAt)
            {
                //Resources used up so we will just not spawn anything
                spawned = true;
            }
        } while (spawned == false);
        return wallsHolderc[indexWallsc];
    }
    public GameObject GetWalld()
    {
        bool spawned = false;
        int indexStartedAt = indexWallsd;
        do
        {

            switch (wallsHolderd[indexWallsd].gameObject.GetComponent<wallBehavior>().isActive())
            {
                case true:
                    indexWallsd++;
                    break;
                case false:
                    wallsHolderd[indexWallsd].gameObject.transform.position = initWallSpawnd;
                    wallsHolderd[indexWallsd].gameObject.GetComponent<wallBehavior>().changeActive();
                    spawned = true;
                    break;
            }

            if (indexWallsd >= wallsHolderd.Count)
                indexWallsd = 0;
            if (indexWallsd == indexStartedAt)
            {
                //Resources used up so we will just not spawn anything
                spawned = true;
            }
        } while (spawned == false);
        return wallsHolderd[indexWallsd];
    }
    public GameObject GetWalle()
    {
        bool spawned = false;
        int indexStartedAt = indexWallse;
        do
        {

            switch (wallsHoldere[indexWallse].gameObject.GetComponent<wallBehavior>().isActive())
            {
                case true:
                    indexWallse++;
                    break;
                case false:
                    wallsHoldere[indexWallse].gameObject.transform.position = initWallSpawne;
                    wallsHoldere[indexWallse].gameObject.GetComponent<wallBehavior>().changeActive();
                    spawned = true;
                    break;
            }

            if (indexWallse >= wallsHoldere.Count)
                indexWallse = 0;
            if (indexWallse == indexStartedAt)
            {
                //Resources used up so we will just not spawn anything
                spawned = true;
            }
        } while (spawned == false);
        return wallsHoldere[indexWallse];
    }

    public GameObject GetWallMonster()
    {
        bool spawned = false;
        int indexStartedAt = indexWallsMonster;
        do
        {

            switch (wallsHolderMonster[indexWallsMonster].gameObject.GetComponent<monsterWall>().isActive())
            {
                case true:
                    indexWallsMonster++;
                    break;
                case false:
                    wallsHolderMonster[indexWallsMonster].gameObject.transform.position = initWallSpawnMonster;
                    wallsHolderMonster[indexWallsMonster].gameObject.GetComponent<monsterWall>().changeActive();
                    wallsHolderMonster[indexWallsMonster].gameObject.transform.GetChild(0).GetComponent<enemyBehavior>().changeType(Random.Range(0, 2));
                    //enemyManager.singleton.getEnemy(wallsHolderMonster[indexWallsMonster]);
                    spawned = true;
                    break;
            }

            if (indexWallsMonster >= wallsHolderMonster.Count)
                indexWallsMonster = 0;
            if (indexWallsMonster == indexStartedAt)
            {
                //Resources used up so we will just not spawn anything
                spawned = true;
            }
        } while (spawned == false);
        return wallsHolderMonster[indexWallsMonster];
    }

    public void ResetWall(GameObject wall)
    {
        switch (wall.gameObject.name)
        {
            case "WallA(Clone)":
                for (int i = 0; i < wallsHoldera.Count; i++)
                {
                    if (wall == wallsHoldera[i])
                    {
                        wallsHoldera[i].gameObject.transform.position = initWallSpawna;
                        wallsHoldera[i].gameObject.GetComponent<wallBehavior>().changeActive();
                    }
                }
                break;
            case "WallB(Clone)":
                for (int i = 0; i < wallsHolderb.Count; i++)
                {
                    if (wall == wallsHolderb[i])
                    {
                        wallsHolderb[i].gameObject.transform.position = initWallSpawnb;
                        wallsHolderb[i].gameObject.GetComponent<wallBehavior>().changeActive();
                    }
                }
                break;
            case "WallC(Clone)":
                for (int i = 0; i < wallsHolderc.Count; i++)
                {
                    if (wall == wallsHolderc[i])
                    {
                        wallsHolderc[i].gameObject.transform.position = initWallSpawnc;
                        wallsHolderc[i].gameObject.GetComponent<wallBehavior>().changeActive();
                    }
                }
                break;
            case "WallD(Clone)":
                for (int i = 0; i < wallsHolderd.Count; i++)
                {
                    if (wall == wallsHolderd[i])
                    {
                        wallsHolderd[i].gameObject.transform.position = initWallSpawnd;
                        wallsHolderd[i].gameObject.GetComponent<wallBehavior>().changeActive();
                    }
                }
                break;
            case "WallE(Clone)":
                for (int i = 0; i < wallsHoldere.Count; i++)
                {
                    if (wall == wallsHoldere[i])
                    {
                        wallsHoldere[i].gameObject.transform.position = initWallSpawne;
                        wallsHoldere[i].gameObject.GetComponent<wallBehavior>().changeActive();
                    }
                }
                break;
            case "WallMonster(Clone)":
                for (int i = 0; i < wallsHolderMonster.Count; i++)
                {
                    if (wall == wallsHolderMonster[i])
                    {
                        //if (wallsHolderMonster[indexWallsMonster].gameObject.transform.childCount != 0)
                        //    enemyManager.singleton.resetEnemy(wallsHolderMonster[indexWallsMonster].gameObject.transform.GetChild(0).gameObject);
                        wallsHolderMonster[i].gameObject.transform.position = initWallSpawnMonster;
                        wallsHolderMonster[i].gameObject.GetComponent<monsterWall>().changeActive();

                    }
                }
                break;
        }
        

    }
    public void increaseSpeed(float amount)
    {
        initSpawnTimer /= (amount * 0.94f);
        bulletManager.singleton.increaseSpeed(amount);
        for (int i = 0; i < 6; i++)
        {
            wallsHoldera[i].GetComponent<wallBehavior>().increaseSpeed(amount);
            wallsHolderb[i].GetComponent<wallBehavior>().increaseSpeed(amount);
            wallsHolderc[i].GetComponent<wallBehavior>().increaseSpeed(amount);
            wallsHolderd[i].GetComponent<wallBehavior>().increaseSpeed(amount);
            wallsHoldere[i].GetComponent<wallBehavior>().increaseSpeed(amount);
            wallsHolderMonster[i].GetComponent<monsterWall>().increaseSpeed(amount);
        }
    }
}
