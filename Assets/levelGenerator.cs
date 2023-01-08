using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelGenerator : MonoBehaviour
{
    //private const float PlayerDistanceSpawn = 10;
    //[SerializeField] private Transform LevelPart_Start;
    [SerializeField] private Transform LevelPart1;
    [SerializeField] private Transform Player;
    private Vector3 levelPosition = new Vector3(51.4f, 1.438089f, 0.2f);
    private Vector3 additionToLevelPosition = new Vector3(51.4f, 0, 0);

    private void Awake()
    {

        //SpawnLevelPart(levelPosition);
        //SpawnLevelPart(levelPosition + additionToLevelPosition);
        //SpawnLevelPart(levelPosition + additionToLevelPosition + additionToLevelPosition);


    }


    private void SpawnLevelPart(Vector3 spawnPosition)
    {
        Instantiate(LevelPart1, spawnPosition, Quaternion.identity);
    }

    private void Update()
    {
        if (Player.position.x > 40.0f && Player.position.x < 40.1f)
        {
            SpawnLevelPart(levelPosition);
            levelPosition += additionToLevelPosition;
        }
        if (Player.position.x == 80)
        {
            SpawnLevelPart(levelPosition);
            levelPosition += additionToLevelPosition;
        }
    }
}