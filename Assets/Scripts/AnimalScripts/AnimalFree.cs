using System;
using System.Collections;
using System.Collections.Generic;
using MoreMountains.Feedbacks;
using MoreMountains.Tools;
using UnityEngine;

public class AnimalFree : MonoBehaviour
{
    /// a duration (in seconds) during which the food is inactive before moving it to another position
    public float OffDelay = 1f;
    /// the food's visual representation
    public GameObject Model;
    /// a feedback to play when food gets eaten
    public MMFeedbacks EatFeedback;
    /// a feedback to play when food appears
    public MMFeedbacks AppearFeedback;
    /// the food spawner
    public SpawnArea Spawner { get; set; }

    protected PlayerController _player;
  
    /// <summary>
    /// When this food gets eaten, we play its eat feedback, and start moving it somewhere else in the scene
    /// </summary>
    /// <param name="other"></param>
    protected void OnTriggerEnter2D(Collider2D other)
    {
        _player = other.GetComponent<PlayerController>();

        if (_player != null)
        {
            _player.Eat();
            EatFeedback?.PlayFeedbacks();
            StartCoroutine(MoveFood());
        }
    }

    /// <summary>
    /// Moves the food to another spot
    /// </summary>
    /// <returns></returns>
    protected virtual IEnumerator MoveFood()
    {
        Model.SetActive(false);
        yield return MMCoroutine.WaitFor(OffDelay);
        Model.SetActive(true);

        this.transform.position = Spawner.DetermineSpawnPosition();

        AppearFeedback?.PlayFeedbacks();
    }
}

