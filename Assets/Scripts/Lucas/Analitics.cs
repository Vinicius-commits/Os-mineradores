using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;
using System;

public class AnalyticsTest : MonoBehaviour
{
    public float museuTime;
    public float faseTime;
    public int minerios;
    public List<AnalyticsData> data;
    public static AnalyticsTest Instance { get; private set; }

    void Awake()
    {
        Instance = this;
        data = new List<AnalyticsData>();
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Museu")
        {
            museuTime += Time.deltaTime;
        }
        else if (SceneManager.GetActiveScene().name != "Menu" && SceneManager.GetActiveScene().name != "MapaBrasil")
        {
            faseTime += Time.deltaTime;
        }
        else if (SceneManager.GetActiveScene().name == "Menu")
        {
            Destruido();
            Destroy(this);
        }
    }

    void Destruido()
    {
        AddAnalytics("Player", "MuseuTime", museuTime.ToString("0.00"));
        AddAnalytics("Player", "FaseTime", faseTime.ToString("0.00"));
        AddAnalytics("Player", "Minerios", minerios.ToString());
        Save();
    }

    public void AddAnalytics(string sender, string track, string value)
    {
        AnalyticsData d = new AnalyticsData(Time.time, sender, track, value);
        Debug.Log("Send: " + d.sender + ", Track: " + d.track + ", Value: " + d.value);
        data.Add(d);
    }

    public void Save()
    {
        AnalyticsFile f = new AnalyticsFile();
        f.data = data.ToArray();
        string json = JsonUtility.ToJson(f, true);
        SaveFile(json);
    }

    void SaveFile(string text)
    {
        string path = Application.dataPath + "/analytics.txt";
        Debug.Log("Arquivo salvo em: " + path);
        File.WriteAllText(path, text);
    }
}