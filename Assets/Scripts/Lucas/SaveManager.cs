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
    public bool FluoritaBool;

    public void SaveMuseu(Minerios minerio)
    {
        switch (minerio)
        {
            case Minerios.Ferro:
                
                FerroBool = true;
                break;
            case Minerios.Ouro:
                
                OuroBool = true;
                break;
            case Minerios.Aluminio:
                
                AluminioBool = true;
                break;
            case Minerios.Niobio:
                
                NiobioBool = true;
                break;
            case Minerios.Zinco:
                
                ZincoBool = true;
                break;
            case Minerios.Grafita:
                
                GrafitaBool = true;
                break;
            case Minerios.Opala:
                
                OpalaBool = true;
                break;
            case Minerios.Cobre:
                
                CobreBool = true;
                break;
            case Minerios.Manganes:
               
                ManganesBool = true;
                break;
            case Minerios.Magnesita:
                
                MagnesitaBool = true;
                break;
            case Minerios.Tungstenio:
                
                TungstenioBool = true;
                break;
            case Minerios.Turmalina:
                
                TurmalinaBool = true;
                break;
            case Minerios.Uranio:
                
                UranioBool = true;
                break;
            case Minerios.Gipsita:
                
                GipsitaBool = true;
                break;
            case Minerios.Fluorita:
                
                FluoritaBool = true;
                break;
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
        Opala,
        Fluorita
    }
}



