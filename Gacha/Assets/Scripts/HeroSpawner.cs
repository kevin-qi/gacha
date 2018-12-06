using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroSpawner : MonoBehaviour
{
				public delegate void Spawned();
				public static event Spawned HeroesSpawned;

				private ArrayList spawnPoints;

				[SerializeField]
				private GameObject heroPrefab;

				// Use this for initialization
				void Start()
				{
								spawnPoints = new ArrayList();
								// Collect all spawnpoints under Spawnpoints gameobject
								foreach(Transform spawnPoint in GameObject.Find("Spawnpoints").transform)
								{
												spawnPoints.Add(spawnPoint);
								}
								HeroLoader.LoadedHeroes += SpawnHeroes;
				}

				private void SpawnHeroes(ArrayList dataPacket)
				{
								int i = 0;
								foreach(Dictionary<string,string> stats in dataPacket)
								{
												Debug.Log(i);
												SpawnHero(stats, ((Transform) spawnPoints[i]));
												i += 1;
								}
								HeroesSpawned();
				}

				// Spawn hero with given stats at given spawnPoint
				private void SpawnHero(Dictionary<string, string> stats, Transform spawnPoint)
				{
								GameObject newHero = Instantiate(heroPrefab);
								// Set position
								newHero.transform.position = spawnPoint.position;
								// Set stats
								var statScript = newHero.GetComponent<HeroStats>();
								Debug.Log(Int32.Parse(stats["heroHp"]));
								statScript.SetHealth(100);
								
								statScript.SetDefense(Int32.Parse(stats["heroDef"]));
								statScript.SetAttack(Int32.Parse(stats["heroAtk"]));
								statScript.SetSpeed(Int32.Parse(stats["heroSpd"]));
								statScript.SetName(stats["heroName"]);
								statScript.SetTurnbar(0);
				}
}
