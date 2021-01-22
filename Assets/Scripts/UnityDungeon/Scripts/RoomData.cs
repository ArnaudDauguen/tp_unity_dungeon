using System.Collections;
using System.Collections.Generic;
using UnityDungeon;
using UnityEngine;

namespace UnityDungeon
{
	[CreateAssetMenu(fileName ="New room", menuName = "CustomScripts/Room")]
	public class RoomData : ScriptableObject
	{
		public RoomData leftRoom;
		public RoomData rightRoom;
		public CharacterData oponent;

		public string description;

		public float accuracyBoost;
		public float hpBoost;
		public float intelligenceBoost;
	}
}
