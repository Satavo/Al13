using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action_1 : MonoBehaviour
{
    public Transform EndPoint;

    private Transform currentTarget = null; // Текущий целевой EndPoint

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && currentTarget == null)
        {
            currentTarget = EndPoint;
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
