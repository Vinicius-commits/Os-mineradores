using UnityEngine;
using UnityEngine.UI;

public class FPSCounter : MonoBehaviour
{
    public Text fpsText; // Referência ao componente Text do UI
    private float deltaTime = 0.0f;
    

    void Update()
    {
        // Atualiza o tempo delta
        deltaTime += (Time.deltaTime - deltaTime) * 0.1f;

        // Calcula os frames por segundo
        float fps = 1.0f / deltaTime;

        // Atualiza o texto do UI com o valor do FPS
        fpsText.text = string.Format("{0:0.} FPS", fps);
    }
}
