using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{
    public List<GameObject> MyItems = new List<GameObject>();
    public GameObject[] PlayerItems;
    [SerializeField] InputActionReference Inventroykey;
   
    public float Open_Close;//close= 0 & open=1;

    [SerializeField] GameObject HandBookUI_Handler;
    [SerializeField] Text[] ItemAmountListText;
    [SerializeField] int[] ItemAmountList;


    private void OnEnable()
    {
        Inventroykey.action.Enable();
    }
    private void OnDisable()
    {
        Inventroykey.action.Disable();
    }


    private void Start()
    {
        HandBookUI_Handler.SetActive(false);
        Open_Close = 0;
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag== "item")
        {
            GameObject temp;
            temp = other.gameObject;
            AddItem(temp);
        }
    }


    public void AddItem(GameObject currentItem)
    {
       MyItems.Add(currentItem);
        
    }
    private void Update()
    {
        if (Inventroykey.action.triggered && Open_Close==0)
        {
            HandBookUI_Handler.SetActive(true);
            StartCoroutine(OpenOrClose());
            string result = "My Iventory: ";
            
            foreach (GameObject x in MyItems)
            {
                string temp;
                temp = x.name;
                result += "\n "+ temp.ToString() ;
                
            }
            ListCheck();
          

            Debug.Log(result);
        }
        else if (Inventroykey.action.triggered && Open_Close == 1)
        {
            StartCoroutine(OpenOrClose());
            
            HandBookUI_Handler.SetActive(false);
            
        }
    }
    void ListCheck()
    {
        foreach (GameObject x in MyItems)
        {
            string temp;
            temp = x.name;
            Debug.Log(temp);
            for(int i=0; i<MyItems.Count; i++)
            {
                if (temp == MyItems[i].name)
                {
                    int TempNum=0;
                    string tempString = "";
                    ItemAmountList[i]++;
                    TempNum = ItemAmountList[i];
                    tempString = "" + TempNum;
                    ItemAmountListText[i].text = tempString;
                    //ItemAmountList[i] = int.Parse(ItemAmountList[i])++
                }
                else
                {
                    continue;
                }
            }
            //result += "\n " + temp.ToString();

        }
    }
    IEnumerator OpenOrClose()
    {
       
        if (Open_Close == 0 )
        {
            Debug.Log("closed");
            Open_Close = 1;
           
            yield return null;
            
            //  yield return new WaitForSeconds(2);
        }
       else 
        {
            Debug.Log("Open");
            Open_Close = 0;
          
            yield return null;
            //yield return new WaitForSeconds(2);
        }
        

        
    }
}
