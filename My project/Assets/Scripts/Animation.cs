using System.Collections;
using UnityEngine;

public class DoorRotation : MonoBehaviour
{
    private bool isOpening = false;
    private float startAngle = 0f;
    private float targetAngle = 90f;
    private float duration = 2f; // Продолжительность анимации в секундах

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isOpening)
        {
            isOpening = true;
            StartCoroutine(OpenDoor());
        }
    }

    IEnumerator OpenDoor()
    {
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            float currentAngle = Mathf.Lerp(startAngle, targetAngle, elapsedTime / duration);
            transform.localEulerAngles = new Vector3(0f, 0f, currentAngle);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.localEulerAngles = new Vector3(0f, 0f, targetAngle);
        isOpening = false;
    }
}
