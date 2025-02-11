﻿namespace TrainingDiary.Web.Areas.Administration.Controllers
{
    using TrainingDiary.Common;
    using TrainingDiary.Web.Controllers;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    [Area("Administration")]
    public class AdministrationController : BaseController
    {
    }
}
