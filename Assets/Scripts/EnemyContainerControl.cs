using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyContainerControl : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float timeCreateEnemy = 2;
    public float timeCurrentCreateEnemy = 0;
    public float minX = -6.90f;
    public float maxX = 7.05f;
    public float minY = 5.72f;
    public float maxY = 9.57f;
    public float speedY;
    public float vertical;
    void CreateEnemy()
    {
        Vector2 randomPosition = new Vector2(
            Random.Range(minX, maxX),
            Random.Range(minY, maxY)
            );
        GameObject enemy = Instantiate(enemyPrefab, randomPosition, transform.rotation);
        Rigidbody2D enemyRigidbody = enemy.GetComponent<Rigidbody2D>();
        enemyRigidbody.velocity = new Vector2(0, speedY * vertical);

    }
    void Update()
    {
        timeCurrentCreateEnemy = timeCurrentCreateEnemy + Time.deltaTime;
        if (timeCurrentCreateEnemy >= timeCreateEnemy)
        {
            timeCurrentCreateEnemy = 0;
            CreateEnemy();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Destroy(gameObject);
        }
    }
}
