namespace TrainingDiary.Services.Data
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;
    using TrainingDiary.Data.Models;

    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> usersRepository;

        public UserService(UserManager<ApplicationUser> usersRepository)
        {
            this.usersRepository = usersRepository;
        }

        public async Task<bool> HasTrainingAsync(DateTime date, string userId)
        {
            var appUser = await this.usersRepository.FindByIdAsync(userId);

            if (appUser.Trainings.Where(x => x.Date == date).Count() == 0)
            {
                return false;
            }

            return true;
        }
    }
}
