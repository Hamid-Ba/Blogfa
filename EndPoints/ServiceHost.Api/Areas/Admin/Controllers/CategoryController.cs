using Blogfa.Application.CategoryAgg.Create;
using Blogfa.Presentation.Facade.CategoryAgg;
using Microsoft.AspNetCore.Mvc;
using Framework.Application;
using Blogfa.Application.CategoryAgg.Edit;

namespace ServiceHost.Api.Areas.Admin.Controllers
{
    public class CategoryController : AdminBaseController
    {
        private readonly ICategoryFacade _categoryFacade;

        public CategoryController(ICategoryFacade categoryFacade) => _categoryFacade = categoryFacade;

        public async Task<IActionResult> Index() => View(await _categoryFacade.GetAll());

        [HttpGet]
        public IActionResult Create() => PartialView();

        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryCommand command,string Keyword,string Title,string Desc)
        {
            var seoData = new Framework.Domain.ValueObjects.SeoData(Keyword,Title, Desc);

            var result = await _categoryFacade.Create(new CreateCategoryCommand(command.Title,command.Slug,seoData));

            if (result.Status == OperationResultStatus.Success) TempData[SuccessMessage] = result.Message;

            return new JsonResult(result);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(long id)
        {
            var model = await _categoryFacade.GetBy(id);
            return PartialView(new EditCategoryCommand(id, model.Title, model.Slug, model.SeoData));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditCategoryCommand command)
        {
            var result = await _categoryFacade.Edit(command);

            if (result.Status == OperationResultStatus.Success) TempData[SuccessMessage] = result.Message;

            return new JsonResult(result);
        }
    }
}