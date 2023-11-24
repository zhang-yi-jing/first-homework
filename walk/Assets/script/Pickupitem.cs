using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PickupItem : MonoBehaviour

{
    public Item itemData;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Destroy(gameObject);

            GameManager.instance.AddItem(itemData);

        }
    }
}