using ArticlesApp.Models;
using Microsoft.AspNetCore.Identity;

namespace ArticlesAppLab9Upload.Models;

public class ApplicationUser : IdentityUser 
{
    public virtual ICollection<Article>?  Articles { get; set; }
    public virtual ICollection<Comment>? Comments { get; set; } 
}