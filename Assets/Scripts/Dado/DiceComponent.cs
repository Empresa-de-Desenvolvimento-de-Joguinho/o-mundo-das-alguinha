using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

namespace Turno
{
    public class DiceComponent : TurnComponent
    {
        [SerializeField] private GameObject _dadoButton;
        [SerializeField] private GameObject _dadoRoll;
        [SerializeField] private GameObject _canvas;
        [SerializeField] private Image diceImage;
        [SerializeField] private Sprite[] _diceImages;

        public int diceSide;
        private bool canRollDice = true;
        private Random rnd = new Random();

        public int GetQuantityToMove()
        {
            return diceSide;
        }

        public virtual void RollDice()
        {
            if (!canRollDice)
            {
                FinishComponent();
            }

            diceSide = rnd.Next(1,6);

            diceImage.sprite = _diceImages[diceSide];
            canRollDice = false;
        }

        public void ShowDiceButton()
        {
            _dadoButton.SetActive(false);
            _dadoRoll.SetActive(true);
            RollDice();
        }

        public override void ShowElements()
        {
            _canvas.SetActive(true);
            _dadoButton.SetActive(true);
            _dadoRoll.SetActive(false);
        }

        protected override void HideComponent()
        {
            canRollDice = true;

            _canvas.SetActive(false);
            _dadoButton.SetActive(false);
            _dadoRoll.SetActive(false);
        }

        private void Start()
        {
            canRollDice = true;
        }
    }
}