using UnityEngine;

[CreateAssetMenu(menuName="Objects/Card")]
public class Card : ScriptableObject
{
    public new string name;
    public string description;

    public Sprite artwork;

    public int manaCost;
    public int attack;
    public int health;

    public override string ToString()
    {
        string s = "";
        
        s += "Name: " + this.name;
        s += "\nDescription: " + this.description;
        s += "\n\nMana cost: " + this.manaCost;
        s += "\nAttack: " + this.attack;
        s += "\nHealth: " + this.health;

        return s;
    }
}
