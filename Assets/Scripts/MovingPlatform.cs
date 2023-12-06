using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private int startingPoint;
    [SerializeField] private Transform[] points;

    private int i;
    // Start is called before the first frame update
    void Start()
    {

    }

    void FixedUpdate()
    {
        if (Vector2.Distance(transform.position, points[i].position) < 0.002f)
        {
            i++;
            if (i == points.Length)
            {
                i = 0;
            }
        }
        Debug.Log(transform.position);
        Debug.Log(points[i].position);
        Debug.Log("current position distance " + Vector2.Distance(transform.position, points[i].position));

        transform.position = Vector2.MoveTowards(transform.position, points[i].position, speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.transform.SetParent(transform);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        collision.transform.SetParent(null);
    }
}
