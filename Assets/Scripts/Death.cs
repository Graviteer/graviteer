using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private Vector2 respawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        respawnPoint = new Vector2(player.transform.position.x, player.transform.position.y);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            player.transform.position = new Vector2(respawnPoint.x, respawnPoint.y);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
