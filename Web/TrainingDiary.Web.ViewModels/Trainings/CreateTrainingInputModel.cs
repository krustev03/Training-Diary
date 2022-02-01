namespace TrainingDiary.Web.ViewModels.Trainings
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class CreateTrainingInputModel
    {
        [Required]
        public DateTime Date { get; set; }
    }
}
