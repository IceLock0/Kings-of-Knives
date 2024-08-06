using System.Collections.Generic;

namespace Kings_of_Knives.Scripts.Services.ProgressSavers
{
    public class ProgressSaverService<T> : IProgressSaverService<T>
    {
        private readonly Dictionary<T, float> _progressTimes = new Dictionary<T, float>();
        
        public float GetProgress(T item) => _progressTimes.TryGetValue(item, out var time) ? time : 0.0f;

        public void SetProgress(T item, float progress) => _progressTimes[item] = progress;

        public void RemoveProgress(T item) => _progressTimes.Remove(item);
    }
}