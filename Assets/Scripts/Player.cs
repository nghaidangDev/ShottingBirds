using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float fireRate;
    float curFire;
    bool isShooted = false;

    public GameObject viewFinder;
    GameObject viewFinderClone;

    private void Awake()
    {
        curFire = fireRate;
    }

    private void Start()
    {
        if (viewFinder)
        {
            viewFinderClone = Instantiate(viewFinder, Vector2.zero, Quaternion.identity);
        }
    }

    private void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButton(0) && !isShooted)
        {
            Shoot(mousePos);
        }

        if (isShooted)
        {
            curFire -= Time.deltaTime;

            if (curFire <= 0)
            {
                isShooted = false;

                curFire = fireRate;
            }
        }

        if (viewFinderClone)
        {
            viewFinderClone.transform.position = new Vector3(mousePos.x, mousePos.y, 0);
        }
    }

    void Shoot(Vector3 mousePos)
    {
        isShooted = true;

        Vector3 shootDir = Camera.main.transform.position - mousePos;
        
        //gán độ dài của shootDir = 1 nhưng vẫn giữ nguyên hướng của nó.
        shootDir.Normalize();

        //Tạo mảng lưu các thành phần của hits khi bắt va chạm từ raycast.
        RaycastHit2D[] hits = Physics2D.RaycastAll(mousePos, shootDir);

        if (hits != null && hits.Length > 0)
        {
            for (int i = 0; i < hits.Length; i++)
            {
                RaycastHit2D hit = hits[i];

                //Nếu lấy đc hit và khoảng cách của hit đến mousePos <= 0.4 
                if (hit.collider && Vector3.Distance((Vector2)hit.collider.transform.position, (Vector2)mousePos) <= 0.4f)
                {
                    Debug.Log(hit.collider.name);
                }
            }
        }
    }
}
