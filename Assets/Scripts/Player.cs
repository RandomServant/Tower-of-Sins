using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    [Header("Speeds")]
    [SerializeField] private float _speedMovePlayer = 1.5f;
    [SerializeField] private float _speedRotationPlayer = 5f;

    [Header("Shadow")]
    public GameObject Shadow;
    
    [Header("Objects")]
    public GameObject Camera;
    
    [Header("Player")]
    public int HP;

    private Rigidbody _coliderPlayer;
    private Animator _animatorPlayer;
    private Transform _transformPlayer;
    
    private CameraMovement _cameraMovement;
    private Shadow _shadow;

    private bool _isShadowSummoned = false;
    private bool _isNoActive = false;

    [Header("UI")] 
    public Slider HPSlider;

    void Start()
    {
        _coliderPlayer = GetComponent<Rigidbody>();
        _animatorPlayer = GetComponent<Animator>();
        _transformPlayer = GetComponent<Transform>();
        _cameraMovement = Camera.GetComponent<CameraMovement>();
        _shadow = Shadow.GetComponent<Shadow>();
    }

    private void SummonShadow()
    {
        Shadow.SetActive(true);
        _isShadowSummoned = true;
        
        _animatorPlayer.SetBool("isSummonedShadow", _isShadowSummoned);
        
        Shadow.transform.parent = null;
        
        _cameraMovement.ChangeUnderControllCharacter(_isShadowSummoned);
    }
    
    private void UnSummonShadow()
    {
        _isShadowSummoned = false;
        
        _animatorPlayer.SetBool("isSummonedShadow", _isShadowSummoned);
        
        _cameraMovement.ChangeUnderControllCharacter(_isShadowSummoned);
        
        Shadow.SetActive(false);
        Shadow.transform.SetParent(gameObject.transform, true);
        Shadow.transform.localPosition = new Vector3(0, 0.3f, -0.5f);
        Shadow.transform.localRotation = Quaternion.Euler(0, 0, 0);

        _shadow.UnSummon();
    }

    private void Update()
    {
        HPSlider.value = HP;
        if(HP <= 0) Camera.GetComponent<Death>().Die();
        if(Input.GetKeyDown(KeyCode.Q) && !_isShadowSummoned)
        {
            SummonShadow();
        }
        else if (Input.GetKeyDown(KeyCode.Q) && _isShadowSummoned  && _isNoActive)
        {
            UnSummonShadow();
            _isNoActive = false;
        }
    }

    private void FixedUpdate()
    {
        if (!_isShadowSummoned)
        {
            float directionX = Input.GetAxis("Horizontal");
            float directionZ = Input.GetAxis("Vertical");

            Vector3 directionVector = new Vector3(directionX, 0, directionZ);
            
            _animatorPlayer.SetFloat("Speed", Vector3.ClampMagnitude(directionVector, 1).magnitude);

            if (directionVector.magnitude > Math.Abs(0.05f)) 
                _transformPlayer.rotation = Quaternion.Lerp
                    (_transformPlayer.rotation, Quaternion.LookRotation(directionVector), Time.deltaTime * _speedRotationPlayer);

            _coliderPlayer.velocity = Vector3.ClampMagnitude(directionVector, 1) * _speedMovePlayer;
        }
    }

    public void ChangeSummon()
    {
        _isNoActive = true;
    }
}
