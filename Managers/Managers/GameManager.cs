//using GameAnalyticsSDK;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : BaseManager<GameManager>
{
    //public static GameManager Instance { get; private set; }

    public Action<int,int> OnMonetCountChanged;
    private SaveData saveData;
    //[SerializeField] private LevelsData _levelsData;


    protected override void Awake()
    {
        base.Awake();
        Load();
    }

    private void Start()
    {
        
        //GameAnalytics.Initialize();
        Debug.Log("GA INIT DONE");
        
    }


    private void Load()
    {
        saveData = JSONSaver.Load(new SaveData());
        //Debug.Log(saveData.ToString());
       //Debug.Log(saveData.money.ToString());
    }

    public SaveData GetSaveData()
    {
        return saveData;
    }

    public int GetCurrentItem()
    {
        return saveData.currentItem;
    }
   
    public int GetCurrentLevel()
    {
        return saveData.level;
    }

    public int GetMonetsCount()
    {
        return saveData.money;
    }

    public void AddMonet()
    {
        AddMonet(1);
    }

    public void AddMonet(int count)
    {
        SetMonetsCount(GetMonetsCount() + count);
    }

    public void SetMonetsCount(int value)
    {
        
        OnMonetCountChanged?.Invoke(value,value - saveData.money);

        saveData.money = value;
        Save();
    }
    /*
    public LevelData GetLevelData()
    {
        if (_levelsData.LevelsArray.Length > saveData.level)
        {
            return _levelsData.LevelsArray[saveData.level];
        }
        else
        {
            return null;
        }
        
    }
    */
    private void OnDisable()
    {
        Save();
    }
    /*
    public void WinLevel()
    {
        
        saveData.level++;
        
        Save();
    }
    */
    public void Save()
    {
        JSONSaver.Save(saveData);
    }

    public void LoadNewLevel()
    {
        /*
        GameAnalytics.NewProgressionEvent(GAProgressionStatus.Complete, "Level" + saveData.level.ToString());
        FaceBookActivator.Instance.LogEndLevel(saveData.level);
        */
        //FlurryActivator.Instance?.LogLevelProgressListener(saveData.level, "Complete");

        saveData.level++;

        Save();
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ResetLevel()
    {
        //GameAnalytics.NewProgressionEvent(GAProgressionStatus.Fail, "Level" + saveData.level.ToString());
        //FlurryActivator.Instance?.LogLevelProgressListener(saveData.level, "Fail");

        LoadNewLevel();
    }

    public void ResetSaveData()
    {
        saveData = new SaveData();
        JSONSaver.Delete();
        ResetLevel();
    }
}
