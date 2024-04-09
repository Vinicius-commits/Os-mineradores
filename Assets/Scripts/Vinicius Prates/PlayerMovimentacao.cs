using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using System.Net.Http.Headers;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovimentacao : MonoBehaviour
{
    #region Movement
    [Header("Movimentation")]
    [SerializeField] Rigidbody _rigidBody;
    [SerializeField] Vector3 _inputAcoes;
    [SerializeField] Transform cameraPlayer;
    [SerializeField] Movimento _movimento = new Movimento();
    [SerializeField] ForceMode _forceMode;
    #endregion
    
    #region Colisions
    [Header("Collisions")]
    [SerializeField] bool _estaNoChao;
    [SerializeField] RaycastHit hit;
    #endregion

    #region Interacoes
    [SerializeField] bool segurando;
    [SerializeField] bool isButtonPressed;
    [SerializeField] Transform mao;
    [SerializeField] string cena;
    #endregion



    public void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

    public void FixedUpdate()
    {
        ApplyMovement();
        ApplyRotation();
        Debug.DrawRay(transform.position, transform.forward * 2, Color.red);
    }

    public void ApplyMovement()
    {
        var targetSpeed = _movimento.estaCorrendo ? _movimento.velocidade * _movimento.multiplicarCorrida : _movimento.velocidade;        
        _rigidBody.AddForce((_inputAcoes * targetSpeed * Time.deltaTime), _forceMode);
    }

    public void ApplyRotation()
    {
        if (!(_inputAcoes.x == 0 && _inputAcoes.z == 0))
        {
            var _viewAngle = Mathf.Atan2(_inputAcoes.x, _inputAcoes.z) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0.0f, _viewAngle, 0.0f);
        }
    }

    public void Sprint(InputAction.CallbackContext context)
    {
        _movimento.estaCorrendo = context.started || context.performed;
    }

    public void Move(InputAction.CallbackContext context)
    {
        _inputAcoes = context.ReadValue<Vector3>();
    }

    // public void Interaction(InputAction.CallbackContext context)
    // {
    //     if (context.performed)
    //     {
    //         // A ação foi realizada (botão pressionado)
    //         // Faça o que precisa ser feito quando o botão é pressionado
            
    //         // Exemplo: lançar um raio para interagir com objetos
    //         Physics.Raycast(transform.position, transform.forward, out hit, 2.0f);

    //         if (hit.collider != null)
    //         {
    //             if (hit.collider.CompareTag("Pedra"))
    //             {
    //                 hit.collider.GetComponent<Interactable>().Interagir(ref segurando, mao);
    //             }
    //             else if (hit.collider.CompareTag("Minerio"))
    //             {
    //                 hit.collider.GetComponent<Interactable>().Interagir();
    //             }

    //             if (!segurando && hit.collider.CompareTag("Minerio"))
    //             {
    //                 // Ativar animação de minerar
    //                 segurando = true;
    //                 Interactable obj = hit.collider.GetComponent<Interactable>();
                    
    //                 // Continuar interagindo enquanto o botão estiver pressionado
    //                 isButtonPressed = true;
    //                 while (isButtonPressed && context.performed && obj.CompareTag("Minerio"))
    //                 {
    //                     if (!obj.IsInteragindo())
    //                     {
    //                         Physics.Raycast(transform.position, transform.forward, out hit, 2.0f);
    //                         obj.Interagir();
    //                     }
    //                 }
    //             }
    //         }
    //     }

    //     else if (context.canceled)
    //     {
    //         // A ação foi cancelada (botão liberado)
    //         isButtonPressed = false;
    //     }
    // }


    public void Interaction(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            // A ação foi realizada (botão pressionado)
            // Faça o que precisa ser feito quando o botão é pressionado
            
            isButtonPressed = true;
            StartCoroutine(ContinuousInteraction());
        }
        
        if (context.canceled)
        {
            // A ação foi cancelada (botão liberado)
            isButtonPressed = false;
        }
    }

    private IEnumerator ContinuousInteraction()
    {
        while (isButtonPressed)
        {
            // Exemplo: lançar um raio para interagir com objetos
            Physics.Raycast(transform.position, transform.forward, out hit, 2.0f);

            if (hit.collider != null)
            {
                if (hit.collider.CompareTag("Pedra"))
                {
                    hit.collider.GetComponent<Interactable>().Interagir(ref segurando, mao);
                }
                else if (hit.collider.CompareTag("Minerio"))
                {
                    hit.collider.GetComponent<Interactable>().Interagir();
                }

                if (!segurando && hit.collider.CompareTag("Minerio"))
                {
                    // Ativar animação de minerar
                    segurando = true;
                    Interactable obj = hit.collider.GetComponent<Interactable>();

                    while (isButtonPressed && obj.CompareTag("Minerio"))
                    {
                        if (!obj.IsInteragindo())
                        {
                            Physics.Raycast(transform.position, transform.forward, out hit, 2.0f);
                            obj.Interagir();
                        }

                        // Esperar um pequeno intervalo para evitar execução muito rápida
                        yield return null;
                    }
                }
            }

            // Esperar um pequeno intervalo para evitar execução muito rápida
            yield return null;
        }
    }

    

    public bool IsGrounded() => _estaNoChao;


     void OnCollisionEnter(Collision other)
     {
        if (other.gameObject.CompareTag("Elevador")){
            SceneManager.LoadScene(cena);
        }
     }

}
[Serializable]
public struct Movimento
{
    public float velocidade, multiplicarCorrida, aceleracao;

    [HideInInspector] public bool estaCorrendo;
    [HideInInspector] public float velocidadeAtual;
}