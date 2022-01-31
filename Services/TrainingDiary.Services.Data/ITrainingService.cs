namespace TrainingDiary.Services.Data
{
    using System;

    public interface ITrainingService
    {
        T GetTraining<T>(DateTime date, string userId);
    }
}
