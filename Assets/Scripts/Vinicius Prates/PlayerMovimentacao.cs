using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class PlayerMovimentacao : MonoBehaviour
{
    #region Movimento
    [Header("Movimentacao")]
    [SerializeField] private float velocidade = 3;
    [SerializeField] private float velocidadeCorrida = 6;
    private float velocidadeAntiga;
    private Vector2 myInput;
    private CharacterController characterController;
    [SerializeField] private Transform myCamera;
    [SerializeField] bool _minerando;
    [SerializeField] bool correndo;
    public bool agua;

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
    [SerializeField] Animator animator;
    #endregion

    private void Awake()
    {
        velocidadeAntiga = velocidade;
        characterController = GetComponent<CharacterController>();
    }

    /// <summary>
    /// Metodo respons�vel por obter as entradas do joystick.
    /// </summary>
    /// <param name="value">Callback com as entradas de joystick, vindos do Inputs Actions</param>
    public void MoverPersonagem(InputAction.CallbackContext value)
    {
        myInput = value.ReadValue<Vector2>();
    }

    

    public void Update()
    {
        if(!correndo)
        velocidade = velocidadeAntiga;
        
        if(!_minerando && !agua)
        {
            RotacionarPersonagem();
            characterController.Move(transform.forward * myInput.magnitude * velocidade * Time.deltaTime);
            characterController.Move(Vector3.down * 9.81f * Time.deltaTime);
            animator.SetBool("Andar", myInput != Vector2.zero);

        }

        
    }
    /// <summary>
    /// Rotaciona o personagem de acordo com a posi��o da c�mera e entradas do usu�rio
    /// </summary>
    private void RotacionarPersonagem()
    {
        Vector3 forward = myCamera.TransformDirection(Vector3.forward);

        Vector3 right = myCamera.TransformDirection(Vector3.right);


        Vector3 targetDirection = myInput.x * right + myInput.y * forward;


        if (myInput != Vector2.zero && targetDirection.magnitude > 0.1f)
        {
            Quaternion freeRotation = Quaternion.LookRotation(targetDirection.normalized); 
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(new Vector3(transform.eulerAngles.x, freeRotation.eulerAngles.y, transform.eulerAngles.z)), 10 * Time.deltaTime);
        }
    }

    public void Correr(InputAction.CallbackContext value)
    {
        velocidade = velocidadeCorrida;
        animator.SetBool("Correr", value.started || value.performed);
        correndo = (value.started || value.performed);
        
    }






    public void Interaction(InputAction.CallbackContext context)
    {
        Physics.BoxCast(transform.position, new Vector3(2f, 2f, 0.1f), transform.forward, out hit, transform.rotation, 1.0f);

        if (context.started)
        {

            isButtonPressed = true;
            if (hit.collider.CompareTag("Minerio"))
            {
                hit.collider.GetComponent<Interactable>().Interagir();
                objInt = hit.collider.GetComponent<Interactable>();
                if (objInt != null)
                {
                    StartCoroutine(InteracaoContinua());
                }

            }
            else if (hit.collider.CompareTag("Pedra"))
            {
                hit.collider.GetComponent<Interactable>().Interagir(ref segurando, mao);
            }
            else if (hit.collider.CompareTag("Interagivel"))
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
        while (isButtonPressed && objInt != null)
        {
            _minerando = true;
            animator.SetBool("Batendo", true);
            animator.SetBool("Correr", false);
            animator.SetBool("andar", false);
            if (objInt is not null)
            {
                objInt.Interagir();
            }
            Debug.Log("Colidiu");
            yield return new WaitForSeconds(1f);
        }

        animator.SetBool("Batendo", false);
        _minerando = false;
        if (objInt is not null)
            objInt.Cancelar();
        yield return null;


    }



    public bool IsGrounded() => _estaNoChao;

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Elevador"))
        {
            SceneManager.LoadScene(cena);
        }
    }

    void OnDrawGizmos()
    {
        float maxDistance = 10f;
        RaycastHit hit;

        bool isHit = Physics.BoxCast(transform.position, new Vector3(2f, 2f, 0.1f), transform.forward, out hit, transform.rotation, 1.0f);
        if (isHit)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawRay(transform.position, transform.forward * hit.distance);
            Gizmos.DrawWireCube(transform.position + transform.forward * hit.distance, new Vector3(2f, 2f, 0.1f));
        }
        else
        {
            Gizmos.color = Color.green;
            Gizmos.DrawRay(transform.position, transform.forward * 2.0f);
        }
    }

}

