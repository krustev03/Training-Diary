namespace TrainingDiary.Services.Data
{
    using System.Collections.Generic;

    public interface IExerciseService
    {
        IEnumerable<T> GetAll<T>(int trainingId);
    }
}
