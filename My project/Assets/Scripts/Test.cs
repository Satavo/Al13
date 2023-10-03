using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public Transform EndPoint;
    public Transform EndPoint2;
    public Transform EndPoint3;

    private Transform currentTarget = null; // Текущий целевой EndPoint

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && currentTarget == null)
        {
            currentTarget = EndPoint;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) && currentTarget == null)
        {
            currentTarget = EndPoint2;
        }

        if (Input.GetKeyDown(KeyCode.Alpha3) && currentTarget == null)
        {
            currentTarget = EndPoint3;
        }

        if (currentTarget != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, currentTarget.position, Time.deltaTime);

            // Если достигли целевой точки
            if (Vector3.Distance(transform.position, currentTarget.position) < 0.001f)
            {
                currentTarget = null; // Останавливаем движение
            }
        }
    }
}
