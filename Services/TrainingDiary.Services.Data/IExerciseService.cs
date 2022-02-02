namespace TrainingDiary.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using TrainingDiary.Web.ViewModels.Exercises;

    public interface IExerciseService
    {
        Task AddExerciseAsync(CreateExerciseInputModel model, int trainingId);

        IEnumerable<T> GetAll<T>(int trainingId);
    }
}
