using System;
using System.Collections.Generic;
using Kings_of_Knives.Scripts.Tables;
using UnityEngine;

namespace Kings_of_Knives.Scripts.Interact.Tables.CuttingTable
{
    public class CuttingTable : BaseTable, IHoldingInteractable
    {
        public event Action<float, float> OnHoldTimeChanged;

        public override void Interact()
        {
            if (_currentPlayerIngredient != null)
                _isCanPutOnTheTable = _currentPlayerIngredient.IngredientInfo.IsCanPutOnCuttingTable;

            base.Interact();

            if (_isWasBaseInteracted == true && IngredientOnTable == null)
                OnHoldTimeChanged?.Invoke(0, 0);
        }

        private Dictionary<IIngredient, float> _existedIngredients = new Dictionary<IIngredient, float>();

        public void HoldingInteract()
        {
            if (IngredientOnTable == null || IngredientOnTable.IngredientInfo.IsCanCut == false)
                return;

            if (IngredientOnTable.IngredientInfo.Output is not IngredientCuttingInfo ingredientCuttingInfo)
                return;

            var cuttingTime = 0.0f;

            if (_existedIngredients.ContainsKey(IngredientOnTable))
                cuttingTime = _existedIngredients[IngredientOnTable];
            else _existedIngredients.Add(IngredientOnTable, cuttingTime);

            var timeToCutting = ingredientCuttingInfo.TimeToCutting;

            cuttingTime += Time.deltaTime;

            OnHoldTimeChanged?.Invoke(cuttingTime, timeToCutting);

            if (cuttingTime >= ingredientCuttingInfo.TimeToCutting)
            {
                IngredientOnTable = new Ingredient(IngredientOnTable.IngredientInfo.Output);

                TriggerEventFromChild();

                _existedIngredients.Remove(IngredientOnTable);
            }
            else _existedIngredients[IngredientOnTable] = cuttingTime;
        }
    }
}