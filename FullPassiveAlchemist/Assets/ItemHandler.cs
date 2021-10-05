using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHandler : MonoBehaviour
{
    public float RespawnTime;
    public GameObject Player;
    PlayerInventory inventory;
    
    private void Awake()
    {
        inventory = Player.GetComponent<PlayerInventory>();
    }
    public void Disable()
    {
        inventory.PickUpText.SetActive(false);
        gameObject.SetActive(false);
    }
   /* public IEnumerator DisableObjects()
    {
        gameObject.SetActive(false);

        yield return new WaitForSeconds(RespawnTime);
    }*/

}
