namespace TrainingDiary.Web.ViewModels.Trainings
{
    using System;
    using System.Collections.Generic;

    using TrainingDiary.Data.Models;
    using TrainingDiary.Services.Mapping;
    using TrainingDiary.Web.ViewModels.Exercises;

    public class TrainingViewModel : IMapFrom<Training>
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public IEnumerable<ExerciseViewModel> Exercises { get; set; }
    }
}
