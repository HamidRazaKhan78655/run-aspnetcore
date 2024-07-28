using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspnetRun.Web.Pages
{
    public class IndexModel : PageModel
    {

        public async Task<IActionResult> OnGet()
        {

            //CategoryModel = await _indexPageService.GetCategoryWithProducts(1);
            //ProductModel = await _indexPageService.GetProducts();
            return Page();
        }
    }
}
