using System;
using UnityEngine;

public class Shadow : MonoBehaviour
{
    [Header("Speeds")]
    [SerializeField] private float _speedMoveShadow = 1.5f;
    [SerializeField] private float _speedRotationShadow = 5f;
    
    [Header("Shadow")]
    [SerializeField] private int _damage;

    private Rigidbody _coliderShadow;
    private Animator _animatorShadow;
    private Transform _transformShadow;

    private bool _isMove = false;

    public GameObject Player;
    private Player _player;
    
    public AudioSource Audio;
    public AudioClip AudioCogti;

    void Start()
    {
        _coliderShadow = GetComponent<Rigidbody>();
        _animatorShadow = GetComponent<Animator>();
        _transformShadow = GetComponent<Transform>();
        _player = Player.GetComponent<Player>();
    }

    private void FixedUpdate()
    {
        if (_isMove)
        {
            float directionX = Input.GetAxis("Horizontal");
            float directionZ = Input.GetAxis("Vertical");

            Vector3 directionVector = new Vector3(directionX, 0, directionZ);

            _animatorShadow.SetFloat("Speed", Vector3.ClampMagnitude(directionVector, 1).magnitude);

            if (directionVector.magnitude > Math.Abs(0.05f))
                _transformShadow.rotation = Quaternion.Lerp
                (_transformShadow.rotation, Quaternion.LookRotation(directionVector),
                    Time.deltaTime * _speedRotationShadow);

            _coliderShadow.velocity = Vector3.ClampMagnitude(directionVector, 1) * _speedMoveShadow;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            _animatorShadow.SetTrigger("Attake");
        }
    }

    private void NextMove()
    {
        _animatorShadow.SetBool("Summon", true);
        _isMove = true;
        _player.ChangeSummon();
    }
    
    public void UnSummon()
    {
        _isMove = false;
        _animatorShadow.SetBool("Summon", false);
    }

    private void Sound()
    {
        Audio.PlayOneShot(AudioCogti);
    }
}
