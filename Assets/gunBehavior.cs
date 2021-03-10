using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunBehavior : MonoBehaviour
{
    private Vector3 pointOffset;


    // Start is called before the first frame update
    void Start()
    {
        pointOffset = transform.position - gameObject.transform.parent.gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pointPosM = Camera.main.WorldToScreenPoint(gameObject.transform.parent.gameObject.transform.position);
        pointPosM = Input.mousePosition - pointPosM;
        float angle = Mathf.Atan2(pointPosM.y, pointPosM.x) * Mathf.Rad2Deg;
        pointPosM = Quaternion.AngleAxis(angle, new Vector3(0,1,0)) * (Vector3.right * pointOffset.x);
        transform.position = gameObject.transform.parent.gameObject.transform.position + new Vector3(pointPosM.x, -pointPosM.z, 0);
        transform.LookAt(gameObject.transform.parent.gameObject.transform.position);

        if (Input.GetMouseButtonDown(0))
        {
            //fireBullet
            bulletManager.singleton.getBullet(new Vector3(transform.position.x, transform.position.y, 0));
        }

    }
}
