using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroStats : MonoBehaviour
{
				// StatsUpdate() will inform all appropriate gameobjects that the hero stats changed.
				public delegate void UpdateStats();
				public static event UpdateStats StatsUpdate;

				[SerializeField]
				private int health;

				[SerializeField]
				private int attack;

				[SerializeField]
				private int defense;

				[SerializeField]
				private int speed;

				[SerializeField]
				private int turnbar;

				[SerializeField]
				private string heroName;

				// Use this for initialization
				void Start()
				{
				}

				// Update is called once per frame
				void Update()
				{
								if (IsDead())
								{
												SetTurnbar(0);
								}
				}

				#region Accessor Methods
				public int GetHealth()
				{
								return this.health;
				}

				public int GetAttack()
				{
								return attack;
				}

				public int GetDefense()
				{
								return defense;
				}

				public int GetSpeed()
				{
								return speed;
				}

				public int GetTurnbar()
				{
								return turnbar;
				}

				public string GetName()
				{
								return heroName;
				}
				#endregion

				public bool IsDead()
				{
								return health <= 0;
				}

				// Make sure that ALL mutations occur through Set* methods.
				#region Mutator Methods
				public void ModHealth(int delta)
				{
								SetHealth(health + delta);
				}

				public void ModTurnbar(int delta)
				{
								SetTurnbar(turnbar + delta);
				}

				public void ResetTurnbar()
				{
								SetTurnbar(0);
				}

				public void SetHealth(int num)
				{
								health = num;
								StatsUpdate();
				}

				public void SetAttack(int num)
				{
								attack = num;
								StatsUpdate();
				}

				public void SetDefense(int num)
				{
								defense = num;
								StatsUpdate();
				}

				public void SetSpeed(int num)
				{
								speed = num;
								StatsUpdate();
				}

				public void SetTurnbar(int num)
				{
								turnbar = num;
								StatsUpdate();
				}

				public void SetName(string name)
				{
								heroName = name;
								StatsUpdate();
				}
				#endregion

}
