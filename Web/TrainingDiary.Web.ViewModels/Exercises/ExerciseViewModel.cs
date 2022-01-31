namespace TrainingDiary.Web.ViewModels.Exercises
{
    using TrainingDiary.Data.Models;
    using TrainingDiary.Services.Mapping;

    public class ExerciseViewModel : IMapFrom<Exercise>
    {
        public string Description { get; set; }
    }
}
