using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    Transform player;
    [SerializeField] float speed = 5f;
    [SerializeField] float pickupDistance = 1.5f;
    [SerializeField] float ttl = 10f;

    public Item item;
    public int count = 1;

    private void Awake()
    {
        player = GameManager.instance.player.transform;
    }

    private void Update()
    {
        ttl -= Time.deltaTime;
        if (ttl < 0) { Destroy(gameObject); }
        float distance = Vector3.Distance(transform.position, player.position);
        if(distance > pickupDistance)
        {
            return;
        }

        transform.position = Vector3.MoveTowards(
        transform.position, 
        player.position, 
        speed * Time.deltaTime
        );

        if(distance < 0.1f)
        {
            //*TODO* Move into specified controller
            if (GameManager.instance.inventoryContainer != null)
            {
                GameManager.instance.inventoryContainer.Add(item, count);
            }
            else{
                Debug.LogWarning("No Inventory container attached to the game manager");
            }
            Destroy(gameObject);
        }
    }

}
