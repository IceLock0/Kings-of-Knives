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
            if (CurrentPlayerIngredient != null)
                IsCanPutOnTheTable = CurrentPlayerIngredient.IngredientInfo.IsCanPutOnCuttingTable;

            base.Interact();

            if (IsWasBaseInteracted == true && Ingredient == null)
                OnHoldTimeChanged?.Invoke(0, 0);
        }

        private Dictionary<IIngredient, float> _existedIngredients = new Dictionary<IIngredient, float>();

        public void HoldingInteract()
        {
            if (Ingredient == null || Ingredient.IngredientInfo.IsCanCut == false)
                return;

            if (Ingredient.IngredientInfo.Output is not IngredientCuttingInfo ingredientCuttingInfo)
                return;

            var cuttingTime = 0.0f;

            if (_existedIngredients.ContainsKey(Ingredient))
                cuttingTime = _existedIngredients[Ingredient];
            else _existedIngredients.Add(Ingredient, cuttingTime);

            var timeToCutting = ingredientCuttingInfo.TimeToCutting;

            cuttingTime += Time.deltaTime;

            OnHoldTimeChanged?.Invoke(cuttingTime, timeToCutting);

            if (cuttingTime >= ingredientCuttingInfo.TimeToCutting)
            {
                Ingredient = new Ingredient(Ingredient.IngredientInfo.Output);

                TriggerEventFromChild();

                _existedIngredients.Remove(Ingredient);
            }
            else _existedIngredients[Ingredient] = cuttingTime;
        }
    }
}