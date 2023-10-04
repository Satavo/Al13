using System.Collections;
using UnityEngine;

public class DoorRotation : MonoBehaviour
{
    private bool isMoving = false; // Вместо только открывания мы учитываем оба направления
    private bool isOpen = false; // Для проверки текущего состояния двери (открыта/закрыта)
    private float startAngle = 0f;
    private float openAngle = 90f; // угол, при котором дверь считается открытой
    private float duration = 2f;

    void Update()
    {
        // При нажатии на кнопку и если дверь не двигается
        if (Input.GetMouseButtonDown(0) && !isMoving)
        {
            StartCoroutine(ToggleDoor());
        }
    }

    IEnumerator ToggleDoor()
    {
        isMoving = true;

        float elapsedTime = 0f;
        float initialAngle = transform.localEulerAngles.z;
        float targetAngle = isOpen ? startAngle : openAngle;

        while (elapsedTime < duration)
        {
            float currentAngle = Mathf.Lerp(initialAngle, targetAngle, elapsedTime / duration);
            transform.localEulerAngles = new Vector3(0f, 0f, currentAngle);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.localEulerAngles = new Vector3(0f, 0f, targetAngle);
        isOpen = !isOpen; // Меняем состояние двери
        isMoving = false;
    }
}
