namespace TrainingDiary.Services.Data
{
    using System;
    using System.Linq;

    using TrainingDiary.Data.Common.Repositories;
    using TrainingDiary.Data.Models;
    using TrainingDiary.Services.Mapping;

    public class TrainingService : ITrainingService
    {
        private readonly IDeletableEntityRepository<Training> trainingsRepository;

        public TrainingService(IDeletableEntityRepository<Training> trainingsRepository)
        {
            this.trainingsRepository = trainingsRepository;
        }

        public T GetTraining<T>(DateTime date, string userId)
        {
            var training = this.trainingsRepository.AllAsNoTracking()
                .Where(x => x.Date == date && x.UserId == userId)
                .To<T>().FirstOrDefault();
            return training;
        }
    }
}
