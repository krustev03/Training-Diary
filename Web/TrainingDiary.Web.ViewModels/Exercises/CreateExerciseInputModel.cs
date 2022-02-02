namespace TrainingDiary.Web.ViewModels.Exercises
{
    using System.ComponentModel.DataAnnotations;

    public class CreateExerciseInputModel
    {
        [Required]
        public string Description { get; set; }
    }
}
