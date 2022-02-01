namespace TrainingDiary.Services.Data
{
    using System;
    using System.Threading.Tasks;

    using TrainingDiary.Web.ViewModels.Trainings;

    public interface ITrainingService
    {
        Task AddTrainingAsync(CreateTrainingInputModel model, string userId);

        T GetTrainingByDateAndUser<T>(DateTime date, string userId);

        T GetTrainingById<T>(int trainingId);
    }
}
