using System;
using Cysharp.Threading.Tasks;
using Kings_of_Knives.Scripts.Services.Fabric.Ingredient;
using Kings_of_Knives.Scripts.Services.IngredientDestroyer;
using Kings_of_Knives.Scripts.Services.ProgressSavers;
using Kings_of_Knives.Scripts.UI.Ingredient;
using UnityEngine;
using Zenject;

namespace Kings_of_Knives.Scripts.Tables
{
    public class FryingTable : BaseTable
    {
        private IProgressSaverService<Ingredient> _fryingProgressSaverService;

        [Inject]
        public void Initialize(IProgressSaverService<Ingredient> fryingProgressSaverService)
        {
            _fryingProgressSaverService = fryingProgressSaverService;
        }

        public event Action FryingStarted;
        public event Action FryingStopped;
        
        public override void Interact()
        {
            if (CurrentPlayerIngredient != null)
                IsCanPutOnTheTable = CurrentPlayerIngredient.IngredientInfo.IsCanPutOnFryingTable;

            base.Interact();

             Fry().Forget();
        }

        private async UniTask Fry()
        {
            while (true)
            {
                if (Ingredient == null)
                {
                    FryingStopped?.Invoke();
                    break;
                }

                FryingStarted?.Invoke();

                CheckFryingValid();

                var ingredientFryingInfo = Ingredient.IngredientInfo.Output as IngredientFryingInfo;
                var fryingTime = _fryingProgressSaverService.GetProgress(Ingredient);
                var timeToFrying = ingredientFryingInfo.TimeToFrying;

                var progressBarUI = Ingredient.GetComponentInChildren<IngredientProgressBarUI>();

                if (progressBarUI == null)
                    throw new NullReferenceException("Progress Bar UI component not found");

                progressBarUI.UpdateBar(fryingTime, timeToFrying);
                

                await UniTask.Delay((int) (Time.deltaTime * 1000));
                fryingTime += Time.deltaTime;

                _fryingProgressSaverService.SetProgress(Ingredient, fryingTime);
                
                if (fryingTime >= timeToFrying)
                {
                    CompleteFrying();
                    progressBarUI.UpdateBar(fryingTime, timeToFrying);
                    break;
                }
            }
        }


        
        private void CompleteFrying()
        {
            ReplaceIngredientByCook();

            _fryingProgressSaverService.RemoveProgress(Ingredient);
            
            FryingStopped?.Invoke();
        }
        
        private void CheckFryingValid()
        {
            if (Ingredient.IngredientInfo.IsCanFry == false)
                throw new ArgumentException($"Ingredient = {Ingredient}, isCanFry = false");

            if (Ingredient.IngredientInfo.Output is not IngredientFryingInfo)
                throw new ArgumentException($"Ingredient = {Ingredient}, has no IngredientFryingInfo");
        }
    }
}