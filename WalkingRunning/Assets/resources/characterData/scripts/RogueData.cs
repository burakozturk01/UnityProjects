using Types;
using UnityEngine;

[CreateAssetMenu(fileName = "New Rogue Data", menuName = "Character Data/Rogue")]
public class RogueData : CharacterData
{
    public RogueWeaponType wpnType;
    public RogueStrategyType strategyType;
}
