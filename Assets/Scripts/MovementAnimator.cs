using Photon.Pun;
using StarterAssets;
using UnityEngine;

namespace photonPun
{
    /// <summary>
    /// 移動動畫控制器
    /// </summary>
    public class MovementAnimator : MonoBehaviourPun
    {
        [SerializeField, Header("腳色控制器")]
        private CharacterController characterController;
        [SerializeField, Header("第一人稱控制器")]
        private FirstPersonController firstPersonController;

        private Animator ani;
        private string parMove = "Movement";


        private void Awake()
        {
            if(!photonView.IsMine) enabled = false;
            ani = GetComponent<Animator>();
        }
        private void Update()
        {
            UpdateAnimator();
        }

        private void UpdateAnimator()
        {
            print(characterController.velocity.magnitude);
            ani.SetFloat(parMove, characterController.velocity.magnitude / firstPersonController.SprintSpeed);
        }
    }
}

