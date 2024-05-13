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
    [SerializeField] Vector3 _inputAcoes2D;
    [SerializeField] Vector3 _inputAcoes;
    [SerializeField] Transform cameraPlayer;
    [SerializeField] Movimento _movimento = new Movimento();
    [SerializeField] ForceMode _forceMode;
    Vector3 forward;
    [SerializeField] bool _minerando;
    #endregion

    #region Colisoes
    [Header("Colisoes")]
    [SerializeField] bool _estaNoChao;
    [SerializeField] Transform rayCastInicio;
    [SerializeField] RaycastHit hit;
    #endregion

    #region Interacoes
    [Header("Intereacoes")]
    [SerializeField] bool segurando;
    [SerializeField] bool isButtonPressed;
    [SerializeField] Transform mao;
    [SerializeField] string cena;
    [SerializeField] Interactable objInt;
    #endregion

    #region Animacoes
    [SerializeField] Animator anim;
    #endregion

    public void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

    public void Update()
    {
        anim.SetFloat("Speed", _rigidBody.velocity.magnitude);
        if ((_inputAcoes.x == 0 && _inputAcoes.z == 0))
        {
            return;
        }
        if (!_minerando)
        {
            ApplyMovement();
            ApplyRotation();
        }
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
        _inputAcoes2D = context.ReadValue<Vector2>();
        Debug.Log("" + _inputAcoes2D.x);
        _inputAcoes = new Vector3(_inputAcoes2D.x,0,_inputAcoes2D.y);
        _inputAcoes = Matrix4x4.Rotate(cameraPlayer.rotation) * _inputAcoes;
    }

    public void Interaction(InputAction.CallbackContext context)
    {
        Physics.CapsuleCast(rayCastInicio.position, transform.forward * 3.0f, 0.4f, transform.forward, out hit, 2.0f);

        if (context.started)
        {
            isButtonPressed = true;
            StartCoroutine(InteracaoContinua());
            /* if (hit.collider.CompareTag("NPC"))
             {
                 hit.collider.GetComponent<Interactable>().Interagir();
             }*/
            if (hit.collider.CompareTag("Pedra"))
            {
                hit.collider.GetComponent<Interactable>().Interagir(ref segurando, mao);
            }
            if (hit.collider.CompareTag("Interagivel"))
            {
                hit.collider.GetComponent<Interactable>().Interagir();
            }
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
            // Vector3 vectorEsquerda = transform.forward + new Vector3(-0.2f, 0, 0);
            // Vector3 vectorDireita = transform.forward + new Vector3(0.2f, 0, 0);
            // Physics.Raycast(transform.position, transform.forward, out hit, 2.0f);
            // Physics.Raycast(transform.position, vectorEsquerda, out hit, 2.0f);
            // Physics.Raycast(transform.position, vectorDireita, out hit, 2.0f);
            Physics.CapsuleCast(rayCastInicio.position, transform.position + (transform.forward), 0.4f, transform.forward, out hit, 2.0f);
            if (hit.collider != null)
            {
                if (hit.collider.CompareTag("Minerio"))
                {
                    hit.collider.GetComponent<Interactable>().Interagir();
                    anim.SetBool("Batendo", true);
                    _minerando = true;
                    objInt = hit.collider.GetComponent<Interactable>();
                }

                if (!segurando && hit.collider.CompareTag("Minerio"))
                {
                    segurando = true;
                    


                    while (isButtonPressed && objInt.CompareTag("Minerio"))
                    {
                        if (!objInt.IsInteragindo())
                        {
                            // Physics.Raycast(transform.position, transform.forward, out hit, 2.0f);
                            Physics.CapsuleCast(rayCastInicio.position, transform.forward * 2.0f, 0.5f, transform.forward, out hit, 2.0f);
                            objInt.Interagir();
                        }
                        if (objInt != null)
                            objInt.Cancelar();
                        yield return new WaitForSeconds(0.3f);

                    }
                    if (objInt != null)
                        objInt.Cancelar();
                }
            }
            yield return null;
        }
        anim.SetBool("Batendo", false);
        _minerando = false;
        if(objInt != null)
        objInt.Cancelar();
       // objInt = null;


    }



    public bool IsGrounded() => _estaNoChao;

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Elevador"))
        {
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