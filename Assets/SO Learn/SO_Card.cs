using UnityEngine;
using NaughtyAttributes;

[CreateAssetMenu (menuName = "Profile/Card")]
public class SO_Card : ScriptableObject
{
    [Header("Character Infos")]
    public string Name;
    public string Description;
    public Type ElementalType;

    [Space, ShowAssetPreview]
    public Sprite CharacterImage;

    [Header("Character Stats")]
    public int Cost;
    public int Health;
    public int ATK;

}

public enum Type
{
    Fire,
    Ice,
    Water,
    Lightning,
    Physical,
    Quantum,
    Wind,
}