using UnityEngine;
using System.IO;

public class SaveManager : Singleton<SaveManager>
{
    public bool FerroBool;
    public bool OuroBool;
    public bool AluminioBool;
    public bool NiobioBool;
    public bool ZincoBool;
    public bool GrafitaBool;
    public bool GipsitaBool;
    public bool TurmalinaBool;
    public bool CobreBool;
    public bool TungstenioBool;
    public bool UranioBool;
    public bool OpalaBool;
    public bool MagnesitaBool;
    public bool ManganesBool;

    // Método para salvar dados do jogador em um arquivo JSON
    public void SaveMuseu(Minerios minerio)
    {
        Museu MuseuMinerios = new Museu();
        switch (minerio)
        {
            case Minerios.Ferro:
                MuseuMinerios.FerroBool = true;
                FerroBool = true;
                break;
            case Minerios.Ouro:
                MuseuMinerios.OuroBool = true;
                OuroBool = true;
                break;
            case Minerios.Aluminio:
                MuseuMinerios.AluminioBool = true;
                AluminioBool = true;
                break;
            case Minerios.Niobio:
                MuseuMinerios.NiobioBool = true;
                NiobioBool = true;
                break;
            case Minerios.Zinco:
                MuseuMinerios.ZincoBool = true;
                ZincoBool = true;
                break;
            case Minerios.Grafita:
                MuseuMinerios.GrafitaBool = true;
                GrafitaBool = true;
                break;
            case Minerios.Opala:
                MuseuMinerios.OpalaBool = true;
                OpalaBool = true;
                break;
            case Minerios.Cobre:
                MuseuMinerios.CobreBool = true;
                CobreBool = true;
                break;
            case Minerios.Manganes:
                MuseuMinerios.ManganesBool = true;
                ManganesBool = true;
                break;
            case Minerios.Magnesita:
                MuseuMinerios.MagnesitaBool = true;
                MagnesitaBool = true;
                break;
            case Minerios.Tungstenio:
                MuseuMinerios.TungstenioBool = true;
                TungstenioBool = true;
                break;
            case Minerios.Turmalina:
                MuseuMinerios.TurmalinaBool = true;
                TurmalinaBool = true;
                break;
            case Minerios.Uranio:
                MuseuMinerios.UranioBool = true;
                UranioBool = true;
                break;
            case Minerios.Gipsita:
                MuseuMinerios.GipsitaBool = true;
                GipsitaBool = true;
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
        Grafita,
        Magnesita,
        Uranio,
        Cobre,
        Turmalina,
        Tungstenio,
        Manganes,
        Gipsita,
        Opala
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

[System.Serializable]
    public class Museu
    {
        public bool FerroBool;
        public bool OuroBool;
        public bool AluminioBool;
        public bool NiobioBool;
        public bool ZincoBool;
        public bool GrafitaBool;
        public bool OpalaBool;
        public bool TurmalinaBool;
        public bool TungstenioBool;
        public bool GipsitaBool;
        public bool MagnesitaBool;
        public bool ManganesBool;
        public bool UranioBool;
        public bool CobreBool;
}
