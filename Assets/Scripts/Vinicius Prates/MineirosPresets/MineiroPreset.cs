using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

[CreateAssetMenu(fileName = "Mineiro PreConfigurado", menuName = "Mineiros", order = 0)]

public class MineiroPreset : ScriptableObject {
    public string nome;
    public Mesh corpoTipo;
    public Sprite mineiroIcon;
}
