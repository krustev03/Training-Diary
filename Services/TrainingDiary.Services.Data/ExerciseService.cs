namespace TrainingDiary.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using TrainingDiary.Data.Common.Repositories;
    using TrainingDiary.Data.Models;
    using TrainingDiary.Services.Mapping;

    public class ExerciseService : IExerciseService
    {
        private readonly IDeletableEntityRepository<Exercise> exercisesRepository;

        public ExerciseService(IDeletableEntityRepository<Exercise> exercisesRepository)
        {
            this.exercisesRepository = exercisesRepository;
        }

        public IEnumerable<T> GetAll<T>(int trainingId)
        {
            var exercises = this.exercisesRepository.AllAsNoTracking()
                .Where(x => x.TrainingId == trainingId)
                .OrderBy(x => x.Id)
                .To<T>().ToList();
            return exercises;
        }
    }
}
