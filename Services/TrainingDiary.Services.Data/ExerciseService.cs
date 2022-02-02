namespace TrainingDiary.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using TrainingDiary.Data.Common.Repositories;
    using TrainingDiary.Data.Models;
    using TrainingDiary.Services.Mapping;
    using TrainingDiary.Web.ViewModels.Exercises;

    public class ExerciseService : IExerciseService
    {
        private readonly IDeletableEntityRepository<Exercise> exercisesRepository;

        public ExerciseService(IDeletableEntityRepository<Exercise> exercisesRepository)
        {
            this.exercisesRepository = exercisesRepository;
        }

        public async Task AddExerciseAsync(CreateExerciseInputModel model, int trainingId)
        {
            var exercise = new Exercise()
            {
                Description = model.Description,
                TrainingId = trainingId,
            };

            await this.exercisesRepository.AddAsync(exercise);
            await this.exercisesRepository.SaveChangesAsync();
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
