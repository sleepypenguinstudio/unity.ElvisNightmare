using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    private const float PlayDistanceSpawnLevelPart = 50;
    public int StartingSpawnLevelParts = 1;
    [SerializeField] private Transform LevelPart_Start;
    [SerializeField] private List<Transform> LevelPartList;
    [SerializeField] private Transform player;

    private Vector3 LastEndPosition;

    private void Awake()
    {
        LastEndPosition = LevelPart_Start.Find("EndPoint").position;
        for (int i=0; i< StartingSpawnLevelParts; i++)
        {
            SpawnLevelPart();
        }
    }

    private void Update()
    {
        if(Vector3.Distance(player.position, LastEndPosition) < PlayDistanceSpawnLevelPart)
        {
            SpawnLevelPart();
        }
    }

    private void SpawnLevelPart()
    {
        Transform ChosenLevelPart = LevelPartList[Random.Range(0, LevelPartList.Count)];
        Transform LastLevelPartTransform = SpawnLevelPart(ChosenLevelPart, LastEndPosition);
        LastEndPosition = LastLevelPartTransform.Find("EndPoint").position;
    }
    private Transform SpawnLevelPart(Transform LevelPart, Vector3 spawnPosition)
    {
        Transform LevelPartTransform = Instantiate(LevelPart, spawnPosition, Quaternion.identity);
        return LevelPartTransform;
    }
}
