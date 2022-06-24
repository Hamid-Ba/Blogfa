using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blogfa.Presentation.Facade.ArticleAgg;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.Api.Areas.Admin.Controllers
{
    public class ArticleController : AdminBaseController
    {
        private readonly IArticleFacade _articleFacade;

        public ArticleController(IArticleFacade articleFacade) => _articleFacade = articleFacade;

        public async Task<IActionResult> Index() => View(await _articleFacade.GetAllForAdmin());

        public async Task<IActionResult> Detail(long id) => PartialView(await _articleFacade.GetBy(id));
    }
}