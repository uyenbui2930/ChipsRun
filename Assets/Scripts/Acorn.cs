using UnityEngine;

public class Acorn : MonoBehaviour
{
    private float leftEdge;

    private void Start()
    {
        leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 2f;
    }

    private void Update()
    {
        // Move left along the X-axis only
        transform.position += GameManager.Instance.gameSpeed * Time.deltaTime * Vector3.left;

        // Destroy when off-screen
        if (transform.position.x < leftEdge)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.AddScore(10); // Increase score
            Destroy(gameObject); // Remove the acorn after collection
        }
    }
}
