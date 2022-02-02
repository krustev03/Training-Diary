namespace TrainingDiary.Web.Controllers
{
    using System;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using TrainingDiary.Data.Models;
    using TrainingDiary.Services.Data;
    using TrainingDiary.Web.ViewModels.Exercises;
    using TrainingDiary.Web.ViewModels.Trainings;

    public class TrainingsController : Controller
    {
        private readonly ITrainingService trainingService;
        private readonly IExerciseService exerciseService;
        private readonly UserManager<ApplicationUser> userManager;

        public TrainingsController(
            ITrainingService trainingsService,
            IExerciseService exerciseService,
            UserManager<ApplicationUser> userManager)
        {
            this.trainingService = trainingsService;
            this.exerciseService = exerciseService;
            this.userManager = userManager;
        }

        public IActionResult Filtered(int trainingId)
        {
            if (trainingId == 0)
            {
                return this.View();
            }
            else
            {
                var training = this.trainingService.GetTrainingById<TrainingViewModel>(trainingId);

                var viewModel = new TrainingViewModel
                {
                    Id = training.Id,
                    Date = training.Date,
                    Exercises = this.exerciseService.GetAll<ExerciseViewModel>(trainingId),
                };

                return this.View(viewModel);
            }
        }

        public IActionResult Add()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateTrainingInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            var appUser = await this.userManager.GetUserAsync(this.User);

            try
            {
                await this.trainingService.AddTrainingAsync(model, appUser.Id);
            }
            catch (Exception ex)
            {
                this.ModelState.AddModelError(string.Empty, ex.Message);
                return this.View(model);
            }

            var training = this.trainingService.GetTrainingByDateAndUser<TrainingViewModel>(model.Date, appUser.Id);

            return this.RedirectToAction("Filtered", "Trainings", new { trainingId = training.Id });
        }
    }
}
