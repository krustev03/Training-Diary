namespace TrainingDiary.Web.Controllers
{
    using System.Diagnostics;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using TrainingDiary.Data.Models;
    using TrainingDiary.Services.Data;
    using TrainingDiary.Web.ViewModels;
    using TrainingDiary.Web.ViewModels.Exercises;
    using TrainingDiary.Web.ViewModels.Trainings;

    public class HomeController : BaseController
    {
        private readonly ITrainingService trainingService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IUserService userService;

        public HomeController(
            ITrainingService trainingService,
            UserManager<ApplicationUser> userManager,
            IUserService userService)
        {
            this.trainingService = trainingService;
            this.userManager = userManager;
            this.userService = userService;
        }

        public IActionResult Index()
        {
            return this.View();
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public async Task<IActionResult> SearchTraining(SearchTrainingViewModel model)
        {
            var appUser = await this.userManager.GetUserAsync(this.User);

            var training = this.trainingService.GetTraining<TrainingViewModel>(model.Date, appUser.Id);

            if (training == null)
            {
                return this.RedirectToAction("FilteredTraining", "Trainings", new { trainingId = 0 });
            }

            return this.RedirectToAction("FilteredTraining", "Trainings", new { trainingId = training.Id });
        }
    }
}
