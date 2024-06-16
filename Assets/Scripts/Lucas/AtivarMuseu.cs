using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtivarMuseu : MonoBehaviour
{
    
    public Minerios[] minerios;
    void Start()
    {
        //ferro
        minerios[0].Nome = "Ferro";
        minerios[0].pedestal.SetActive(SaveManager.Instance.FerroBool);
        minerios[0].minerio.SetActive(SaveManager.Instance.FerroBool);
        //ouro
        minerios[1].Nome = "Ouro";
        minerios[1].pedestal.SetActive(SaveManager.Instance.OuroBool);
        minerios[1].minerio.SetActive(SaveManager.Instance.OuroBool);
        //AluminioBool
        minerios[2].Nome = "Aluminio";
        minerios[2].pedestal.SetActive(SaveManager.Instance.AluminioBool);
        minerios[2].minerio.SetActive(SaveManager.Instance.AluminioBool);
        //NiobioBool
        minerios[3].Nome = "Niobio";
        minerios[3].pedestal.SetActive(SaveManager.Instance.NiobioBool);
        minerios[3].minerio.SetActive(SaveManager.Instance.NiobioBool);
        //ZincoBool
        minerios[4].Nome = "Zinco";
        minerios[4].pedestal.SetActive(SaveManager.Instance.ZincoBool);
        minerios[4].minerio.SetActive(SaveManager.Instance.ZincoBool);
        //GrafitaBool
        minerios[5].Nome = "Grafita";
        minerios[5].pedestal.SetActive(SaveManager.Instance.GrafitaBool);
        minerios[5].minerio.SetActive(SaveManager.Instance.GrafitaBool);
        //GipsitaBool
        minerios[6].Nome = "Gipsita";
        minerios[6].pedestal.SetActive(SaveManager.Instance.GipsitaBool);
        minerios[6].minerio.SetActive(SaveManager.Instance.GipsitaBool);
        //TurmalinaBool
        minerios[7].Nome = "Tumalina";
        minerios[7].pedestal.SetActive(SaveManager.Instance.TurmalinaBool);
        minerios[7].minerio.SetActive(SaveManager.Instance.TurmalinaBool);
        //CobreBool
        minerios[8].Nome = "Cobre";
        minerios[8].pedestal.SetActive(SaveManager.Instance.CobreBool);
        minerios[8].minerio.SetActive(SaveManager.Instance.CobreBool);
        //TungstenioBool
        minerios[9].Nome = "Tungstenio";
        minerios[9].pedestal.SetActive(SaveManager.Instance.TungstenioBool);
        minerios[9].minerio.SetActive(SaveManager.Instance.TungstenioBool);
        //UranioBool
        minerios[10].Nome = "Uranio";
        minerios[10].pedestal.SetActive(SaveManager.Instance.UranioBool);
        minerios[10].minerio.SetActive(SaveManager.Instance.UranioBool);
        //OpalaBool
        minerios[11].Nome = "Opala";
        minerios[11].pedestal.SetActive(SaveManager.Instance.OpalaBool);
        minerios[11].minerio.SetActive(SaveManager.Instance.OpalaBool);
        //MagnesitaBool
        minerios[12].Nome = "Magnesita";
        minerios[12].pedestal.SetActive(SaveManager.Instance.MagnesitaBool);
        minerios[12].minerio.SetActive(SaveManager.Instance.MagnesitaBool);
        ///////////////////////////////////////////////////////////////////
        //MagnesitaBool
        /*
        minerios[13].Nome = "temp";
        minerios[13].pedestal.SetActive(SaveManager.Instance.MagnesitaBool);
        minerios[13].minerio.SetActive(SaveManager.Instance.MagnesitaBool);
        //MagnesitaBool
        minerios[14].Nome = "temp";
        minerios[14].pedestal.SetActive(SaveManager.Instance.MagnesitaBool);
        minerios[14].minerio.SetActive(SaveManager.Instance.MagnesitaBool);
        //MagnesitaBool
        minerios[15].Nome = "temp";
        minerios[15].pedestal.SetActive(SaveManager.Instance.MagnesitaBool);
        minerios[15].minerio.SetActive(SaveManager.Instance.MagnesitaBool);
        //MagnesitaBool
        minerios[16].Nome = "temp";
        minerios[16].pedestal.SetActive(SaveManager.Instance.MagnesitaBool);
        minerios[16].minerio.SetActive(SaveManager.Instance.MagnesitaBool);
        //MagnesitaBool
        minerios[17].Nome = "temp";
        minerios[17].pedestal.SetActive(SaveManager.Instance.MagnesitaBool);
        minerios[17].minerio.SetActive(SaveManager.Instance.MagnesitaBool);
        //MagnesitaBool
        minerios[18].Nome = "temp";
        minerios[18].pedestal.SetActive(SaveManager.Instance.MagnesitaBool);
        minerios[18].minerio.SetActive(SaveManager.Instance.MagnesitaBool);
        //MagnesitaBool
        minerios[19].Nome = "temp";
        minerios[19].pedestal.SetActive(SaveManager.Instance.MagnesitaBool);
        minerios[19].minerio.SetActive(SaveManager.Instance.MagnesitaBool);
        //MagnesitaBool
        minerios[20].Nome = "temp";
        minerios[20].pedestal.SetActive(SaveManager.Instance.MagnesitaBool);
        minerios[20].minerio.SetActive(SaveManager.Instance.MagnesitaBool);*/
    }

}
[System.Serializable]
public class Minerios
{
    
    public string Nome;
    public GameObject pedestal;
    public GameObject minerio;
}
