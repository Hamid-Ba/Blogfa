using Blogfa.Application.CategoryAgg.Create;
using Blogfa.Presentation.Facade.CategoryAgg;
using Microsoft.AspNetCore.Mvc;
using Framework.Application;
using Blogfa.Application.CategoryAgg.Edit;

namespace ServiceHost.Api.Areas.Admin.Controllers
{
    public class CatrgoryController : AdminBaseController
    {
        private readonly ICategoryFacade _categoryFacade;

        public CatrgoryController(ICategoryFacade categoryFacade) => _categoryFacade = categoryFacade;
        
        public async Task<IActionResult>  Index() => View(await _categoryFacade.GetAll());

        [HttpGet]
        public IActionResult Create() => PartialView();

        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryCommand command)
        {
            var result = await _categoryFacade.Create(command);

            if (result.Status == OperationResultStatus.Success) TempData[SuccessMessage] = result.Message;

            return new JsonResult(result);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(long id) => PartialView(new EditCategoryCommand(id,"fake","fake",null!));

        [HttpPost]
        public async Task<IActionResult> Create(EditCategoryCommand command)
        {
            var result = await _categoryFacade.Edit(command);

            if (result.Status == OperationResultStatus.Success) TempData[SuccessMessage] = result.Message;

            return new JsonResult(result);
        }
    }
}