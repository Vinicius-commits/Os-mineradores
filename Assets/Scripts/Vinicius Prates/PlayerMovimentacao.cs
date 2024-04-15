using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovimentacao : MonoBehaviour
{
    #region Movimento
    [Header("Movimentacao")]
    [SerializeField] Rigidbody _rigidBody;
    [SerializeField] Vector3 _inputAcoes;
    [SerializeField] Transform cameraPlayer;
    [SerializeField] Movimento _movimento = new Movimento();
    [SerializeField] ForceMode _forceMode;
    Vector3 forward;
    #endregion

    #region Colisoes
    [Header("Colisoes")]
    [SerializeField] bool _estaNoChao;
    [SerializeField] RaycastHit hit;
    #endregion

    #region Interacoes
    [Header("Intereacoes")]
    [SerializeField] bool segurando;
    [SerializeField] bool isButtonPressed;
    [SerializeField] Transform mao;
    [SerializeField] string cena;
    #endregion

    #region Animacoes
    [SerializeField] Animator animator;
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
        Debug.DrawRay(transform.position, new Vector3(-0.3f, 0, 1) * 2, Color.red);
        Debug.DrawRay(transform.position, new Vector3(0.3f, 0, 1) * 2, Color.red);
    }

    public void ApplyMovement()
    {
        var targetSpeed = _movimento.estaCorrendo ? _movimento.velocidade * _movimento.multiplicarCorrida : _movimento.velocidade;
        _rigidBody.AddForce((_inputAcoes * targetSpeed * Time.deltaTime), _forceMode);
        animator.Play("Run");
    }

    public void ApplyRotation()
    {
        if (!(_inputAcoes.x == 0 && _inputAcoes.z == 0))
        {
            var _viewAngle = Mathf.Atan2(_inputAcoes.x, _inputAcoes.z) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0.0f, _viewAngle, 0.0f);
        }
        
        else if(!(animator.GetCurrentAnimatorClipInfo(0).ToString() == "Idle") && !isButtonPressed)
        {
            animator.Play("Idle");
        }
    }

    public void Sprint(InputAction.CallbackContext context)
    {
        _movimento.estaCorrendo = context.started || context.performed;
    }

    public void Move(InputAction.CallbackContext context)
    {
        _inputAcoes = context.ReadValue<Vector3>();
        _inputAcoes = Matrix4x4.Rotate(cameraPlayer.rotation) * _inputAcoes;
    }

    public void Interaction(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            isButtonPressed = true;
            StartCoroutine(InteracaoContinua());
        }
        
        if (context.canceled)
        {
            isButtonPressed = false;
        }
    }

    private IEnumerator InteracaoContinua()
    {
        while (isButtonPressed)
        {
            Physics.Raycast(transform.position, transform.forward, out hit, 2.0f);
            Physics.Raycast(transform.position, new Vector3(0.3f, 0, 1), out hit, 2.0f);
            Physics.Raycast(transform.position, new Vector3(-0.3f, 0, 1), out hit, 2.0f);

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
                else if (hit.collider.CompareTag("NPC"))
                {
                    hit.collider.GetComponent<Interactable>().Interagir();
                }

                if (!segurando && hit.collider.CompareTag("Minerio"))
                {
                    segurando = true;
                    Interactable obj = hit.collider.GetComponent<Interactable>();
                    animator.Play("Minerando");

                    while (isButtonPressed && obj.CompareTag("Minerio"))
                    {
                        if (!obj.IsInteragindo())
                        {
                            Physics.Raycast(transform.position, transform.forward, out hit, 2.0f);
                            obj.Interagir();
                        }
                        yield return null;
                    }
                    animator.Play("Idle");
                }
            }

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