namespace TrainingDiary.Web.Controllers
{
    using System;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using TrainingDiary.Services.Data;
    using TrainingDiary.Web.ViewModels.Exercises;

    public class ExercisesController : Controller
    {
        private readonly IExerciseService exerciseService;

        public ExercisesController(IExerciseService exerciseService)
        {
            this.exerciseService = exerciseService;
        }

        public IActionResult Add(int trainingId)
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(int trainingId, CreateExerciseInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            try
            {
                await this.exerciseService.AddExerciseAsync(model, trainingId);
            }
            catch (Exception ex)
            {
                this.ModelState.AddModelError(string.Empty, ex.Message);
                return this.View(model);
            }

            return this.RedirectToAction("Filtered", "Trainings", new { trainingId = trainingId });
        }
    }
}
