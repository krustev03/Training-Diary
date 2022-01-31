namespace TrainingDiary.Services.Data
{
    using System;
    using System.Threading.Tasks;

    public interface IUserService
    {
        Task<bool> HasTrainingAsync(DateTime date, string userId);
    }
}
