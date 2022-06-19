using AppManager.Data;
using AppManager.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ContactManager.Pages.Contacts
{
    public class CreateModel : DI_BasePageModel
    {
        public CreateModel(
            ApplicationDbContext context,
            IAuthorizationService authorizationService,
            UserManager<IdentityUser> userManager)
            : base(context, authorizationService, userManager)
        {
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public ItemModel ItemModel { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            ItemModel.OwnerID = UserManager.GetUserId(User);

            //var isAuthorized = await AuthorizationService.AuthorizeAsync(
            //                                            User, ItemModel,
            //                                            ItemModel.Create);
            //if (!isAuthorized.Succeeded)
            //{
            //      return Forbid();
            //}

            Context.ItemModel.Add(ItemModel);
            await Context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}