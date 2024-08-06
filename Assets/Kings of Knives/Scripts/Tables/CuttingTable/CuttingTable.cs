using System;
using Kings_of_Knives.Scripts.Services;
using Kings_of_Knives.Scripts.Services.Fabric.Ingredient;
using Kings_of_Knives.Scripts.Services.IngredientDestroyer;
using Kings_of_Knives.Scripts.Services.ProgressSavers;
using Zenject;
using Kings_of_Knives.Scripts.Tables;
using Kings_of_Knives.Scripts.UI.Ingredient;
using Unity.VisualScripting;
using UnityEngine;

namespace Kings_of_Knives.Scripts.Interact.Tables.CuttingTable
{
    public class CuttingTable : BaseTable, IHoldingInteractable
    {
         private IProgressSaverService<Ingredient> _cuttingProgressSaverService;
         private IIngredientFabric _ingredientFabric;
         private IngredientDestroyerService _ingredientDestroyerService;

        [Inject]
        public void Initialize(IProgressSaverService<Ingredient> cuttingProgressSaverService, IIngredientFabric ingredientFabric, IngredientDestroyerService ingredientDestroyerService)
        {
            _cuttingProgressSaverService = cuttingProgressSaverService;
            _ingredientFabric = ingredientFabric;
            _ingredientDestroyerService = ingredientDestroyerService;
        }
        
        public override void Interact()
        {
            if (CurrentPlayerIngredient != null)
                IsCanPutOnTheTable = CurrentPlayerIngredient.IngredientInfo.IsCanPutOnCuttingTable;

            base.Interact();
        }

        public void HoldingInteract()
        {
            CheckCuttingValid();

            var ingredientCuttingInfo = Ingredient.IngredientInfo.Output as IngredientCuttingInfo;

            var cuttingTime = _cuttingProgressSaverService.GetProgress(Ingredient);
            var timeToCutting = ingredientCuttingInfo.TimeToCutting;

            var progressBarUI = Ingredient.GetComponentInChildren<IngredientProgressBarUI>();

            if (progressBarUI == null)
                throw new NullReferenceException("Progress Bar UI component not found");
            
            progressBarUI.UpdateBar(cuttingTime, timeToCutting);
            
            cuttingTime += Time.deltaTime;
            _cuttingProgressSaverService.SetProgress(Ingredient, cuttingTime);

            if (cuttingTime >= timeToCutting)
            {
                CompleteCutting();
                progressBarUI.UpdateBar(cuttingTime, timeToCutting);
            }
        }

        private void CompleteCutting()
        {
            _ingredientDestroyerService.DestroyIngredient(Ingredient);
            
            Ingredient = _ingredientFabric.CreateIngredientFromSO(Ingredient.IngredientInfo.Output,
                Ingredient.transform.position, Ingredient.transform.parent);

            TriggerEventFromChild();
            
            _cuttingProgressSaverService.RemoveProgress(Ingredient);
        }

        private void CheckCuttingValid()
        {
            if (Ingredient == null)
                throw new ArgumentException("Nothing to cut. Ingredient is null.");

            if (Ingredient.IngredientInfo.IsCanCut == false)
                throw new ArgumentException($"Ingredient = {Ingredient}, isCanCut = false");

            if (Ingredient.IngredientInfo.Output is not IngredientCuttingInfo)
                throw new ArgumentException($"Ingredient = {Ingredient}, has no IngredientCuttingInfo");
        }
    }
}