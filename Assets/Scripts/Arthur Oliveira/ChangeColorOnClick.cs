using UnityEngine;
using UnityEngine.EventSystems;

public class ChangeColorOnClick : MonoBehaviour
{
    private Renderer objectRenderer;
    private Color originalColor;
    public Color newColor = Color.red; // Defina a nova cor aqui

    void Start()
    {
        // Obtém o Renderer do objeto
        objectRenderer = GetComponent<Renderer>();
        // Salva a cor original do material
        originalColor = objectRenderer.material.color;

        // Adiciona um Event Trigger dinamicamente ao objeto
        AddEventTrigger();
    }

    void AddEventTrigger()
    {
        // Adiciona um Event Trigger ao objeto
        EventTrigger eventTrigger = gameObject.AddComponent<EventTrigger>();

        // Adiciona um evento de clique ao Event Trigger
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerClick;
        entry.callback.AddListener((data) => { OnPointerClick(); });
        eventTrigger.triggers.Add(entry);
    }

    // Este método é chamado quando o objeto é clicado
    void OnPointerClick()
    {
        // Muda a cor do material para a nova cor definida
        objectRenderer.material.color = newColor;
    }

    // Este método é chamado quando o mouse sai do objeto
    void OnMouseExit()
    {
        // Retorna a cor original do material
        objectRenderer.material.color = originalColor;
    }
}