namespace TrainingDiary.Web.Controllers
{
    using System;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using TrainingDiary.Data.Models;
    using TrainingDiary.Services.Data;
    using TrainingDiary.Web.ViewModels.Trainings;

    public class TrainingsController : Controller
    {
        private readonly ITrainingService trainingsService;
        private readonly UserManager<ApplicationUser> userManager;

        public async Task<IActionResult> FilteredTraining(int trainingId)
        {
            return this.View();
        }
    }
}
