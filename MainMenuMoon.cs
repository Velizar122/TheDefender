using UnityEngine;

public class MainMenuMoon : MonoBehaviour
{
    public Transform centerPoint;
    public float speed = 2f;
    public float radius = 2f;

    private float angle;

    private void Update()
    {
        angle += speed * Time.deltaTime;

        float x = Mathf.Cos(angle) * radius;
        float y = Mathf.Sin(angle) * radius;

        transform.position = centerPoint.position + new Vector3(x, y, 0f);
    }
}


