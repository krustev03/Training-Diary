namespace TrainingDiary.Services.Data
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using TrainingDiary.Data.Common.Repositories;
    using TrainingDiary.Data.Models;
    using TrainingDiary.Services.Mapping;
    using TrainingDiary.Web.ViewModels.Trainings;

    public class TrainingService : ITrainingService
    {
        private readonly IDeletableEntityRepository<Training> trainingsRepository;

        public TrainingService(IDeletableEntityRepository<Training> trainingsRepository)
        {
            this.trainingsRepository = trainingsRepository;
        }

        public async Task AddTrainingAsync(CreateTrainingInputModel model, string userId)
        {
            var training = new Training()
            {
                Date = model.Date,
                UserId = userId,
            };

            await this.trainingsRepository.AddAsync(training);
            await this.trainingsRepository.SaveChangesAsync();
        }

        public T GetTrainingByDateAndUser<T>(DateTime date, string userId)
        {
            var training = this.trainingsRepository.AllAsNoTracking()
                .Where(x => x.Date == date && x.UserId == userId)
                .To<T>().FirstOrDefault();
            return training;
        }

        public T GetTrainingById<T>(int trainingId)
        {
            var training = this.trainingsRepository.AllAsNoTracking()
                .Where(x => x.Id == trainingId)
                .To<T>().FirstOrDefault();
            return training;
        }
    }
}
