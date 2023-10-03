using UnityEngine;

public class FurnaceDoorController : MonoBehaviour
{
    public Transform furnaceBody; // ссылка на объект FurnaceBody.001
    public Transform mechanic;    // ссылка на объект Mechanic
    public Transform trolley;     // ссылка на объект Trolley

    private bool isOpen = false;
    private float rotationSpeed = 100f;
    private float targetAngle = 0f;

    private Vector3 mechanicTargetPosition; 
    private Vector3 trolleyTargetPosition;  

    void Start()
    {
        // Вычисляем целевые позиции на основе позиции furnaceBody. Вы можете настроить смещение по своему усмотрению
        mechanicTargetPosition = furnaceBody.position + new Vector3(0, 2, -7); // Примерное смещение назад на 1 единицу
        trolleyTargetPosition = furnaceBody.position + new Vector3(0, 2, -7); // Примерное смещение назад на 2 единицы
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isOpen = !isOpen;
            targetAngle = isOpen ? 90f : 0f;

            if (isOpen)
            {
                Invoke("MoveObjects", 2f);  // Задержка в 2 секунды после открытия двери
            }
        }

        float angle = Mathf.MoveTowardsAngle(transform.localEulerAngles.z, targetAngle, rotationSpeed * Time.deltaTime);
        transform.localEulerAngles = new Vector3(0, 0, angle);
    }

    void MoveObjects()
    {
        // Перемещаем объекты в их целевые позиции
        mechanic.position = mechanicTargetPosition;
        trolley.position = trolleyTargetPosition;
    }
}
