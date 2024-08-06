namespace Kings_of_Knives.Scripts.Services.ProgressSavers
{
    public interface IProgressSaverService<T>
    {
        float GetProgress(T item);
        void SetProgress(T item, float progress);
        void RemoveProgress(T item);
    }
}