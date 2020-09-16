using System;
using System.Collections.Generic;

[System.Serializable]
public class SaveData
{
    public int level;
    public List<int> buyedItems;
    public int currentItem;
    public int money;
    public int length;
    public int time;
    public string installTime;

    public SaveData()
    {
        level = 1;
        buyedItems = new List<int>();
        buyedItems.Add(0);
        currentItem = 0;
        money = 0;
        length = 0;
        time = 0;
        installTime = DateTime.Now.ToString();
    }
}
