using UnityEngine;

namespace Jogador
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Character", order = 1)]
    public class Character : ScriptableObject, ICharacter
    {
        [SerializeField] private Sprite sprite;

        [SerializeField] private string scientificName;

        [SerializeField] private Color color;

        [SerializeField] private CharacterType type;
    
        public Sprite GetSprite()
        {
            return sprite;
        }

        public string GetName()
        {
            return scientificName;
        }
        

        public Color GetColor()
        {
            return color;
        }

        public CharacterType GetType()
        {
            return type;
        }
        
    }

    public enum CharacterType
    {
        CHLOROPHYCEAE,
        CYANOBACTERIA,
        DIATOMACEAS,
        DINOFLAGELADA,
        EUGLENA
    }
}