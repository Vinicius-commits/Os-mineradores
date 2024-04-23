using UnityEngine;
using System.IO;

public class SaveManager : Singleton<SaveManager>
{
    [System.Serializable]
    public class Museu
    {
        public bool FerroBool;
        public bool OuroBool;
        public bool AluminioBool;
        public bool NiobioBool;
        public bool ZincoBool;
        public bool GrafitaBool;
    }

    // Método para salvar dados do jogador em um arquivo JSON
    public void SaveMuseu(Minerios minerio)
    {
        Museu MuseuMinerios = new Museu();
        switch (minerio)
        {
            case Minerios.Ferro:
                MuseuMinerios.FerroBool = true;
                break;
            case Minerios.Ouro:
                MuseuMinerios.OuroBool = true;
                break;
            case Minerios.Aluminio:
                MuseuMinerios.AluminioBool = true;
                break;
            case Minerios.Niobio:
                MuseuMinerios.NiobioBool = true;
                break;
            case Minerios.Zinco:
                MuseuMinerios.ZincoBool = true;
                break;
            case Minerios.Grafita:
                MuseuMinerios.GrafitaBool = true;
                break;
        }


        string jsonData = JsonUtility.ToJson(MuseuMinerios);
        File.WriteAllText(Application.persistentDataPath + "/Museu.json", jsonData);
    }

    // Método para carregar dados do jogador de um arquivo JSON
    public Museu LoadMuseu()
    {
        string path = Application.persistentDataPath + "/Museu.json";
        if (File.Exists(path))
        {
            string jsonData = File.ReadAllText(path);
            Museu MuseuMinerios = JsonUtility.FromJson<Museu>(jsonData);
            return MuseuMinerios;
        }
        else
        {
            Debug.LogError("ARQUIVO NAO ENCONTRADO");
            return null;
        }
    }

    public enum Minerios
    {
        Ferro,
        Ouro,
        Aluminio,
        Niobio,
        Zinco,
        Grafita
    }

    public SaveManager()
    {

    }

    // Toda vez q tu der play ele carrega tudo dnv
    public void Start() 
    {
        LoadMuseu();
    }

}
