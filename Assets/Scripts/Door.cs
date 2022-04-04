using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D), typeof(SpriteRenderer))]
public class Door : MonoBehaviour
{
    BoxCollider2D boxcollider;
    SpriteRenderer spriteRenderer;
    [SerializeField] Sprite openDoor;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxcollider = GetComponent<BoxCollider2D>();
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") &&
            collision.gameObject.GetComponent<PlayerController>().CurrentKeys > 0)
        {
            Debug.Log("дверь");
            OpenDoor(collision.gameObject);
        }
    }
    void OpenDoor(GameObject player)
    {
        spriteRenderer.sprite = openDoor;
        player.GetComponent<PlayerController>().CurrentKeys--;
        boxcollider.isTrigger = true;
    }
}
