using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MoreMountains.Tools;
using MoreMountains.Feedbacks;

public class PlayerController : MonoBehaviour
{
    [Header("Input")]
    public KeyCode ActionKey = KeyCode.Space;
    public KeyCode ActionKeyAlt = KeyCode.Joystick1Button0;

    [Header("Movement")]
    public float Speed = 5f;
    public Vector3 Direction = Vector2.right;

    [Header("BodyParts")]
    public AnimalPrefab AnimalPartPrefab;
    public int BodyPartsOffset = 7;

    [Header("Bindings")]
    public Text PointsCounter;

    [Header("Feedbacks")]
    public MMFeedbacks TurnFeedback;
    public MMFeedbacks TeleportFeedback;
    public MMFeedbacks TeleportOnceFeedback;
    public MMFeedbacks EatFeedback;
    public MMFeedbacks LoseFeedback;

    [Header("Debug")]
    [MMReadOnly]
    public int AnimalPoints = 0;
    [MMReadOnly]
    public float _speed;

    protected Vector3 _newPosition;
    protected MMPositionRecorder _recorder;
    public List<AnimalPrefab> _animalPrefabs;
    protected float _lastLostPart = 0f;


    protected virtual void Awake()
    {
        _speed = Speed;
        AnimalPoints = 0;
        _recorder = this.gameObject.GetComponent<MMPositionRecorder>();
        PointsCounter.text = "0";
        _animalPrefabs = new List<AnimalPrefab>();
    }

    protected virtual void Update()
    {
        HandleInput();
        HandleMovement();
    }
    protected virtual void HandleInput()
    {
        if (Input.GetKeyDown(ActionKey) || Input.GetKeyDown(ActionKeyAlt) || Input.GetMouseButtonDown(0))
        {
            Turn();
        }
    }
    protected virtual void HandleMovement()
    {
        _newPosition = (_speed * Time.deltaTime * Direction);
        this.transform.position += _newPosition;
    }
    public virtual void Turn()
    {
        TurnFeedback?.PlayFeedbacks();
        Direction = MMMaths.RotateVector2(Direction, 90f);
        this.transform.Rotate(new Vector3(0f, 0f, 90f));
    }
    public virtual void Teleport()
    {
        //   StartCoroutine(TeleportCo());
    }
    public virtual void Eat()
    {
        EatEffect();

        EatFeedback?.PlayFeedbacks();
        AnimalPoints++;
        PointsCounter.text = AnimalPoints.ToString();
    }

    public virtual void EatEffect()
    {
            //_lastFoodEatenAt = Time.time;

            AnimalPrefab part = Instantiate(AnimalPartPrefab);
            part.transform.position = this.transform.position;
            part.TargetRecorder = _recorder;
            part.Offset = ((AnimalPoints) * BodyPartsOffset) + BodyPartsOffset + 1;

            part.Index = _animalPrefabs.Count;
            part.name = "AnimalPrefabs_" + part.Index;
            _animalPrefabs.Add(part);
        
    }

}