namespace TrainingDiary.Web.ViewModels.Trainings
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class SearchTrainingViewModel
    {
        [Required]
        public DateTime Date { get; set; }

        public bool HasTraining { get; set; }
    }
}
