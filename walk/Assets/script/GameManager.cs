using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static UnityEditor.Progress;
using System.Diagnostics;
using Debug = UnityEngine.Debug;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;//MARKER SINGLETON PATTERN 
    public bool isPaused;

    public List<Item> items = new List<Item>();//WHAT KIND OF ITEMS WE HAVE
    public List<int> itemNumbers = new List<int>();//HOW MANY ITEMS WE HAVE
    public GameObject[] slots;

    public Item addItem_01;//TODO REMOVE later
    public Item removeItem_01;//TODO REMOVE later
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            if (instance != this)
            {
                Destroy(gameObject);
            }
        }
        DontDestroyOnLoad(gameObject);

        // 获取背包对象并设置引用
        GameObject backpackObject = GameObject.Find("backpack"); // 替换为背包对象的名称
        SetBackpack(backpackObject);
    }
    private void Start()
    {
        DisplayItems();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            AddItem(addItem_01);
        }
        if(Input.GetKeyDown(KeyCode.N))
        {
            RemoveItem(removeItem_01);
        }

    }
    private void DisplayItems()
    {
        
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < items.Count)
            {
                Debug.Log(slots[i].transform.GetChild(0));
                //UPDATE slots Item Image
                slots[i].transform.GetChild(0).GetComponent<Image>().color = new Color(1, 1, 1, 1);
                slots[i].transform.GetChild(0).GetComponent<Image>().sprite = items[i].itemSprite;
                //UPDATE slots Count Text
                slots[i].transform.GetChild(1).GetComponent<Text>().color = new Color(1, 1, 1, 1);
                slots[i].transform.GetChild(1).GetComponent<Text>().text = itemNumbers[i].ToString();
                //UPDATE CLOSE/THROW button
                slots[i].transform.GetChild(2).gameObject.SetActive(true);
            }
            else//Some Remove Items
            {
                //UPDATE slots Item Image
                slots[i].transform.GetChild(0).GetComponent<Image>().color = new Color(1, 1, 1, 0);
                slots[i].transform.GetChild(0).GetComponent<Image>().sprite = null;
                //UPDATE slots Count Text
                slots[i].transform.GetChild(1).GetComponent<Text>().color = new Color(1, 1, 1, 0);
                slots[i].transform.GetChild(1).GetComponent<Text>().text = null;
                //UPDATE CLOSE/THROW button
                slots[i].transform.GetChild(2).gameObject.SetActive(false);
}
        }
    }
    public void AddItem(Item _item)
    {
        //MARKER IF There is a new _item in our bag
        if (!items.Contains(_item))
        {
            items.Add(_item);
            itemNumbers.Add(1);//ADD ONE
        }
        else//IF There is one existing item in our bags(List)
        {
            UnityEngine.Debug.Log("You have already have this One!");
            for (int i = 0; i < items.Count; i++)
            {
                if (_item == items[i])
                {
                    itemNumbers[i]++;
                }
            }
            DisplayItems();
        }
    }
    public void RemoveItem(Item _item)
    {
        if (items.Contains(_item))//IF There is one existing item in our bags(List)
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (_item == items[i])
                {
                    itemNumbers[i]--;
                    if (itemNumbers[i] == 0)
                    {
                        //WE HAVE TO REMOVE THIS ITEM
                        items.Remove(_item);
                        itemNumbers.Remove(itemNumbers[i]);
                    }
                }
            }
        }
        else
        {
            UnityEngine.Debug.Log("THERE IS NO " + _item + " in my Bags");
        }
        //IF There is no ITEM inside Inventory
        DisplayItems();
    }
    private static GameObject backpack;

    public static void SetBackpack(GameObject backpackObject)
    {
        backpack = backpackObject;
    }



}

